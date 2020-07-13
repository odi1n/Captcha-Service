using Captcha_Service.Models.AntiCaptcha.Request.Addition;
using Captcha_Service.Task;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Request
{

    public class SpendingStats : Setting
    {
        [JsonProperty(  "date")]
        public int date { get; set; }
        [JsonProperty( "queue")]
        public ACQueue Queue { get; set; }
        [JsonProperty(  "ip")]
        public string Ip { get; set; }
    }
}
