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
using Cliver.Bot;
using Microsoft.Win32;

namespace Cliver.Custom
{
    public class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Cliver.Config.Initialize(new string[] { "Products", "Engine", "Log" });
                Cliver.Config.Reload();

                BrowserForm bf = new BrowserForm();
                bf.ShowDialog();

                //Cliver.Bot.Program.Run();//It is the entry when the app runs as a console app.
                //Cliver.BotGui.Program.Run();//It is the entry when the app uses the default GUI.
            }
            catch (Exception e)
            {
                LogMessage.Error(e);
            }
        }
    }

    public class CustomSession : Session
    {
        public CustomSession()
        {            
            InternetDateTime.CHECK_TEST_PERIOD_VALIDITY(2016, 12, 23);
        }

        override public void __Closing()
        {
        }

        public class DataItem : InputItem
        {
            readonly public string Status;

            override public void __Processor(BotCycle bc)
            {
                CustomSession session = (CustomSession)bc.Session;

                //bc.Add(new EmailItem(output_pdf, output_addendum_pdf, output_addendum1_pdf));
            }            
        }

        class EmailItem : InputItem
        {
            public DataItem Data { get { return (DataItem)__ParentItem; } }
            public readonly string Pdf;

            internal EmailItem(string pdf)
            {
                Pdf = pdf;
            }

            override public void __Processor(BotCycle bc)
            {
                CustomSession session = (CustomSession)bc.Session;
            }
        }
    }
}