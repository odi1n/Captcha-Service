using Captcha_Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Anticaptcha.Response
{
    [DataContract]
    public class ACResponse
    {
        [DataMember(Name = "errorId")]
        public int ErrorId { get; set; }

        [DataMember(Name = "errorCode")]
        public Error ErrorCode { get; set; }

        [DataMember(Name = "errorDescription")]
        public string ErrorDescription { get; set; }

        [DataMember(Name = "balance")]
        public string Balance { get; set; }

        [DataMember(Name = "taskId")]
        public int TaskId { get; set; }

        [DataMember(Name = "status")]
        public Status Status { get; set; }

        [DataMember(Name = "solution")]
        public object Solution { get; set; }

        [DataMember(Name = "cost")]
        public double Cost { get; set; }

        [DataMember(Name = "ip")]
        public string Ip { get; set; }

        [DataMember(Name = "createTime")]
        public int CreateTime { get; set; }

        [DataMember(Name = "endTime")]
        public int EndTime { get; set; }

        [DataMember(Name = "solveCount")]
        public int SolveCount { get; set; }

        [DataMember(Name = "waiting")]
        public int Waiting { get; set; }

        [DataMember(Name = "load")]
        public float Load { get; set; }

        [DataMember(Name = "bid")]
        public float Bid { get; set; }

        [DataMember(Name = "speed")]
        public float Speed { get; set; }

        [DataMember(Name = "total")]
        public int Total { get; set; }

    }
}
