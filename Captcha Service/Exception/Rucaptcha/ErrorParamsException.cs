using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Captcha_Service.Enum;

namespace Captcha_Service.Exception.Rucaptcha
{
    [Serializable]
    public class ErrorParamsException : System.Exception
    {
        public ErrorParamsException(string Message) : base(Message) { }
    }
}
