using Captcha_Service.Additions;
using Captcha_Service.Query;
using System.Threading;
using System.Web.Script.Serialization;
using Captcha_Service.Task;
using Captcha_Service.Models.ACResponse;
using Captcha_Service.Models;
using Captcha_Service.Models.AntiCaptcha.Request;

namespace Captcha_Service
{
    /// <summary>
    /// Класс для работы с сервисом Аnticaptcha.com
    /// </summary>
    public class AntiCaptcha
    {
        private SettingCap setting;
        private Request _request = new Request();

        private const string _linkMain = "api.anti-captcha.com";
        private const string _link = "https:/" + _linkMain + "/";

        public AntiCaptcha(string key)
        {
            setting = new SettingCap(key, true, 0);
        }

        /// <summary>
        /// Cоздание задачи
        /// </summary>
        /// <param name="createTask">Модель данных</param>
        /// <returns></returns>
        public CreateTaskResp CreateTask(CreateTask createTask)
        {
            createTask.SoftId = setting.SoftId;
            createTask.ClientKey = setting.Key;
            var response = _request.Post(_link + ACTask.CreateTask, JsonConverts.Serializer<CreateTask>(createTask));
            return JsonConvert.Deserializ<CreateTaskResp>(response);
        }

        /// <summary>
        /// Получить результат задачи
        /// </summary>
        /// <param name="getTaskResult">Модель данных</param>
        /// <returns></returns>
        public TaskResultResp GetTaskResult(GetTaskResult getTaskResult)
        {
            getTaskResult.ClientKey = setting.Key;
            var response = _request.Post(_link + ACTask.GetTaskResult, JsonConverts.Serializer<CreateTask>(getTaskResult));
            return JsonConvert.Deserializ<TaskResultResp>(response);
        }

        /// <summary>
        /// Получение баланса
        /// </summary>
        /// <returns></returns>
        public BalanceResp GetBalance()
        {
            var response = _request.Post(_link + ACTask.GetBalance, JsonConverts.Serializer<GetBalance>(new GetBalance(setting.Key)));
            return JsonConvert.Deserializ<BalanceResp>(response);
        }

        /// <summary>
        /// Получить информацию о загрузке очереди
        /// </summary>
        /// <param name="getTaskResult">Модель данных</param>
        /// <returns></returns>
        public QueueStatsResp GetQueueStats(GetQueueStats getQueueStatus)
        {
            var response = _request.Post(_link + ACTask.GetQueueStats, JsonConvert.Serializer(getQueueStatus));
            return JsonConvert.Deserializ<QueueStatsResp>(response);
        }

        /// <summary>
        /// Пожаловаться на капчу
        /// </summary>
        /// <param name="reportIncorrect">Модель данных</param>
        /// <returns></returns>
        public ReportIncorrectResp ReportIncorrectImageCaptcha(ReportIncorrect reportIncorrect)
        {
            reportIncorrect.ClientKey = setting.Key;
            var response = _request.Post(_link + ACTask.ReportIncorrectImageCaptcha, JsonConvert.Serializer(reportIncorrect));
            return JsonConvert.Deserializ<ReportIncorrectResp>(response);
        }

        /// <summary>
        /// Пожаловаться на рекапчу
        /// </summary>
        /// <param name="reportIncorrect">Модель данных</param>
        /// <returns></returns>
        public ReportIncorrectResp ReportIncorrectRecaptcha(ReportIncorrect reportIncorrect)
        {
            reportIncorrect.ClientKey = setting.Key;
            var response = _request.Post(_link + ACTask.ReportIncorrectRecaptcha, JsonConvert.Serializer(reportIncorrect));
            return JsonConvert.Deserializ<ReportIncorrectResp>(response);
        }

        /// <summary>
        /// Получить статистику трат аккаунта
        /// </summary>
        /// <param name="spendingStats">Модель данных</param>
        /// <returns></returns>
        public SpendingStatsResp GetSpendingStats(SpendingStats spendingStats)
        {
            spendingStats.ClientKey = setting.Key;
            var response = _request.Post(_link + ACTask.GetSpendingStats, JsonConvert.Serializer(spendingStats));
            return JsonConvert.Deserializ<SpendingStatsResp>(response);
        }


    }
}