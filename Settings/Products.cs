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

namespace Cliver.Custom
{
    public class Settings
    {
        public static readonly ProductsSettings Products;

        public class ProductsSettings : Cliver.Settings
        {
            public Dictionary<string, Product> Ids2Products = new Dictionary<string, Product>();
        }

        public class PriceChange
        {
            public float Price;
            public TimeSpan Time;
        }

        public class Product
        {
            public string Id;
            public List<int> Days;
            public List<PriceChange> PriceChanges;

            //[ScriptIgnore]
            [Newtonsoft.Json.JsonIgnore]
            public string Url
            {
                get
                {
                    return "https://fril.jp/item/" + Id + "/edit";
                }
            }
        }
    }
}