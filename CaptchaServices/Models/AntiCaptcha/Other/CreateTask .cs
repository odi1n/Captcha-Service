using Captcha_Service.Enums;
using Captcha_Service.Models.AntiCaptcha.Addition;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Other
{

    public class CreateTask : Setting
    {
        [JsonProperty(  "task")]
        public object Task { get; set; }

        [JsonProperty( "languagePool")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Lang LanguagePool { get; set; }

        [JsonProperty( "callbackUrl")]
        public string CallbackUrl { get; set; }

        public CreateTask(object task)
        {
            this.Task = task;
        }
    }
}
