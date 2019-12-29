using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Captcha_Service.Enum.Rucaptcha;

namespace Captcha_Service.Exception.Rucaptcha
{
    [Serializable]
    public class ErrorParamsRucaptchaException : System.Exception
    {
        public ErrorParamsRucaptchaException(string Message) : base(Message) { }
    }
}
