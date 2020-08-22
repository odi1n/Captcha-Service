using Captcha_Service.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Other
{
    public class GetQueueStats 
    {
        [JsonProperty("queueId")]
        public QueueId QueueId { get; set; }
        public GetQueueStats(QueueId queueId)
        {
            this.QueueId = QueueId;
        }
    }
}
