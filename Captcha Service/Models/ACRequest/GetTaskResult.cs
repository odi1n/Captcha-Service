using Captcha_Service.Models.ACRequest.Addition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Anticaptcha
{
    [DataContract]
    public class GetTaskResult : Setting
    {
        [DataMember(Name = "task")]

        public object Task { get; set; }

        public GetTaskResult(object task)
        {
            this.Task = task;
        }
    }
}
