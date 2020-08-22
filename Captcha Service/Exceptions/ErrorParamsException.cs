using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Captcha_Service.Enums;

namespace Captcha_Service.Exceptions
{
    [Serializable]
    public class ErrorParamsException : System.Exception
    {
        public ErrorParamsException(string Message) : base(Message) { }
    }
}
