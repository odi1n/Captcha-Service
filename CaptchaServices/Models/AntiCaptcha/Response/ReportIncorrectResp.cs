using Captcha_Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.ACResponse
{
    public class ReportIncorrectResp
    {
        [DataMember(Name = "errorId")]
        public int ErrorId{get;set; }
        [DataMember(Name = "status")]
        public Status Status { get;set; }
    }
}
