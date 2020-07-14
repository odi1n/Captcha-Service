using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Enums
{
    partial class Method
    {
        public const string Post = "post";
        public const string UserreCaptcha = "userrecaptcha";
        public const string FunCaptcha = "funcaptcha";
        public const string KeyCaptcha = "keycaptcha";
        public const string GeeTest = "geetest";
        public const string HCaptcha = "hcaptcha";

        public const string CreateTask = "createTask";
        public const string GetTaskResult = "getTaskResult";
        public const string GetBalance = "getBalance";
        public const string GetQueueStats = "getQueueStats";
        public const string ReportIncorrectImageCaptcha = "reportIncorrectImageCaptcha";
        public const string ReportIncorrectRecaptcha = "reportIncorrectRecaptcha";
        public const string GetSpendingStats = "getSpendingStat ";
        public const string GetAppStats = "getAppStats";
        public const string SendFunds = "sendFunds";
        public const string Test = "test";

        public const string ImageToTextTask = "ImageToTextTask";
        public const string NoCaptchaTask = "NoCaptchaTask";
        public const string NoCaptchaTaskProxyless = "NoCaptchaTaskProxyless";
        public const string RecaptchaV3TaskProxyless = "RecaptchaV3TaskProxyless";
        public const string FunCaptchaTask = "FunCaptchaTask";
        public const string FunCaptchaTaskProxyless = "FunCaptchaTaskProxyless";
        public const string SquareNetTextTask = "SquareNetTextTask";
        public const string GeeTestTask = "GeeTestTask";
        public const string GeeTestTaskProxyless = "GeeTestTaskProxyless";
        public const string HCaptchaTask = "HCaptchaTask";
        public const string HCaptchaTaskProxyless = "HCaptchaTaskProxyless";
        public const string RecaptchaV1Task = "RecaptchaV1Task";
        public const string RecaptchaV1TaskProxyless = "RecaptchaV1TaskProxyless";
    }
}
