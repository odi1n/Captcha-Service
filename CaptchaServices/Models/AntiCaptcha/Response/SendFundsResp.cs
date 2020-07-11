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
        [DataMember(Name = "errorId")]
        public int ErrorId { get; set; }
        [DataMember(Name = "errorCode")]
        public string ErrorCode { get; set; }
        [DataMember(Name = "errorDescription")]
        public string ErrorDescription { get; set; }
        [DataMember(Name = "balanceLeft")]
        public double BalanceLeft { get; set; }
    }
}
