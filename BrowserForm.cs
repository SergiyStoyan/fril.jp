using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cliver;

//LOGIN:
//mrsweeves@i.softbank.jp
//Crusaders-1


namespace Cliver.fril.jp
{
    public partial class BrowserForm : Form//BaseForm//
    {
        BrowserForm()
        {
            InitializeComponent();

            Text = "Product Collection";
            this.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetEntryAssembly().Location);

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

            browser.ObjectForScripting = this;
            browser.DocumentCompleted += Browser_DocumentCompleted;
            browser.Navigated += Browser_Navigated;
            browser.ProgressChanged += Browser_ProgressChanged;
            browser.Navigate(Url);
        }

        const string Url = "https://fril.jp/sell";

        public static void Open()
        {
            if (bf == null)
                bf = new BrowserForm();
            bf.Show();
            bf.Activate();
        }
        static BrowserForm bf = null;

        private void Browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (browser.Url == null || !browser.Url.AbsoluteUri.Contains(Url))
                return;
            switch (browser.ReadyState)
            {
                case WebBrowserReadyState.Interactive:
                    //HtmlElement s = browser.Document.CreateElement("script");
                    //s.SetAttribute("src", "https://code.jquery.com/jquery-2.2.0.min.js");
                    //browser.Document.Body.AppendChild(s);
                    //add_buttons();
                    break;
                case WebBrowserReadyState.Complete:
                    add_buttons();
                    break;
            }
        }

        private void Browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //add_buttons();
        }

        private void add_buttons()
        {
            string script = @"
var done = false;
$('.col-lg-4.col-md-4.col-sm-4.col-xs-4.text-right').each(function (index, value) {
    done = true;
//alert($(this).find('._added').length);
    if($(this).find('._added').length > 0) return;
//alert($(this).find('a:first').attr('href'));
    var pid = $(this).find('a:first').attr('href');
    var image_src = $(this).closest('.media').find('img:first').attr('src');
    $(this).append(""<span class='btn btn-default _added' onclick='window.external.EditProduct(\"""" + pid + ""\"", \"""" + image_src + ""\"");'>prices</span>"");
});
return done;
";
            for (int i = 0; i < 5; i++)
            {
                if ((bool)PerformScript(script))
                    return;
                SleepRoutines.Wait(300);
            }
        }

        private object PerformScript(string script)
        {
            script = @"(function() {" + script + @"}())";
            return browser.Invoke(() => { return browser.Document.InvokeScript("eval", new object[] { script }); });
        }

        public void EditProduct(string id, string image_src)
        {
            this.BeginInvoke(() =>
            {
                id = Regex.Replace(id, "/item/(.*?)/edit", "$1");
                ProductForm pf = new ProductForm(id, image_src);
                pf.ShowDialog();
            });
        }
    }
}