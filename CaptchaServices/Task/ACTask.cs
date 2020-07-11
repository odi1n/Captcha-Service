using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Task
{
    class ACTask
    {
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
    }
}
