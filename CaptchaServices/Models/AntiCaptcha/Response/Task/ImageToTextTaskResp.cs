using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Response.Task
{
    public class ImageToTextTaskResp
    {
        [DataMember(Name = "errorId")]
        public int ErrorId { get; set; }
        [DataMember(Name = "taskId")]
        public int TaskId { get; set; }
    }
}
