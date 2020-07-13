using Captcha_Service.Models.AntiCaptcha.Request.Addition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Request
{
    [DataContract]
    public class ReportIncorrect : Setting
    {
        [DataMember(Name = "taskId")]
        public int TaskId { get; set; }
        public ReportIncorrect(int taskId)
        {
            this.TaskId = taskId;
        }
    }
}
