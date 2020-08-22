using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Enums
{
    partial class Method
    {
        internal const string Post = "post";
        internal const string Base64 = "base64";
        internal const string UserreCaptcha = "userrecaptcha";
        internal const string FunCaptcha = "funcaptcha";
        internal const string KeyCaptcha = "keycaptcha";
        internal const string GeeTest = "geetest";
        internal const string HCaptcha = "hcaptcha";

        internal const string CreateTask = "createTask";
        internal const string GetTaskResult = "getTaskResult";
        internal const string GetBalance = "getBalance";
        internal const string GetQueueStats = "getQueueStats";
        internal const string ReportIncorrectImageCaptcha = "reportIncorrectImageCaptcha";
        internal const string ReportIncorrectRecaptcha = "reportIncorrectRecaptcha";
        internal const string GetSpendingStats = "getSpendingStat ";
        internal const string GetAppStats = "getAppStats";
        internal const string SendFunds = "sendFunds";
        internal const string Test = "test";

        internal const string ImageToTextTask = "ImageToTextTask";
        internal const string NoCaptchaTask = "NoCaptchaTask";
        internal const string NoCaptchaTaskProxyless = "NoCaptchaTaskProxyless";
        internal const string RecaptchaV3TaskProxyless = "RecaptchaV3TaskProxyless";
        internal const string FunCaptchaTask = "FunCaptchaTask";
        internal const string FunCaptchaTaskProxyless = "FunCaptchaTaskProxyless";
        internal const string SquareNetTextTask = "SquareNetTextTask";
        internal const string GeeTestTask = "GeeTestTask";
        internal const string GeeTestTaskProxyless = "GeeTestTaskProxyless";
        internal const string HCaptchaTask = "HCaptchaTask";
        internal const string HCaptchaTaskProxyless = "HCaptchaTaskProxyless";
        internal const string RecaptchaV1Task = "RecaptchaV1Task";
        internal const string RecaptchaV1TaskProxyless = "RecaptchaV1TaskProxyless";
    }
}
