using Captcha_Service.Models.AntiCaptcha.Request.Addition;
using Captcha_Service.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Request
{
    public class SpendingStats : Setting
    {
        [DataMember(Name = "date")]
        public int date { get; set; }
        [DataMember(Name = "queue")]
        public ACQueue Queue { get; set; }
        [DataMember(Name = "ip")]
        public string Ip { get; set; }
    }
}
