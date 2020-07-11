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
    public class CreateTask : Setting
    {
        [DataMember(Name = "task")]

        public object Task { get; set; }
        [DataMember(Name = "languagePool")]

        public string LanguagePool { get; set; }
        [DataMember(Name = "callbackUrl")]

        public string CallbackUrl { get; set; }

        public CreateTask(object task)
        {
            this.Task = task;
        }
    }
}
