using Captcha_Service.Models.AntiCaptcha.Request.Addition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Request
{
    public class GetBalance : Setting
    {
        public GetBalance(string clientKey)
        {
            SetSetting(clientKey);
        }
    }
}
