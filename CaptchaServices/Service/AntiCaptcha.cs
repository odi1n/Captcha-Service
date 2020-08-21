using Captcha_Service.Additions;
using System.Threading;
using Captcha_Service.Models;
using Captcha_Service.Models.AntiCaptcha.Request;
using Captcha_Service.Enums;
using Captcha_Service.Models.AntiCaptcha;
using Captcha_Service.Models.AntiCaptcha.Addition;
using Captcha_Service.Models.AntiCaptcha.Other;

namespace Captcha_Service
{
    /// <summary>
    /// Класс для работы с сервисом Аnticaptcha.com
    /// </summary>
    public class AntiCaptcha
    {
        private int? SoftId = null;
        private Request _request = new Request();
        private const string _linkMain = "api.anti-captcha.com";
        private const string _link = "https://" + _linkMain + "/";

        public delegate void GetAnswer(object e, TaskResultResp response);
        public event GetAnswer Answer;

        public AntiCaptcha(string key)
        {
            Setting.Set(key, SoftId);
        }

        /// <summary>
        /// Cоздание задачи
        /// </summary>
        /// <param name="createTask">Модель данных</param>
        /// <returns></returns>
        private CreateTaskResp CreateTask(CreateTask createTask)
        {
            var response = _request.Post(_link + Method.CreateTask, Converts.JsonSerializer(createTask));
            return Converts.JsonDeserializ<CreateTaskResp>(response);
        }

        /// <summary>
        /// Получить результат задачи
        /// </summary>
        /// <param name="getTaskResult">Модель данных</param>
        /// <returns></returns>
        private TaskResultResp GetTaskResult(GetTaskResult getTaskResult)
        {
            var response = _request.Post(_link + Method.GetTaskResult, Converts.JsonSerializer(getTaskResult));
            return Converts.JsonDeserializ<TaskResultResp>(response);
        }

        private TaskResultResp GetResult(CreateTaskResp create, int sleep = 2000)
        {
            while (true)
            {
                var result = GetTaskResult(new GetTaskResult(create.TaskId));
                if (result.ErrorId == 0)
                {
                    Answer?.Invoke(this, result);
                    return result;
                }
                Thread.Sleep(sleep);
            }
        }

        /// <summary>
        /// Получение баланса
        /// </summary>
        /// <returns></returns>
        public BalanceResp GetBalance()
        {
            var response = _request.Post(_link + Method.GetBalance, Converts.JsonSerializer(new GetBalance()));
            return Converts.JsonDeserializ<BalanceResp>(response);
        }

        /// <summary>
        /// Получить информацию о загрузке очереди
        /// </summary>
        /// <param name="getTaskResult">Модель данных</param>
        /// <returns></returns>
        public QueueStatsResp GetQueueStats(GetQueueStats getQueueStatus)
        {
            var response = _request.Post(_link + Method.GetQueueStats, Converts.JsonSerializer(getQueueStatus));
            return Converts.JsonDeserializ<QueueStatsResp>(response);
        }

        /// <summary>
        /// Пожаловаться на капчу
        /// </summary>
        /// <param name="reportIncorrect">Модель данных</param>
        /// <returns></returns>
        public ReportIncorrectResp ReportIncorrectImageCaptcha(ReportIncorrect reportIncorrect)
        {
            var response = _request.Post(_link + Method.ReportIncorrectImageCaptcha, Converts.JsonSerializer(reportIncorrect));
            return Converts.JsonDeserializ<ReportIncorrectResp>(response);
        }

        /// <summary>
        /// Пожаловаться на рекапчу
        /// </summary>
        /// <param name="reportIncorrect">Модель данных</param>
        /// <returns></returns>
        public ReportIncorrectResp ReportIncorrectRecaptcha(ReportIncorrect reportIncorrect)
        {
            var response = _request.Post(_link + Method.ReportIncorrectRecaptcha, Converts.JsonSerializer(reportIncorrect));
            return Converts.JsonDeserializ<ReportIncorrectResp>(response);
        }

        /// <summary>
        /// Получить статистику трат аккаунта
        /// </summary>
        /// <param name="spendingStats">Модель данных</param>
        /// <returns></returns>
        public SpendingStatsResp GetSpendingStats(SpendingStats spendingStats)
        {
            var response = _request.Post(_link + Method.GetSpendingStats, Converts.JsonSerializer(spendingStats));
            return Converts.JsonDeserializ<SpendingStatsResp>(response);
        }

        /// <summary>
        /// Отправить средства другому пользователю
        /// </summary>
        /// <param name="sendFunds">Модель данных</param>
        /// <returns></returns>
        public SendFundsResp SendFunds(SendFunds sendFunds)
        {
            var response = _request.Post(_link + Method.SendFunds, Converts.JsonSerializer(sendFunds));
            return Converts.JsonDeserializ<SendFundsResp>(response);
        }

        /// <summary>
        /// Тестовый метод для отладки
        /// </summary>
        /// <param name="test">Модель данных</param>
        /// <returns></returns>
        private string Test(Test test)
        {
            var response = _request.Post(_link + Method.Test, Converts.JsonSerializer(test));
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