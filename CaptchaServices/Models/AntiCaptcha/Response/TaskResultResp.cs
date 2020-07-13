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
    public class TaskResultResp
    {
        [JsonProperty( "errorId")]
        public int ErrorId { get; set; }
        [JsonProperty( "errorCode")]
        public string ErrorCode { get; set; }
        [JsonProperty( "errorDescription")]
        public string ErrorDescription { get; set; }
        [JsonProperty( "status")]
        public Status Status { get; set; }
        [JsonProperty( "solution")]
        public Solution Solution { get; set; }
        [JsonProperty( "cost")]
        public string Cost { get; set; }
        [JsonProperty( "ip")]
        public string Ip { get; set; }
        [JsonProperty( "createTime")]
        public string CreateTime { get; set; }
        [JsonProperty( "endTime")]
        public string EndTime { get; set; }
        [JsonProperty( "solveCount")]
        public string SolveCount { get; set; }
    }
}
