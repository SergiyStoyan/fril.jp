//********************************************************************************************
//Author: Sergey Stoyan, CliverSoft.com
//        http://cliversoft.com
//        stoyan@cliversoft.com
//        sergey.stoyan@gmail.com
//        27 February 2007
//Copyright: (C) 2007, Sergey Stoyan
//********************************************************************************************

using System;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Net.Mail;
using Cliver;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Cliver.fril.jp
{
    public class Service
    {
        static Service()
        {
            //must be called from the main ui thread!
            // bf = new Browser2Form();
        }

        public static bool Running
        {
            set
            {
                if (value)
                {
                    //if (schedule_prices_t == null || !schedule_prices_t.IsAlive)
                    //    schedule_prices_t = Cliver.ThreadRoutines.StartTry(schedule_prices);
                    if (set_prices_t == null || !set_prices_t.IsAlive)
                        set_prices_t = Cliver.ThreadRoutines.StartTry(set_prices);
                }
                else
                {
                    if (set_prices_t != null && set_prices_t.IsAlive)
                        set_prices_t.Abort();
                }
            }
            get
            {
                return set_prices_t != null && set_prices_t.IsAlive && schedule_prices_t != null && schedule_prices_t.IsAlive;
            }
        }
        static Thread set_prices_t = null;
        readonly static Thread schedule_prices_t = Cliver.ThreadRoutines.StartTry(schedule_prices);

        readonly static Dictionary<string, LastPrice> pids2LastPrice = new Dictionary<string, LastPrice>();
        class LastPrice
        {
            public uint Price;
            public string ProductId;
            public bool Synchronized = false;
            public DateTime AttemptTime = DateTime.Now;
        }

        static void schedule_prices()
        {
            while (true)
            {
                lock (pids2LastPrice)
                {
                    lock (Settings.Products.Ids2Product)
                    {
                        foreach (string pid in Settings.Products.Ids2Product.Keys)
                        {
                            //if (Settings.Products.Ids2Products[pid].Deleted)
                            //    continue;
                            if (Settings.Products.Ids2Product[pid].PriceChanges.Count < 1)
                                continue;

                            Settings.PriceChange pc = null;
                            if (Settings.Products.Ids2Product[pid].Days.Contains((int)DateTime.Now.DayOfWeek))
                                pc = Settings.Products.Ids2Product[pid].PriceChanges.Where(x => DateTime.Now.Date + x.Time < DateTime.Now).OrderBy(x => x.Time).LastOrDefault();
                            if (pc == null)
                                pc = Settings.Products.Ids2Product[pid].PriceChanges.OrderBy(x => x.Time).LastOrDefault();

                            LastPrice lp;
                            if (!pids2LastPrice.TryGetValue(pid, out lp))
                            {
                                lp = new LastPrice { Price = pc.Price, ProductId = pid, Synchronized = false };
                                pids2LastPrice[pid] = lp;
                            }
                            else
                            {
                                if (lp.Price == pc.Price)
                                    continue;
                                lp.Price = pc.Price;
                                lp.AttemptTime = DateTime.Now;
                                lp.Synchronized = false;
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }

        static void set_prices()
        {
            try
            {
                while (true)
                {
                    LastPrice lp;
                    lock (pids2LastPrice)
                    {
                        lp = pids2LastPrice.Values.Where(x => !x.Synchronized && x.AttemptTime < DateTime.Now).FirstOrDefault();
                    }
                    if (lp == null)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                    int try_count = 0;
                    RETRY:
                    switch (set_price(lp.Price, lp.ProductId))
                    {
                        case SiteProduct.ERROR:
                            if (try_count++ < Settings.General.MaxTryCount)
                            {
                                Log.Main.Write("Price was not set for product " + lp.ProductId + ". Retrying...");
                                goto RETRY;
                            }
                            Log.Main.Warning("Price was not set for product " + lp.ProductId + ". Will retry in " + AttemptDelayInMins + " minutes.");
                            lock (pids2LastPrice)
                            {
                                lp.AttemptTime = DateTime.Now.AddMinutes(AttemptDelayInMins);
                            }
                            break;
                        case SiteProduct.PRODUCT_ABSENT:
                            Log.Main.Warning("Product " + lp.ProductId + " is absent on site. Removing it from the schedule.");
                            lock (Settings.Products.Ids2Product)
                            {
                                Settings.Products.Ids2Product.Remove(lp.ProductId);
                                // Settings.Products.Ids2Products[pid].Deleted
                                Settings.Products.Save();
                            }
                            lock (pids2LastPrice)
                            {
                                pids2LastPrice.Remove(lp.ProductId);
                            }
                            break;
                        case SiteProduct.SYNCHRONIZED:
                            lp.Synchronized = true;
                            Log.Main.Inform("Product: " + lp.ProductId + " set price: " + lp.Price);
                            break;
                        default:
                            throw new Exception("No such option exists");
                    }
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception e)
            {
                Log.Main.Error(e);
            }
        }
        const int AttemptDelayInMins = 10;

        enum SiteProduct
        {
            ERROR,
            PRODUCT_ABSENT,
            SYNCHRONIZED
        }

        static SiteProduct set_price(uint price, string pid)
        {
            return (SiteProduct)Browser2Form.Browser.Invoke(() =>
            {
                string url = "https://fril.jp/item/" + pid + "/edit";
                Browser2Form.Browser.Navigate(url);
                if (!SleepRoutines.WaitForCondition(() =>
                {
                    return Browser2Form.Browser.Url != null && Regex.IsMatch(Browser2Form.Browser.Url.AbsoluteUri, pid, RegexOptions.IgnoreCase);
                }, 30000))
                {
                    Log.Main.Error("Could not Navigate");
                    return SiteProduct.ERROR;
                }

                HtmlElement he = get_he("sell_price");
                if (he == null)
                {
                    if (Browser2Form.Browser.ReadyState == WebBrowserReadyState.Complete)
                        return SiteProduct.PRODUCT_ABSENT;
                    return SiteProduct.ERROR;
                }
                if (he.GetAttribute("value") == price.ToString())
                    return SiteProduct.SYNCHRONIZED;
                he.SetAttribute("value", price.ToString());

                he = get_he("confirm");
                if (he == null)
                    return SiteProduct.ERROR;
               // he.RaiseEvent("onclick");
                he.InvokeMember("click");
                if (!SleepRoutines.WaitForCondition(() =>
                {
                    var e = Browser2Form.Browser.Document.GetElementById("confirm-content");
                    if (e == null)
                        return false;
                    if (Regex.IsMatch(e.Style, @"display:\s*none", RegexOptions.IgnoreCase))
                        return false;
                    return true;

                }, 30000))
                {
                    Log.Main.Error("Price is not confirmed");
                    return SiteProduct.ERROR;
                }

                he = get_he("error");
                if (he == null)
                    return SiteProduct.ERROR;
                if (!string.IsNullOrWhiteSpace(he.InnerHtml))
                {
                    Log.Main.Error("Validation error: " + he.InnerHtml);
                    return SiteProduct.ERROR;
                }

                he = get_he("submit");
                if (he == null)
                    return SiteProduct.ERROR;
               // he.RaiseEvent("onclick");
                he.InvokeMember("click");
                if (!SleepRoutines.WaitForCondition(() =>
                {
                    return Browser2Form.Browser.Url != null && Regex.IsMatch(Browser2Form.Browser.Url.AbsoluteUri, @"fril\.jp/sell", RegexOptions.IgnoreCase);
                }, 30000))
                {
                    Log.Main.Error("Could not save price");
                    return SiteProduct.ERROR;
                }

                return SiteProduct.SYNCHRONIZED;
            });
        }

        static HtmlElement get_he(string id)
        {
            HtmlElement he = (HtmlElement)SleepRoutines.WaitForObject(() =>
            {
                if (Browser2Form.Browser.Document == null)
                    return null;
                return Browser2Form.Browser.Document.GetElementById(id);
            }, 30000);
            if (he == null)
                Log.Main.Error("Could not get HtmlElement: " + id);
            return he;
        }
    }
}