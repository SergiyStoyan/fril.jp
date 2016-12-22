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
using System.Data;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
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
            ProductForm.Change += ProductForm_Change;
        }

        private static void ProductForm_Change()
        {
            Start();
        }

        public static void Start()
        {
            if (t != null && t.IsAlive)
                // t.Abort();
                return;
            //load_PriceChanges();
            t = Cliver.ThreadRoutines.StartTry(run);
        }

        static Thread t = null;
        
        readonly static Dictionary<string, LastPrice> pids2LastPrice = new Dictionary<string, LastPrice>();
        class LastPrice
        {
            public float Price;
            public string ProductId;
            public bool Synchronized = false;
        }

        static void run()
        {
            while (true)
            {
                lock (pids2LastPrice)
                {
                    lock (Settings.Products.Ids2Products)
                    {
                        foreach (string pid in Settings.Products.Ids2Products.Keys)
                        {
                            Settings.PriceChange pc = Settings.Products.Ids2Products[pid].PriceChanges.Where(x => DateTime.Now.Date + x.Time < DateTime.Now).OrderBy(x => x.Time).LastOrDefault();

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
                                lp.Synchronized = true;
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }
        readonly Thread set_price_t = Cliver.ThreadRoutines.StartTry(set_prices);
        
        static void set_prices()
        {
            while (true)
            {
                LastPrice lp;
                lock (pids2LastPrice)
                {
                    lp = pids2LastPrice.Values.Where(x => !x.Synchronized).FirstOrDefault();
                }
                if (lp == null)
                {
                    Thread.Sleep(1000);
                    continue;
                }
                set_price(lp.Price, lp.ProductId);
                lp.Synchronized = true;
            }
        }

        static void set_price(float price, string pid)
        {
            //bro
            //sell_price

        }
    }
}