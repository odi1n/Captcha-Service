using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Enums
{
    public class QueueId
    {
        public const int ImageToTextEng = 1;
        public const int ImageToTextRu = 2;
        public const int RecaptchaNoCaptcha = 5;
        public const int RCRecaptchaProxyless = 6;
        public const int Funcaptcha = 7;
        public const int FuncaptchaProxyless = 10;
        public const int RCSquareNetTask = 11;
        public const int RCGeeTestProxyOn = 12;
        public const int RCGeeTestProxyless = 13;
        public const int RecaptchaV3s03 = 18;
        public const int RecaptchaV3s07 = 19;
        public const int RecaptchaV3s09 = 20;

        public const string EnglishImageToText = "English ImageToText";
        public const string RussianImageToText = "Russian ImageToText";
        public const string RecaptchaProxyOn = "Recaptcha Proxy-on";
        public const string ACRecaptchaProxyless = "Recaptcha Proxyless";
        public const string FunCaptcha = "FunCaptcha";
        public const string FuncaptchaProxyles = "Funcaptcha Proxyless";
        public const string ACSquareNetTask = "Square Net Task";
        public const string ACGeeTestProxyOn = "GeeTest Proxy-on";
        public const string ACGeeTestProxyless = "GeeTest Proxyless";
    }
}
