using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.ACRequest.Addition
{
    [DataContract]
    public class Setting
    {
        [DataMember(Name ="clientKey")]
        public string ClientKey { get; set; }
        [DataMember(Name = "softId")]
        public string SoftId { get; set; }
    }
}
