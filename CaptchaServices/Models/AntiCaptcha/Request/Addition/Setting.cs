﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Request.Addition
{
    [DataContract]
    public partial class Setting
    {
        [DataMember(Name ="clientKey")]
        public string ClientKey {  get; private set; }
        [DataMember(Name = "softId")]
        public int? SoftId { get; private set; }

        public void SetSetting(string clientKey, int? softId = null)
        {
            this.ClientKey = clientKey;
            this.SoftId = softId;
        }
    }
}
