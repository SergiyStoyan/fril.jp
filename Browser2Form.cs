using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cliver;
using System.Threading;

namespace Cliver.fril.jp
{
    public partial class Browser2Form : Form//BaseForm//
    {
        public Browser2Form()
        {
            InitializeComponent();

            //CefSettings settings = new CefSettings();
            //// Initialize cef with the provided settings
            //Cef.Initialize(settings);
            //// Create a browser component
            //ChromiumWebBrowser chromeBrowser = new ChromiumWebBrowser("_blank");
            //// Add it to the form and fill it to the form window.
            //this.Controls.Add(chromeBrowser);

            //chromeBrowser.BrowserSettings.ImageLoading = CefState..Load("https://fril.jp/sell?is_new=0");

            // Cliver.BotWeb.HttpRoutine hr = new BotWeb.HttpRoutine();

            //var f = Cliver.BotWeb.ChromeRoutines.ReadCookies();
            //foreach (var c in f)
            //    if (c.path.Contains("fril.jp"))
            //        if (!Cliver.Win32.InternetSetCookie(c.path, c.name, c.value))
            //            throw new Exception("Could not set cookie");

            browser.ScriptErrorsSuppressed = true;
            browser.ObjectForScripting = this;
            browser.DocumentCompleted += Browser_DocumentCompleted;
            browser.Navigated += Browser_Navigated;
            browser.ProgressChanged += Browser_ProgressChanged;

            if (!IsHandleCreated)
                CreateHandle();

            this.Visible = false;
            //Show();
        }

        public static System.Windows.Forms.WebBrowser Browser
        {
            get
            {
                if (bf == null)
                {
                    ControlRoutines.InvokeFromUiThread(() =>
                    {
                        bf = new Browser2Form();
                        var h = bf.Handle;
                    });
                }
                return bf.browser;
            }
        }
        static Browser2Form bf = null;

        private void Browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            ManagedWebBrowserReadyState = browser.ReadyState;
        }
        public WebBrowserReadyState ManagedWebBrowserReadyState = WebBrowserReadyState.Uninitialized;

        private void Browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }

//        private void add_buttons()
//        {
//            string script = @"
//$('.col-lg-4.col-md-4.col-sm-4.col-xs-4.text-right').each(function (index, value) {
////alert($(this).find('._added').length);
//    if($(this).find('._added').length > 0) return;
////alert($(this).find('a:first').attr('href'));
//    var pid = $(this).find('a:first').attr('href');
//    var image_src = $(this).closest('.media').find('img:first').attr('src');
//    $(this).append(""<a class='btn btn-default _added' onclick='window.external.EditProduct(\"""" + pid + ""\"", \"""" + image_src + ""\""); ' href='#'>prices</a>"");
//}); ";
//            Browser.Document.InvokeScript("eval", new object[] { script });
//        }

//        public void EditProduct(string id, string image_src)
//        {
//            id = Regex.Replace(id, "/item/(.*?)/edit", "$1");
//            ProductForm pf = new ProductForm(id, image_src);
//            pf.ShowDialog();
//        }
    }
}