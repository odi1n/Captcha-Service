using Captcha_Service.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha
{
    public class QueueStatsResp
    {
        [JsonProperty( "waiting")]
        public int Waiting { get; set; }
        [JsonProperty( "load")]
        public float Load { get; set; }
        [JsonProperty( "bid")]
        public float Bid { get; set; }
        [JsonProperty( "speed")]
        public float Speed { get; set; }
        [JsonProperty( "total")]
        public int Total { get; set; }
    }
}
