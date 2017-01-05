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
        public static readonly SchedulesSettings Schedules;

        public class SchedulesSettings : Cliver.Settings
        {
            public Dictionary<string, Schedule> Names2Schedule = new Dictionary<string, Schedule>();
        }

        public class Schedule
        {
            public List<int> Days;
            public List<PriceChange> PriceChanges;
        }
    }
}