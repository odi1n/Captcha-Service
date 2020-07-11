using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Additions
{
    partial class DictionaryConvert
    {
        public static string Deserialization(Dictionary<string, object> dict)
        {
            string str = string.Empty;

            foreach ( KeyValuePair<string, object> entry in dict )
            {
                if (entry.Value != null)
                {
                    if (str.Length > 0) str += "&";
                    if (entry.Value.ToString().Length == 0) continue;

                    var key = entry.Key != null ? entry.Key.ToString() : null;
                    var value = entry.Value != null ? entry.Value.ToString() : null;

                    int? bools = null;
                    try { if ((bool)entry.Value) bools = Convert.ToBoolean(entry.Value).GetHashCode();  value = null; } catch { }

                    str += key + "=" + value + bools;
                }
            }
            return str;
        }
    }
}
