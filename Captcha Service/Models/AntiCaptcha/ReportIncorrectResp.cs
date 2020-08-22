using Captcha_Service.Enums;
using Captcha_Service.Models.AntiCaptcha.Addition;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha
{
    public class ReportIncorrectResp : ErrorResp
    {
        [JsonProperty( "status")]
        public Status Status { get;set; }
    }
}
