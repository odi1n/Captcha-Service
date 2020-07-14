using Captcha_Service.Additions;
using System.Threading;
using Captcha_Service.Models;
using Captcha_Service.Models.AntiCaptcha.Request;
using Captcha_Service.Enums;
using Captcha_Service.Models.AntiCaptcha;

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
            setting = new SettingCap(key, true);
        }

        /// <summary>
        /// Cоздание задачи
        /// </summary>
        /// <param name="createTask">Модель данных</param>
        /// <returns></returns>
        private CreateTaskResp CreateTask(CreateTask createTask)
        {
            createTask.SetSetting(setting.Key, setting.SoftId);
            var response = _request.Post(_link + Method.CreateTask, JsonConverts.Serializer(createTask));
            return JsonConverts.Deserializ<CreateTaskResp>(response);
        }

        /// <summary>
        /// Получить результат задачи
        /// </summary>
        /// <param name="getTaskResult">Модель данных</param>
        /// <returns></returns>
        private TaskResultResp GetTaskResult(GetTaskResult getTaskResult)
        {
            getTaskResult.SetSetting(setting.Key);
            var response = _request.Post(_link + Method.GetTaskResult, JsonConverts.Serializer(getTaskResult));
            return JsonConverts.Deserializ<TaskResultResp>(response);
        }

        private TaskResultResp GetResult(CreateTaskResp create, int sleep = 2000)
        {
            while (true)
            {
                var result = GetTaskResult(new GetTaskResult(create.TaskId));
                if (result.ErrorId == 0)
                    return result;
                Thread.Sleep(sleep);
            }
        }

        /// <summary>
        /// Получение баланса
        /// </summary>
        /// <returns></returns>
        public BalanceResp GetBalance()
        {
            var response = _request.Post(_link + Method.GetBalance, JsonConverts.Serializer(new GetBalance(setting.Key)));
            return JsonConverts.Deserializ<BalanceResp>(response);
        }

        /// <summary>
        /// Получить информацию о загрузке очереди
        /// </summary>
        /// <param name="getTaskResult">Модель данных</param>
        /// <returns></returns>
        public QueueStatsResp GetQueueStats(GetQueueStats getQueueStatus)
        {
            var response = _request.Post(_link + Method.GetQueueStats, JsonConverts.Serializer(getQueueStatus));
            return JsonConverts.Deserializ<QueueStatsResp>(response);
        }

        /// <summary>
        /// Пожаловаться на капчу
        /// </summary>
        /// <param name="reportIncorrect">Модель данных</param>
        /// <returns></returns>
        public ReportIncorrectResp ReportIncorrectImageCaptcha(ReportIncorrect reportIncorrect)
        {
            reportIncorrect.SetSetting(setting.Key);
            var response = _request.Post(_link + Method.ReportIncorrectImageCaptcha, JsonConverts.Serializer(reportIncorrect));
            return JsonConverts.Deserializ<ReportIncorrectResp>(response);
        }

        /// <summary>
        /// Пожаловаться на рекапчу
        /// </summary>
        /// <param name="reportIncorrect">Модель данных</param>
        /// <returns></returns>
        public ReportIncorrectResp ReportIncorrectRecaptcha(ReportIncorrect reportIncorrect)
        {
            reportIncorrect.SetSetting(setting.Key);
            var response = _request.Post(_link + Method.ReportIncorrectRecaptcha, JsonConverts.Serializer(reportIncorrect));
            return JsonConverts.Deserializ<ReportIncorrectResp>(response);
        }

        /// <summary>
        /// Получить статистику трат аккаунта
        /// </summary>
        /// <param name="spendingStats">Модель данных</param>
        /// <returns></returns>
        public SpendingStatsResp GetSpendingStats(SpendingStats spendingStats)
        {
            spendingStats.SetSetting(setting.Key);
            var response = _request.Post(_link + Method.GetSpendingStats, JsonConverts.Serializer(spendingStats));
            return JsonConverts.Deserializ<SpendingStatsResp>(response);
        }

        /// <summary>
        /// Отправить средства другому пользователю
        /// </summary>
        /// <param name="sendFunds">Модель данных</param>
        /// <returns></returns>
        public SendFundsResp SendFunds(SendFunds sendFunds)
        {
            sendFunds.SetSetting(setting.Key);
            var response = _request.Post(_link + Method.SendFunds, JsonConverts.Serializer(sendFunds));
            return JsonConverts.Deserializ<SendFundsResp>(response);
        }

        /// <summary>
        /// Тестовый метод для отладки
        /// </summary>
        /// <param name="test">Модель данных</param>
        /// <returns></returns>
        private string Test(Test test)
        {
            var response = _request.Post(_link + Method.Test, JsonConverts.Serializer(test));
            return response;
        }

        /// <summary>
        /// Решение обычной капчи с текстом
        /// </summary>
        /// <param name="imageToText">Модель данных</param>
        /// <param name="sleep">Задержка получения ответа</param>
        /// <returns></returns>
        public TaskResultResp ImageToText(ImageToText imageToText, int sleep = 3000)
        {
            var create = CreateTask(new CreateTask(imageToText));
            return GetResult(create, sleep);
        }

        /// <summary>
        /// Решение капчи Google
        /// </summary>
        /// <param name="noCaptchaTask">Модель данных</param>
        /// <param name="sleep">Задержка получения ответа</param>
        /// <returns></returns>
        public TaskResultResp NoCaptcha(NoCaptcha noCaptchaTask, int sleep = 4000)
        {
            var create = CreateTask(new CreateTask(noCaptchaTask));
            return GetResult(create, sleep);
        }

        /// <summary>
        /// Решение капчи Google версии 3
        /// </summary>
        /// <param name="recaptchaV3TaskProxyless">Модель данных</param>
        /// <param name="sleep">Задержка получения ответа</param>
        /// <returns></returns>
        public TaskResultResp RecaptchaV3(RecaptchaV3 recaptchaV3TaskProxyless, int sleep = 4000)
        {
            var create = CreateTask(new CreateTask(recaptchaV3TaskProxyless));
            return GetResult(create, sleep);
        }

        /// <summary>
        /// Funcaptcha без прокси
        /// </summary>
        /// <param name="funCaptchaTask">Модель данных</param>
        /// <param name="sleep">Задержка получения ответа</param>
        /// <returns></returns>
        public TaskResultResp FunCaptcha(FunCaptcha funCaptchaTask, int sleep = 4000)
        {
            var create = CreateTask(new CreateTask(funCaptchaTask));
            return GetResult(create, sleep);
        }

        /// <summary>
        /// Выбрать нужный объект на картинке с сеткой изображений
        /// </summary>
        /// <param name="squareNetText">Модель данных</param>
        /// <param name="sleep">Задержка получения ответа</param>
        /// <returns></returns>
        public TaskResultResp SquareNetText(SquareNetText squareNetText, int sleep = 4000)
        {
            var create = CreateTask(new CreateTask(squareNetText));
            return GetResult(create, sleep);
        }

        /// <summary>
        /// Решить капчу от geetest.com
        /// </summary>
        /// <param name="geeTest">Модель данных</param>
        /// <param name="sleep">Задержка получения ответа</param>
        /// <returns></returns>
        public TaskResultResp GeeTest(GeeTest geeTest, int sleep = 4000)
        {
            var create = CreateTask(new CreateTask(geeTest));
            return GetResult(create, sleep);
        }

        /// <summary>
        /// Решение капчи hCaptcha
        /// </summary>
        /// <param name="hCaptcha">Модель данных</param>
        /// <param name="sleep">Задержка получения ответа</param>
        /// <returns></returns>
        public TaskResultResp HCaptcha(HCaptcha hCaptcha, int sleep = 4000)
        {
            var create = CreateTask(new CreateTask(hCaptcha));
            return GetResult(create, sleep);
        }

        /// <summary>
        /// Старая версия рекапчи
        /// </summary>
        /// <param name="recaptchaV1">Модель данных</param>
        /// <param name="sleep">Задержка получения ответа</param>
        /// <returns></returns>
        public TaskResultResp RecaptchaV1(RecaptchaV1 recaptchaV1, int sleep = 4000)
        {
            var create = CreateTask(new CreateTask(recaptchaV1));
            return GetResult(create, sleep);
        }
    }
}