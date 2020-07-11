using Captcha_Service.Addition;
using Captcha_Service.Models.ACRequest;
using Captcha_Service.Models.Anticaptcha;
using Captcha_Service.Models.Anticaptcha.Response;
using Captcha_Service.Query;
using System.Threading;
using System.Web.Script.Serialization;

namespace Captcha_Service
{
    /// <summary>
    /// Класс для работы с сервисом Аnticaptcha.com
    /// </summary>
    public class AntiCaptcha
    {
        private string _key;
        private string _softId = "";
        private Request _request = new Request();

        private const string _link = "https://api.anti-captcha.com/";
        private const string _createTask = "createTask";
        private const string _getTaskResult = "getTaskResult";
        private const string _getBalance = "getBalance";
        private const string _getQueueStats = "getQueueStats";
        private const string _reportIncorrectImageCaptcha = "reportIncorrectImageCaptcha";
        private const string _reportIncorrectRecaptcha = "reportIncorrectRecaptcha";
        private const string _getSpendingStats = "getSpendingStat ";
        private const string _getAppStats = "getAppStats";
        private const string _sendFunds = "sendFunds";
        private const string _test = "test";

        public AntiCaptcha(string key)
        {
            this._key = key;
        }

        /// <summary>
        /// Cоздание задачи
        /// </summary>
        /// <param name="createTask">Модель данных</param>
        /// <returns></returns>
        public ACResponse CreateTask(CreateTask createTask)
        {
            createTask.SoftId = _softId;
            createTask.ClientKey = _key;
            var response = _request.PostJson(_link + _createTask, JsonConverts.Serializer<CreateTask>(createTask));
            return JsonConvert.Deserializ<ACResponse>(response);
        }

        /// <summary>
        /// Получить результат задачи
        /// </summary>
        /// <param name="getTaskResult">Модель данных</param>
        /// <returns></returns>
        public ACResponse GetTaskResult(GetTaskResult getTaskResult)
        {
            getTaskResult.SoftId = _softId;
            getTaskResult.ClientKey = _key;
            var response = _request.PostJson(_link + _getTaskResult, JsonConverts.Serializer<CreateTask>(getTaskResult));
            return JsonConvert.Deserializ<ACResponse>(response);
        }

        /// <summary>
        /// Получение баланса
        /// </summary>
        /// <returns></returns>
        public ACResponse GetBalance()
        {
            var response = _request.PostJson(_link + _getBalance, JsonConverts.Serializer<GetBalance>(new GetBalance(_key)));
            return JsonConvert.Deserializ<ACResponse>(response);
        }

        /// <summary>
        /// Получить информацию о загрузке очереди
        /// </summary>
        /// <param name="getTaskResult"></param>
        /// <returns></returns>
        public ACResponse GetQueueStats(GetQueueStats getQueueStatus)
        {
            var response = _request.PostJson(_link + _getQueueStats, JsonConvert.Serializer(getQueueStatus));
            return JsonConvert.Deserializ<ACResponse>(response);
        }

    }
}