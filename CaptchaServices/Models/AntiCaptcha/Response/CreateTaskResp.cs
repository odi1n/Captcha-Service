﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.ACResponse.Response
{
    public class CreateTaskResp
    {
        [DataMember(Name = "errorId")]
        public int ErrorId { get; set; }
        [DataMember(Name = "errorCode")]
        public string ErrorCode { get; set; }
        [DataMember(Name = "errorDescription")]
        public string ErrorDescription { get; set; }
        [DataMember(Name = "taskId")]
        public int TaskId { get; set; }
    }
}
