using Captcha_Service.Models.AntiCaptcha.Request.Addition;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Request
{

    public class GetTaskResult : Setting
    {
        [JsonProperty("taskId")]

        public int TaskId { get; set; }

        public GetTaskResult(int taskId)
        {
            this.TaskId = taskId;
        }
    }
}
