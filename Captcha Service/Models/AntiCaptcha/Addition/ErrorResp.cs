using Captcha_Service.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Addition
{
    public class ErrorResp
    {
        [JsonProperty("errorId")]
        public int ErrorId { get; set; }
        [JsonProperty("errorCode")]
        public Error? ErrorCode { get; set; }
        [JsonProperty("errorDescription")]
        public string ErrorDescription { get; set; }
    }
}
