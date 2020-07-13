using Captcha_Service.Enums;
using Captcha_Service.Models.AntiCaptcha.Request.Addition;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Request
{

    public class CreateTask : Setting
    {
        [JsonProperty(  "task")]
        public object Task { get; set; }

        [JsonProperty( "languagePool")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LanguagePool LanguagePool { get; set; }

        [JsonProperty( "callbackUrl")]
        public string CallbackUrl { get; set; }

        public CreateTask(object task)
        {
            this.Task = task;
        }
    }
}
