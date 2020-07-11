using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Enums
{
    public enum QueueId
    {
        ImageToTextEng = 1,
        ImageToTextRu = 2,
        RecaptchaNoCaptcha = 5,
        RecaptchaProxyless = 6,
        Funcaptcha = 7,
        FuncaptchaProxyless = 10,
        SquareNetTask = 11,
        GeeTestProxyOn = 12,
        GeeTestProxyless = 13,
        RecaptchaV3s03 = 18,
        RecaptchaV3s07 = 19,
        RecaptchaV3s09 = 20,
    }
}
