using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Response
{
    public class SendFundsResp
    {
        [JsonProperty( "errorId")]
        public int ErrorId { get; set; }
        [JsonProperty( "errorCode")]
        public string ErrorCode { get; set; }
        [JsonProperty( "errorDescription")]
        public string ErrorDescription { get; set; }
        [JsonProperty( "balanceLeft")]
        public double BalanceLeft { get; set; }
    }
}
