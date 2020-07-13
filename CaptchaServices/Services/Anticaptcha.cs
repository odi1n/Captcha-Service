using Captcha_Service.Additions;
using Captcha_Service.Query;
using System.Threading;
using System.Web.Script.Serialization;
using Captcha_Service.Task;
using Captcha_Service.Models.ACResponse;
using Captcha_Service.Models;
using Captcha_Service.Models.AntiCaptcha.Request;
using Captcha_Service.Models.AntiCaptcha.Response;
using Captcha_Service.Models.ACResponse.Response;
using Captcha_Service.Models.AntiCaptcha.Request.Task;
using Captcha_Service.Models.AntiCaptcha.Response.Task;

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
        private const string _link = "https://" + _linkMain + "/";

        public AntiCaptcha(string key)
        {
            setting = new SettingCap(key, true, 0);
        }

        /// <summary>
        /// Cоздание задачи
        /// </summary>
        /// <param name="createTask">Модель данных</param>
        /// <returns></returns>
        private CreateTaskResp CreateTask(CreateTask createTask)
        {
            createTask.SetSetting(setting.Key, setting.SoftId);
            var inf = JsonConverts.Serializer<CreateTask>(createTask);
            var infs = JsonConvert.Serializer(createTask);


            var response = _request.Post(_link + ACTask.CreateTask, JsonConverts.Serializer<CreateTask>(createTask));
            return JsonConvert.Deserializ<CreateTaskResp>(response);
        }

        /// <summary>
        /// Получить результат задачи
        /// </summary>
        /// <param name="getTaskResult">Модель данных</param>
        /// <returns></returns>
        private TaskResultResp GetTaskResult(GetTaskResult getTaskResult)
        {
            getTaskResult.SetSetting(setting.Key);
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
            reportIncorrect.SetSetting(setting.Key);
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
            reportIncorrect.SetSetting(setting.Key);
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
            spendingStats.SetSetting(setting.Key);
            var response = _request.Post(_link + ACTask.GetSpendingStats, JsonConvert.Serializer(spendingStats));
            return JsonConvert.Deserializ<SpendingStatsResp>(response);
        }

        /// <summary>
        /// Отправить средства другому пользователю
        /// </summary>
        /// <param name="sendFunds">Модель данных</param>
        /// <returns></returns>
        public SendFundsResp SendFunds(SendFunds sendFunds)
        {
            sendFunds.SetSetting(setting.Key);
            var response = _request.Post(_link + ACTask.SendFunds, JsonConvert.Serializer(sendFunds));
            return JsonConvert.Deserializ<SendFundsResp>(response);
        }

        /// <summary>
        /// Тестовый метод для отладки
        /// </summary>
        /// <param name="test">Модель данных</param>
        /// <returns></returns>
        public string Test(Test test)
        {
            var response = _request.Post(_link + ACTask.Test, JsonConvert.Serializer(test));
            return response;
        }

        public TaskResultResp ImageToTextTask(ImageToTextTask imageToText)
        {
            imageToText.SetSetting(setting.Key, setting.SoftId);

            var create = CreateTask(new CreateTask(imageToText));
            var response = _request.Post(_link + ACTask.ImageToTextTask, JsonConvert.Serializer(create));
            var imageInfo =  JsonConvert.Deserializ<ImageToTextTaskResp>(response);

            while (true)
            {
                var result = GetTaskResult(new GetTaskResult(imageInfo.TaskId));
                if (result.ErrorId == 0)
                    return result;
            }
        }

    }
}