using Captcha_Service.Enums;
using Captcha_Service.Models.ACResponse.Addition;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.ACResponse.Response
{
    public class BalanceResp
    {
        [JsonProperty( "errorId")]
        public int ErrorId { get; set; }
        [JsonProperty( "errorCode")]
        public Error? ErrorCode { get; set; }
        [JsonProperty( "errorDescription")]
        public string ErrorDescription { get; set; }
        [JsonProperty( "balance")]
        public float Balance { get; set; }
    }
}
