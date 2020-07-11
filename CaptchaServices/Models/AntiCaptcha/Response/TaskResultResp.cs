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
    public class TaskResultResp
    {
        [DataMember(Name = "errorId")]
        public int ErrorId { get; set; }
        [DataMember(Name = "errorCode")]
        public string ErrorCode { get; set; }
        [DataMember(Name = "errorDescription")]
        public string ErrorDescription { get; set; }
        [DataMember(Name = "status")]
        public Status Status { get; set; }
        [DataMember(Name = "solution")]
        public Solution Solution { get; set; }
        [DataMember(Name = "cost")]
        public string Cost { get; set; }
        [DataMember(Name = "ip")]
        public string Ip { get; set; }
        [DataMember(Name = "createTime")]
        public string CreateTime { get; set; }
        [DataMember(Name = "endTime")]
        public string EndTime { get; set; }
        [DataMember(Name = "solveCount")]
        public string SolveCount { get; set; }

    }
}
