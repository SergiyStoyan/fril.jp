using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace Cliver.Custom
{
    public partial class BrowserForm : Form
    {
        public BrowserForm()
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

            browser.ObjectForScripting = this;
            browser.DocumentCompleted += Browser_DocumentCompleted;
            browser.Navigated += Browser_Navigated;
            browser.ProgressChanged += Browser_ProgressChanged;
            browser.Navigate("https://fril.jp/sell?is_new=0");
        }

        private void Browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (browser.ReadyState == WebBrowserReadyState.Loaded)
            {
                HtmlElement s = browser.Document.CreateElement("script");
                s.SetAttribute("src", "https://code.jquery.com/jquery-2.2.0.min.js");
                browser.Document.Body.AppendChild(s);
            }
            if (browser.ReadyState == WebBrowserReadyState.Complete)
            {
                add_buttons();
            }
        }

        private void Browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            add_buttons();
        }

        private void add_buttons()
        {
            string script = @"
$('.col-lg-4.col-md-4.col-sm-4.col-xs-4.text-right').each(function (index, value) {
//alert($(this).find('._added').length);
    if($(this).find('._added').length > 0) return;
//alert($(this).find('a:first').attr('href'));
    var pid = $(this).find('a:first').attr('href');
    $(this).append(""<a class='btn btn-default _added' onclick='window.external.EditProduct(\"""" + pid + ""\""); ' href='#'>schedule</a>"");
}); ";
            browser.Document.InvokeScript("eval", new object[] { script });
        }

        public void EditProduct(string id)
        {
            id = Regex.Replace(id, "/item/(.*?)/edit", "$1");
            ProductForm pf = new ProductForm(id);
            pf.ShowDialog();
        }
    }
}