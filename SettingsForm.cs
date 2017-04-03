using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliver.fril.jp
{
    public partial class SettingsForm : BaseForm// Form// 
    {
        public SettingsForm()
        {
            InitializeComponent();

            FormClosed += delegate
              {
                  sf = null;
              };

            MaxTryCount.Text = Settings.General.MaxTryCount.ToString();          
        }

        //public class EncodingItem
        //{
        //    public string Text { get; set; }
        //    public int CodePage { get; set; }
        //}

        static public void Open()
        {
            if (sf == null)
                sf = new SettingsForm();
            sf.Show();
            sf.Activate();
        }
        static SettingsForm sf = null;

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.General.MaxTryCount = int.Parse(MaxTryCount.Text);

                Close();
            }
            catch (Exception ex)
            {
                Message.Exclaim(ex.Message);
            }
        }
    }
}