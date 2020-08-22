using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Addition
{
    public class Data
    {
        [JsonProperty( "dateFrom")]
        public int DateFrom { get; set; }
        [JsonProperty( "dateTill ")]
        public int DateTill { get; set; }
        [JsonProperty( "volume")]
        public int Volume { get; set; }
        [JsonProperty( "money")]
        public float Money { get; set; }
    }
}
