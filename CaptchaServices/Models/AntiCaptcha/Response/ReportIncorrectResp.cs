using Captcha_Service.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.ACResponse.Response
{
    public class ReportIncorrectResp
    {
        [JsonProperty( "errorId")]
        public int ErrorId{get;set; }
        [JsonProperty( "status")]
        public Status Status { get;set; }
    }
}
