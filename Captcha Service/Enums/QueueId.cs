using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Enums
{
    public class QueueId
    {
        internal const int ImageToTextEng = 1;
        internal const int ImageToTextRu = 2;
        internal const int RecaptchaNoCaptcha = 5;
        internal const int RCRecaptchaProxyless = 6;
        internal const int Funcaptcha = 7;
        internal const int FuncaptchaProxyless = 10;
        internal const int RCSquareNetTask = 11;
        internal const int RCGeeTestProxyOn = 12;
        internal const int RCGeeTestProxyless = 13;
        internal const int RecaptchaV3s03 = 18;
        internal const int RecaptchaV3s07 = 19;
        internal const int RecaptchaV3s09 = 20;

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
