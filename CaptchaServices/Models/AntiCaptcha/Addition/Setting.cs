using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Addition
{
    public partial class Setting
    {
        internal static string ClientKeyStat { get; set; }
        internal static int? SoftIdStat { get; private set; }

        [JsonProperty("clientKey")]
        internal string ClientKey { get { return ClientKeyStat; } }
        [JsonProperty(  "softId")]
        public int? SoftId { get { return SoftIdStat; } }

        internal static void Set(string clientKey, int? softId = null)
        {
            ClientKeyStat = clientKey;
            SoftIdStat = softId;
        }
    }
}
