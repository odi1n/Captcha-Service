using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Anticaptcha.wAnticaptcha
{
    public class JsonDes
    {
        #region Информационные
        /// <summary>
        /// Получить данные об ошибке
        /// </summary>
        public class Error
        {
            /// <summary>
            /// Идентификатор ошибки. 0 - ошибок нет, свойства errorCode и errorDescription отсутствуют
            /// >1 - код ошибки, информация об ошибке находится в свойстве errorCode и errorDescription
            /// </summary>
            public int errorId { get; set; }
            /// <summary>
            /// Код ошибки. 
            /// </summary>
            public string errorCode { get; set; }
            /// <summary>
            /// Краткое описание ошибки на английском языке.
            /// </summary>
            public string errorDescription { get; set; }
        }

        /// <summary>
        /// Получить результат задачи
        /// </summary>
        public class getTaskResult
        {
            /// <summary>
            /// Идентификатор ошибки. 0 - ошибок нет, свойства errorCode и errorDescription отсутствуют
            /// >1 - код ошибки, информация об ошибке находится в свойстве errorCode и errorDescription
            /// </summary>
            public int errorId { get; set; }
            /// <summary>
            /// processing - задача в процессе выполнения
            /// ready - задача выполнена, решение находится в свойстве solution
            /// </summary>
            public string status { get; set; }
            /// <summary>
            /// Стоимость решения в USD.
            /// </summary>
            public string cost { get; set; }
            /// <summary>
            /// IP адрес с которого пришел запрос на создание задачи.
            /// </summary>
            public string ip { get; set; }
            /// <summary>
            /// UNIX Timestamp создания задачи.
            /// </summary>
            public int createTime { get; set; }
            /// <summary>
            /// UNIX Timestamp завершения задачи.
            /// </summary>
            public int endTime { get; set; }
            /// <summary>
            /// Количество попыток решения задачи разными работниками
            /// </summary>
            public string solveCount { get; set; }
        }
        #endregion

        #region Дополнительные
        /// <summary>
        /// Получить данные о балансе
        /// </summary>
        public class GetBalance
        {
            /// <summary>
            /// Идентификатор ошибки. 0 - ошибок нет, свойства errorCode и errorDescription отсутствуют
            /// >1 - код ошибки, информация об ошибке находится в свойстве errorCode и errorDescription
            /// </summary>
            public int errorId { get; set; }
            /// <summary>
            /// Сумма на счете клиента
            /// </summary>
            public float balance { get; set; }
        }

        /// <summary>
        /// Получить информацию о загрузке очереди
        /// </summary>
        public class GetQueueStats
        {
            /// <summary>
            /// Количество свободных работников на линии, ожидающих задание
            /// </summary>
            public int waiting { get; set; }
            /// <summary>
            /// Загрузка очереди в процентах
            /// </summary>
            public float load { get; set; }
            /// <summary>
            /// Средняя стоимость решения одной задачи в USD
            /// </summary>
            public string bid { get; set; }
            /// <summary>
            /// Средняя скорость выполнения задания в секундах
            /// </summary>
            public float speed { get; set; }
            /// <summary>
            /// Общее количество работников на линии
            /// </summary>
            public int total { get; set; }
        }
        #endregion

        #region Решение капчи
        /// <summary>
        /// Получить данные о решение обычной капчи с текстом.
        /// </summary>
        public class ImageToText
        {
            /// <summary>
            /// Текст решения капчи
            /// </summary>
            public string text { get; set; }
            /// <summary>
            /// Веб-адрес по которому капча доступна в системе. Действует 48 часов, после этого файл удаляется.
            /// </summary>
            public string url { get; set; }
        }

        /// <summary>
        /// Решение капчи Google
        /// </summary>
        public class NoCaptchaTask
        {
            /// <summary>
            /// Хеш который необходимо подставить в форму с рекапчей в <textarea id="g-recaptcha-response" ..></textarea> . Имеет длину от 500 до 2190 байт.
            /// </summary>
            public string gRecaptchaResponse { get; set; }
            /// <summary>
            /// Контрольная сумма gRecaptchaResponse в MD5. Передается только если добавить параметр isExtended со значением true в методе getTaskResult.
            /// </summary>
            public string gRecaptchaResponseMD5 { get; set; }
        }

        /// <summary>
        /// Крутящаяся капча funcaptcha.com
        /// </summary>
        public class FunCaptcha
        {
            /// <summary>
            /// Токен фанкапчи который необходимо подставить в форму.
            /// </summary>
            public string token { get; set; }
        }

        /// <summary>
        /// Выбрать нужный объект на картинке с сеткой изображений
        /// </summary>
        public class SquareNetTextTask
        {
            /// <summary>
            /// Массив содержащий порядковые номера клеток, начиная с нуля, слева направо, сверху вниз.
            /// </summary>
            public int[] cellNumbers { get; set; }
        }

        /// <summary>
        /// GeeTestTask - капча от geetest.com
        /// </summary>
        public class GeeTestTask
        {
            /// <summary>
            /// Хеш необходимый для отправки формы на целевом сайте
            /// </summary>
            public string challenge { get; set; }
            /// <summary>
            /// Этот хеш тоже необходим
            /// </summary>
            public string validate { get; set; }
            /// <summary>
            /// И еще один хэш. Мы без понятия почему их три штуки.
            /// </summary>
            public string seccode { get; set; }
        }

        /// <summary>
        /// RecaptchaV1Task : старая версия рекапчи, решение через прокси
        /// </summary>
        public class RecaptchaV1Task
        {
            /// <summary>
            /// Хеш который необходимо подставить в форму.
            /// </summary>
            public string recaptchaChallenge { get; set; }
            /// <summary>
            /// Текст капчи
            /// </summary>
            public string recaptchaResponse { get; set; }
        }
        #endregion
    }
}
