using Captcha_Service.Enums;
using Captcha_Service.Models.ACResponse.Addition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.ACResponse
{
    public class BalanceResp
    {
        [DataMember(Name = "errorId")]
        public int ErrorId { get; set; }
        [DataMember(Name = "errorCode")]
        public string ErrorCode { get; set; }
        [DataMember(Name = "errorDescription")]
        public string ErrorDescription { get; set; }
        [DataMember(Name = "balance")]
        public float Balance { get; set; }
    }
}
