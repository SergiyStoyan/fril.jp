using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Script.Serialization;

namespace Cliver.fril.jp
{
    public partial class Settings
    {
        [Cliver.Settings.Obligatory]
        public static readonly GeneralSettings General;

        public class GeneralSettings : Cliver.Settings
        { 
            public int MaxTryCount = 10;
        }
    }
}