using Captcha_Service.Enums;
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
    public class CreateTask : Setting
    {
        [DataMember(Name = "task")]
        public object Task { get; set; }
        [DataMember(Name = "languagePool")]

        public LanguagePool LanguagePool { get; set; }
        [DataMember(Name = "callbackUrl")]

        public string CallbackUrl { get; set; }

        public CreateTask(object task)
        {
            this.Task = task;
        }
    }
}
