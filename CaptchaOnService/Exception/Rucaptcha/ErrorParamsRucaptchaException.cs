using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Exception.Rucaptcha
{
    [Serializable]
    class ErrorParamsRucaptchaException : System.Exception
    {
        public ErrorParamsRucaptchaException(string Message) : base(Message) { }
    }
}
