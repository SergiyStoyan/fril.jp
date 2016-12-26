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
    public class Program
    {
        static Program()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.UnhandledException += delegate (object sender, UnhandledExceptionEventArgs args)
            {
                Exception e = (Exception)args.ExceptionObject;
                Message.Error(e);
                Application.Exit();
            };
        }

        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                InternetDateTime.CHECK_TEST_PERIOD_VALIDITY(2016, 12, 30);

                Log.Initialize(Log.Mode.ONLY_LOG, null, true, 5);
                Cliver.Config.Initialize(new string[] { "Products"/*, "Engine", "Log"*/ });
                Cliver.Config.Reload();

                Service.Running = true;

                Application.Run(SysTray.This);
            }
            catch (Exception e)
            {
                Message.Error(e);
            }
            finally
            {
                Environment.Exit(0);
            }
        }
    }
}