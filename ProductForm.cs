using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliver.Custom
{
    public partial class ProductForm : Form
    {
        public ProductForm(string id)
        {
            InitializeComponent();

            prices.ValueMember = "Time";
            prices.DisplayMember = "Text";

            Text = "Product Schedule {ID: " + id + "}";

            Id = id;
            //Url = url;
            Settings.Product p;
            if (Settings.Products.Ids2Products.TryGetValue(id, out p))
            {
                foreach (int d in p.Days)
                    days.SelectedIndex = d;
                foreach (Settings.PriceChange pc in p.PriceChanges)
                    prices.Items.Add(new PriceItem(pc.Time, pc.Price));
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
                float p;
                if (!float.TryParse(p_, out p))
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
                            return;
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
                    return;
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
            public float Price { get; set; }
            public string Text { get; set; }

            public PriceItem(TimeSpan time, float price)
            {
                Text = price.ToString() + " at " + time.ToString(@"hh\:mm");
                Price = price;
                Time = time;
            }
        }

        private void bRemove_Click(object sender, EventArgs e)
        {
            if (prices.SelectedIndex >= 0)
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
                Settings.Products.Ids2Products[p.Id] = p;
            }
            catch (Exception ex)
            {
                Message.Error(ex.Message);
                return;
            }
            Settings.Products.Save();
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}