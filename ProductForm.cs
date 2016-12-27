using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cliver;

namespace Cliver.fril.jp
{
    public partial class ProductForm : BaseForm//Form//
    {
        public ProductForm(string id, string image_url)
        {
            InitializeComponent();

            prices.ValueMember = "Time";
            prices.DisplayMember = "Text";

            Text = "Product Schedule {ID: " + id + "}";

            Id = id;
            //Url = url;
            image.ImageLocation = image_url;
            //link.Links[0].

            lock (Settings.Products.Ids2Products)
            {
                Settings.Product p;
                if (Settings.Products.Ids2Products.TryGetValue(id, out p))
                {
                    foreach (int d in p.Days)
                        days.SelectedIndex = d;
                    foreach (Settings.PriceChange pc in p.PriceChanges)
                        prices.Items.Add(new PriceItem(pc.Time, pc.Price));
                }
                else
                    for (int i = 0; i < 7; i++)
                        days.SelectedIndex = i;
            }
        }

        readonly string Id;
        //readonly string Url;

        private void bAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string p_ = price.Text;
                if (string.IsNullOrWhiteSpace(p_))
                    throw new Exception("Price not set.");
                uint p;
                if (!uint.TryParse(p_, out p))
                    throw new Exception("Price is wrong.");

                PriceItem price_item = new PriceItem(time.Value.TimeOfDay, p);

                for (int i = 0; i < prices.Items.Count; i++)
                {
                    PriceItem pi = (PriceItem)prices.Items[i];
                    if (pi.Time > time.Value.TimeOfDay)
                    {
                        if (pi.Price == price_item.Price)
                            prices.Items.RemoveAt(i);
                        if (i > 0 && ((PriceItem)prices.Items[i - 1]).Price == price_item.Price)
                            throw new Exception("Price is the same.");
                        prices.Items.Insert(i, price_item);
                        return;
                    }
                    if (pi.Time == time.Value.TimeOfDay)
                    {
                        prices.Items[i] = price_item;
                        return;
                    }
                }
                if (prices.Items.Count > 0 && ((PriceItem)prices.Items[prices.Items.Count - 1]).Price == price_item.Price)
                    throw new Exception("Price is the same.");
                prices.Items.Add(price_item);
            }
            catch (Exception ex)
            {
                Message.Error(ex.Message);
            }
        }

        public class PriceItem
        {
            public TimeSpan Time { get; set; }
            public uint Price { get; set; }
            public string Text { get; set; }

            public PriceItem(TimeSpan time, uint price)
            {
                Text = price.ToString() + " at " + time.ToString(@"hh\:mm\:ss");
                Price = price;
                Time = time;
            }
        }

        private void bRemove_Click(object sender, EventArgs e)
        {
            if (prices.SelectedIndex < 0)
                return;
            PriceItem pi = (PriceItem)prices.SelectedItem;
            price.Text = pi.Price.ToString();
            time.Value = new DateTime(2000, 1, 1, pi.Time.Hours, pi.Time.Minutes, pi.Time.Seconds);
            prices.Items.RemoveAt(prices.SelectedIndex);
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            try
            {
                List<Settings.PriceChange> pcs = new List<Settings.PriceChange>();
                for (int i = 0; i < prices.Items.Count; i++)
                {
                    PriceItem pi = (PriceItem)prices.Items[i];
                    pcs.Add(new Settings.PriceChange() { Price = pi.Price, Time = pi.Time });
                }
                List<int> ds = new List<int>();
                foreach (int i in days.SelectedIndices)
                    ds.Add(i);
                Settings.Product p = new Settings.Product();
                p.Days = ds;
                p.Id = Id;
                p.PriceChanges = pcs;
                //p.Url = Url;
                lock (Settings.Products.Ids2Products)
                {
                    Settings.Products.Ids2Products[p.Id] = p;
                }
            }
            catch (Exception ex)
            {
                Message.Error(ex.Message);
                return;
            }
            lock (Settings.Products)
            {
                Settings.Products.Save();
            }
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}