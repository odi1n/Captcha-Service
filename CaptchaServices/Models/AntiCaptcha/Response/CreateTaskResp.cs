using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.ACResponse.Response
{
    public class CreateTaskResp
    {
        [JsonProperty( "errorId")]
        public int ErrorId { get; set; }
        [JsonProperty( "errorCode")]
        public string ErrorCode { get; set; }
        [JsonProperty( "errorDescription")]
        public string ErrorDescription { get; set; }
        [JsonProperty( "taskId")]
        public int TaskId { get; set; }
    }
}
