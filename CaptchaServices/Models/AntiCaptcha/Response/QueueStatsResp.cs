using Captcha_Service.Enums;
using Captcha_Service.Models.ACResponse.Addition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.ACResponse.Response
{
    public class QueueStatsResp
    {
        [DataMember(Name = "waiting")]
        public int Waiting { get; set; }
        [DataMember(Name = "load")]
        public float Load { get; set; }
        [DataMember(Name = "bid")]
        public float Bid { get; set; }
        [DataMember(Name = "speed")]
        public float Speed { get; set; }
        [DataMember(Name = "total")]
        public int Total { get; set; }
    }
}
