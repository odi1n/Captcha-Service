using Captcha_Service.Enum;
using Captcha_Service.Models.ACRequest.Addition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.ACRequest
{
    [DataContract]
    public class GetQueueStats 
    {
        [DataMember(Name ="queueId")]
        public QueueId QueueId { get; set; }
        public GetQueueStats(QueueId queueId)
        {
            this.QueueId = QueueId;
        }
    }
}
