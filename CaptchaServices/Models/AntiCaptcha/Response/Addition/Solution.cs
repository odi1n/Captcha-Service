using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.ACResponse.Addition
{
    public class Solution
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }
        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}
