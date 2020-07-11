using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Response.Addition
{
    public class Data
    {
        [DataMember(Name= "dateFrom")]
        public int DateFrom { get; set; }
        [DataMember(Name= "dateTill ")]
        public int DateTill { get; set; }
        [DataMember(Name= "volume")]
        public int Volume { get; set; }
        [DataMember(Name= "money")]
        public float Money { get; set; }
    }
}
