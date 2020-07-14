using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Request
{
    public partial class Setting
    {
        [JsonProperty("clientKey")]
        public string ClientKey {  get; private set; }
        [JsonProperty(  "softId")]
        public int? SoftId { get; private set; }

        internal void SetSetting(string clientKey, int? softId = null)
        {
            this.ClientKey = clientKey;
            this.SoftId = softId;
        }
    }
}
