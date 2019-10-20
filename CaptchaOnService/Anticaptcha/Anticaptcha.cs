using System.Threading;
using System.Web.Script.Serialization;

namespace Captcha_Service.Anticaptcha
{
    /// <summary>
    /// Класс для работы с сервисом Аnticaptcha.com
    /// </summary>
    public class Anticaptcha
    {
        #region Переменные
        /// <summary>
        /// Ключ от сервиса
        /// </summary>
        public static string Key { get; set; }
        /// <summary>
        /// Десериализация данных. 
        /// Json = true - получать полный ответ от сервера в JsonResult. 
        /// Json = false - получать десериализированные данные в Error - если ошибка и в Result - если верный результат. 
        /// </summary>
        public static bool Json { get; set; }
        /// <summary>
        /// Задержка проверки данных
        /// </summary>
        public static int Sleep { get; set; } = 2000;

        /// <summary>
        /// Получить информацию о загрузке очереди. Существуют следующие очереди:
        /// </summary>
        public enum QueueId
        {
            ImageToTextEng = 1,
            ImageToTextRu = 2,
            Recaptcha_NoCaptcha = 5,
            Recaptcha_Proxyless = 6,
            Funcaptcha = 7,
            Funcaptcha_Proxyless = 10,
        }
        /// <summary>
        /// Типы прокси
        /// </summary>
        public enum ProxyType
        {
            http = 0,
            socks4 = 1,
            socks5 = 2,
        }

        private wAnticaptcha.Query Query = new wAnticaptcha.Query();
        #endregion

        #region Обработка
        /// <summary>
        /// Отправка, обрабока и решение капчи
        /// </summary>
        private string DecisionCaptcha(string queryDowload, int sleep = 3000)
        {
            //Делаем запросс с нашей картинкой
            string check = Query.createTask(queryDowload);
            //Десериализируем данные
            dynamic js = wAnticaptcha.Query.Deserializ(check);

            //Если ответ верный и не было проблем
            if (js["errorId"] == 0)
            {
                //Проверяем ответ
                while (true)
                {
                    //Отправляем запросс на проверку
                    string queryReply = Query.getTaskResult(Key, js["taskId"]);
                    //Парсим ответ
                    dynamic checkRepky = wAnticaptcha.Query.Deserializ(queryReply);
                    //Если капча решена получаем ответ
                    if (checkRepky["errorId"] == 0 && checkRepky["status"] == "ready")
                        return queryReply;
                    //Если возникла ошибка, получаем ошибку
                    else if (checkRepky["errorId"] != 0)
                        return queryReply;
                    Thread.Sleep(sleep);
                }
            }
            //Возвращаем ошибку пользователю
            else
                return check;
        }
        #endregion

        #region Информационный функционал
        /// <summary>
        /// Получить информацию об ошибке
        /// </summary>
        /// <param name="Error">Ошика которая возникла</param>
        /// <returns></returns>
        public static string ErrorInfomation(string error)
        {
            string reply = "";
            switch (error)
            {
                case "ERROR_KEY_DOES_NOT_EXIST": reply = wAnticaptcha.Error.ERROR_KEY_DOES_NOT_EXIST; break;
                case "ERROR_NO_SLOT_AVAILABLE": reply = wAnticaptcha.Error.ERROR_NO_SLOT_AVAILABLE; break;
                case "ERROR_ZERO_CAPTCHA_FILESIZE": reply = wAnticaptcha.Error.ERROR_ZERO_CAPTCHA_FILESIZE; break;
                case "ERROR_TOO_BIG_CAPTCHA_FILESIZE": reply = wAnticaptcha.Error.ERROR_TOO_BIG_CAPTCHA_FILESIZE; break;
                case "ERROR_ZERO_BALANCE": reply = wAnticaptcha.Error.ERROR_ZERO_BALANCE; break;
                case "ERROR_IP_NOT_ALLOWED": reply = wAnticaptcha.Error.ERROR_IP_NOT_ALLOWED; break;
                case "ERROR_CAPTCHA_UNSOLVABLE": reply = wAnticaptcha.Error.ERROR_CAPTCHA_UNSOLVABLE; break;
                case "ERROR_BAD_DUPLICATES": reply = wAnticaptcha.Error.ERROR_BAD_DUPLICATES; break;
                case "ERROR_NO_SUCH_METHOD": reply = wAnticaptcha.Error.ERROR_NO_SUCH_METHOD; break;
                case "ERROR_IMAGE_TYPE_NOT_SUPPORTED": reply = wAnticaptcha.Error.ERROR_IMAGE_TYPE_NOT_SUPPORTED; break;
                case "ERROR_NO_SUCH_CAPCHA_ID": reply = wAnticaptcha.Error.ERROR_NO_SUCH_CAPCHA_ID; break;
                case "ERROR_EMPTY_COMMENT": reply = wAnticaptcha.Error.ERROR_EMPTY_COMMENT; break;
                case "ERROR_IP_BLOCKED": reply = wAnticaptcha.Error.ERROR_IP_BLOCKED; break;
                case "ERROR_TASK_ABSENT": reply = wAnticaptcha.Error.ERROR_TASK_ABSENT; break;
                case "ERROR_TASK_NOT_SUPPORTED": reply = wAnticaptcha.Error.ERROR_TASK_NOT_SUPPORTED; break;
                case "ERROR_INCORRECT_SESSION_DATA": reply = wAnticaptcha.Error.ERROR_INCORRECT_SESSION_DATA; break;
                case "ERROR_PROXY_CONNECT_REFUSED": reply = wAnticaptcha.Error.ERROR_PROXY_CONNECT_REFUSED; break;
                case "ERROR_PROXY_CONNECT_TIMEOUT": reply = wAnticaptcha.Error.ERROR_PROXY_CONNECT_TIMEOUT; break;
                case "ERROR_PROXY_READ_TIMEOUT": reply = wAnticaptcha.Error.ERROR_PROXY_READ_TIMEOUT; break;
                case "ERROR_PROXY_BANNED": reply = wAnticaptcha.Error.ERROR_PROXY_BANNED; break;
                case "ERROR_PROXY_TRANSPARENT": reply = wAnticaptcha.Error.ERROR_PROXY_TRANSPARENT; break;
                case "ERROR_RECAPTCHA_TIMEOUT": reply = wAnticaptcha.Error.ERROR_RECAPTCHA_TIMEOUT; break;
                case "ERROR_RECAPTCHA_INVALID_SITEKEY": reply = wAnticaptcha.Error.ERROR_RECAPTCHA_INVALID_SITEKEY; break;
                case "ERROR_RECAPTCHA_INVALID_DOMAIN": reply = wAnticaptcha.Error.ERROR_RECAPTCHA_INVALID_DOMAIN; break;
                case "ERROR_RECAPTCHA_OLD_BROWSER": reply = wAnticaptcha.Error.ERROR_RECAPTCHA_OLD_BROWSER; break;
                case "ERROR_TOKEN_EXPIRED": reply = wAnticaptcha.Error.ERROR_TOKEN_EXPIRED; break;
                case "ERROR_PROXY_HAS_NO_IMAGE_SUPPORT": reply = wAnticaptcha.Error.ERROR_PROXY_HAS_NO_IMAGE_SUPPORT; break;
                case "ERROR_PROXY_INCOMPATIBLE_HTTP_VERSION": reply = wAnticaptcha.Error.ERROR_PROXY_INCOMPATIBLE_HTTP_VERSION; break;
                case "ERROR_FACTORY_SERVER_API_CONNECTION_FAILED": reply = wAnticaptcha.Error.ERROR_FACTORY_SERVER_API_CONNECTION_FAILED; break;
                case "ERROR_FACTORY_SERVER_BAD_JSON": reply = wAnticaptcha.Error.ERROR_FACTORY_SERVER_BAD_JSON; break;
                case "ERROR_FACTORY_SERVER_ERRORID_MISSING": reply = wAnticaptcha.Error.ERROR_FACTORY_SERVER_ERRORID_MISSING; break;
                case "ERROR_FACTORY_SERVER_ERRORID_NOT_ZERO": reply = wAnticaptcha.Error.ERROR_FACTORY_SERVER_ERRORID_NOT_ZERO; break;
                case "ERROR_FACTORY_MISSING_PROPERTY": reply = wAnticaptcha.Error.ERROR_FACTORY_MISSING_PROPERTY; break;
                case "ERROR_FACTORY_PROPERTY_INCORRECT_FORMAT": reply = wAnticaptcha.Error.ERROR_FACTORY_PROPERTY_INCORRECT_FORMAT; break;
                case "ERROR_FACTORY_ACCESS_DENIED": reply = wAnticaptcha.Error.ERROR_FACTORY_ACCESS_DENIED; break;
                case "ERROR_FACTORY_SERVER_OPERATION_FAILED": reply = wAnticaptcha.Error.ERROR_FACTORY_SERVER_OPERATION_FAILED; break;
                case "ERROR_FACTORY_PLATFORM_OPERATION_FAILED": reply = wAnticaptcha.Error.ERROR_FACTORY_PLATFORM_OPERATION_FAILED; break;
                case "ERROR_FACTORY_PROTOCOL_BROKEN": reply = wAnticaptcha.Error.ERROR_FACTORY_PROTOCOL_BROKEN; break;
                case "ERROR_FACTORY_TASK_NOT_FOUND": reply = wAnticaptcha.Error.ERROR_FACTORY_TASK_NOT_FOUND; break;
                case "ERROR_FACTORY_IS_SANDBOXED": reply = wAnticaptcha.Error.ERROR_FACTORY_IS_SANDBOXED; break;
                case "ERROR_PROXY_NOT_AUTHORISED": reply = wAnticaptcha.Error.ERROR_PROXY_NOT_AUTHORISED; break;
                case "ERROR_FUNCAPTCHA_NOT_ALLOWED": reply = wAnticaptcha.Error.ERROR_FUNCAPTCHA_NOT_ALLOWED; break;
                case "ERROR_INVISIBLE_RECAPTCHA": reply = wAnticaptcha.Error.ERROR_INVISIBLE_RECAPTCHA; break;
                case "ERROR_FAILED_LOADING_WIDGET": reply = wAnticaptcha.Error.ERROR_FAILED_LOADING_WIDGET; break;
            }
            return reply;
        }

        /// <summary>
        /// Узнать баланс пользователя, ключа
        /// </summary>
        public class GetBalance
        {
            /// <summary>
            /// Ключ о котором нужно узнать информацию. Можно не указывать если был указан в class Anticaptcha.Key
            /// </summary>
            public string key { get; set; }
            /// <summary>
            /// В каком виде получать данные
            /// true - вернуть в json
            /// false - вернуть десириализированные данные
            /// </summary>
            public bool json { get; set; }

            /// <summary>
            /// Получать данные об ошибке если json = false
            /// </summary>
            public wAnticaptcha.JsonDes.Error Error { get; set; }
            /// <summary>
            /// Получить баланс ключа
            /// </summary>
            public wAnticaptcha.JsonDes.GetBalance Result { get; set; }
            /// <summary>
            /// Получить данные если Json = true
            /// </summary>
            public string JsonResult { get; set; }

            /// <summary>
            /// Узнать баланс, передать параметры
            /// </summary>
            public GetBalance()
            {
                key = Key;
                json = Json;
            }
            /// <summary>
            /// Получить баланс пользователя
            /// </summary>
            /// <returns></returns>
            public GetBalance Balance()
            {
                string Answer = wAnticaptcha.Query.getBalance(Key);
                JavaScriptSerializer js = new JavaScriptSerializer();
                if (json == false)
                {
                    Error = js.Deserialize<wAnticaptcha.JsonDes.Error>(Answer);
                    Result = js.Deserialize<wAnticaptcha.JsonDes.GetBalance>(Answer);
                }
                else
                    JsonResult = Answer;
                return this;
            }
        }

        /// <summary>
        /// Получить информацию о загрузке очереди
        /// </summary>
        public class GetQueueStats
        {
            #region Данные которые надо передать
            /// <summary>
            /// В каком виде получать данные
            /// true - вернуть в json
            /// false - вернуть десириализированные данные
            /// </summary>
            public bool json { get; set; }
            /// <summary>
            /// Номер очереди. Можно использовать enum queueIdList
            /// </summary>
            public int queueId { get; set; }
            #endregion

            #region Данные которые получаем
            /// <summary>
            /// Получать данные об ошибке если json = false
            /// </summary>
            public wAnticaptcha.JsonDes.Error Error { get; set; }
            /// <summary>
            /// Получить информацию
            /// </summary>
            /// 
            public wAnticaptcha.JsonDes.GetQueueStats Result { get; set; }
            /// <summary>
            /// Получить данные если Json = true
            /// </summary>
            public string JsonResult { get; set; }
            #endregion

            #region Дополнительные переменные
            private wAnticaptcha.Query Query = new wAnticaptcha.Query();
            private Anticaptcha Anticaptcha = new Anticaptcha();
            #endregion

            /// <summary>
            /// Получить информацию о загрузке очереди, передать параметры
            /// </summary>
            public GetQueueStats()
            {
                json = Json;
                queueId = 1;
            }
            /// <summary>
            /// Получить информацию о загрузке очереди
            /// </summary>
            /// <param name="queueId">Номер очереди. Существуют следующие очереди: 1 - стандартная ImageToText, язык английский, 2 - стандартная ImageToText, язык русский, 5 - Recaptcha NoCaptcha, 6 - Recaptcha Proxyless, 7 - Funcaptcha, 10 - Funcaptcha Proxyless</param>
            /// <returns></returns>
            public GetQueueStats GetQueue()
            {
                string Answer = Query.getQueueStats(Key, queueId);
                if (json == false)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Error = js.Deserialize<wAnticaptcha.JsonDes.Error>(Answer);
                    Result = js.Deserialize<wAnticaptcha.JsonDes.GetQueueStats>(Answer);
                }
                else
                    JsonResult = Answer;
                return this;
            }
        }
        #endregion

        #region ImageToTextTask - обычная капча с текстом
        /// <summary>
        /// Решение обычной капчи с текстом
        /// </summary>
        public class ImageToTextTask : wAnticaptcha.JsonSer.ImageToTextTask.Task
        {
            #region Данные которые надо передать
            /// <summary>
            /// В каком виде получать данные
            /// true - вернуть в json
            /// false - вернуть десириализированные данные
            /// </summary>
            public bool json { get; set; }
            /// <summary>
            /// Задержка проверки данных
            /// </summary>
            public int sleep { get; set; }
            #endregion

            #region Данные которые получаем
            /// <summary>
            /// Получать данные об ошибке если json = false
            /// </summary>
            public wAnticaptcha.JsonDes.Error Error { get; set; }
            /// <summary>
            /// Получить результат работе если json = false
            /// </summary>
            public getTask Result { get; set; }

            /// <summary>
            /// Получить данные о решении капчи
            /// </summary>
            public class getTask : wAnticaptcha.JsonDes.getTaskResult
            {
                /// <summary>
                /// Получить данные капчи
                /// </summary>
                public wAnticaptcha.JsonDes.ImageToText solution { get; set; }
            }

            /// <summary>
            /// Получить данные если Json = true
            /// </summary>
            public string JsonResult { get; set; }
            #endregion

            #region Дополнительные переменные
            private wAnticaptcha.Query Query = new wAnticaptcha.Query();
            private Anticaptcha Anticaptcha = new Anticaptcha();
            #endregion

            #region Методы
            /// <summary>
            /// Решение обычной капчи с текстом. Передать параметры
            /// </summary>
            public ImageToTextTask()
            {
                json = Json;
                sleep = Sleep;
                body = null;
                phrase = false;
                _case = false;
                numeric = 0;
                math = false;
                minLength = 0;
                maxLength = 0;
                comment = null;
            }

            /// <summary>
            /// Решить обычную капчу с текстом
            /// </summary>
            /// <returns></returns>
            public ImageToTextTask ImageToText()
            {
                string queryDowload = Query.ImageToTextTask(Key, body, phrase, _case, numeric, math, minLength, maxLength, comment);
                string Answer = Anticaptcha.DecisionCaptcha(queryDowload, sleep);
                if (json == false)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Error = js.Deserialize<wAnticaptcha.JsonDes.Error>(Answer);
                    Result = js.Deserialize<getTask>(Answer);
                }
                else
                    JsonResult = Answer;
                return this;
            }
            #endregion 
        }
        #endregion

        #region NoCaptcha
        /// <summary>
        /// Решить капчу Google с использованием прокси
        /// </summary>
        /// <returns></returns>
        public class NoCaptchaTask : wAnticaptcha.JsonSer.NoCaptchaTask.Task
        {
            #region Данные которые требуется передать
            /// <summary>
            /// В каком виде получать данные
            /// true - вернуть в json
            /// false - вернуть десириализированные данные
            /// </summary>
            public bool json { get; set; }
            /// <summary>
            /// Задержка ожидания запросса
            /// </summary>
            public int sleep { get; set; }
            #endregion

            #region Данные которые получаем
            /// <summary>
            /// Получать данные об ошибке если json = false
            /// </summary>
            public wAnticaptcha.JsonDes.Error Error { get; set; }
            /// <summary>
            /// Получить результат работе если json = false
            /// </summary>
            public getTask Result { get; set; }
            /// <summary>
            /// Получить данные о решении капчи
            /// </summary>
            public class getTask : wAnticaptcha.JsonDes.getTaskResult
            {
                /// <summary>
                /// Получить данные капчи
                /// </summary>
                public wAnticaptcha.JsonDes.NoCaptchaTask solution { get; set; }
            }
            /// <summary>
            /// Получить данные если Json = true
            /// </summary>
            public string JsonResult { get; set; }
            #endregion

            #region Дополнительные переменные
            private wAnticaptcha.Query Query = new wAnticaptcha.Query();
            private Anticaptcha Anticaptcha = new Anticaptcha();
            #endregion


            #region Методы
            /// <summary>
            /// Решить капчу Google с использованием прокси, передать параметры
            /// </summary>
            /// <returns></returns>
            public NoCaptchaTask()
            {
                json = Json;
                sleep = Sleep;
                websiteURL = null;
                websiteKey = null;
                websiteSToken = null;
                proxyType = null;
                proxyAddress = null;
                proxyPort = 8080;
                proxyLogin = null;
                proxyPassword = null;
                userAgent = null;
                cookies = null;
                isInvisible = false;
            }

            /// <summary>
            /// Решить капчу Google с использованием прокси
            /// </summary>
            /// <param name="websiteURL">Адрес страницы на которой решается капча</param>
            /// <param name="websiteKey">Ключ-индентификатор рекапчи на целевой странице.  (data-sitekey="ВОТ_ЭТОТ") </param>
            /// <param name="proxyType">http - обычный http/https прокси. socks4 - socks4 прокси. socks5 - socks5 прокси</param>
            /// <param name="proxyAddress">P адрес прокси ipv4/ipv6. Не допускается: - использование имен хостов. -использование прозрачных прокси(там где можно видеть IP клиента). -использование прокси на локальных машинах</param>
            /// <param name="proxyPort">Порт прокси</param>
            /// <param name="userAgent">User-Agent браузера, используемый в эмуляции. Необходимо использовать подпись современного браузера, иначе Google будет возвращать ошибку, требуя обновить браузер.</param>
            /// <param name="proxyLogin">Логин от прокси-сервера</param>
            /// <param name="proxyPassword">Пароль от прокси-сервера</param>
            /// <param name="sleep">Задержка для обновления данных о решении. Пример 1000мс - 1с</param>
            /// <returns></returns>
            public NoCaptchaTask NoCaptcha()
            {
                //Составляем запросс для json
                string queryDowload = Query.NoCaptchaTask(Key, websiteURL, websiteKey, proxyType, proxyAddress, proxyPort, userAgent,
                    websiteSToken, proxyLogin, proxyPassword, cookies, isInvisible);
                string Verify = Anticaptcha.DecisionCaptcha(queryDowload, sleep);
                if (json == false)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Error = js.Deserialize<wAnticaptcha.JsonDes.Error>(Verify);
                    Result = js.Deserialize<getTask>(Verify);
                }
                else
                    JsonResult = Verify;
                return this;
            }
            #endregion
        }

        /// <summary>
        /// Решить капчу Google без прокси
        /// </summary>
        public class NoCaptchaTaskProxyless : wAnticaptcha.JsonSer.NoCaptchaTaskProxyless.Task
        {
            #region Данные которые требуется передать
            /// <summary>
            /// В каком виде получать данные
            /// true - вернуть в json
            /// false - вернуть десириализированные данные
            /// </summary>
            public bool json { get; set; }
            /// <summary>
            /// Задержка ожидания запросса
            /// </summary>
            public int sleep { get; set; }
            #endregion

            #region Данные которые получаем
            /// <summary>
            /// Получать данные об ошибке если json = false
            /// </summary>
            public wAnticaptcha.JsonDes.Error Error { get; set; }
            /// <summary>
            /// Получить результат работе если json = false
            /// </summary>
            public getTask Result { get; set; }
            /// <summary>
            /// Получить данные о решении капчи
            /// </summary>
            public class getTask : wAnticaptcha.JsonDes.getTaskResult
            {
                /// <summary>
                /// Получить данные капчи
                /// </summary>
                public wAnticaptcha.JsonDes.NoCaptchaTask solution { get; set; }
            }
            /// <summary>
            /// Получить данные если Json = true
            /// </summary>
            public string JsonResult { get; set; }
            #endregion

            #region Дополнительные переменные
            private wAnticaptcha.Query Query = new wAnticaptcha.Query();
            private Anticaptcha Anticaptcha = new Anticaptcha();
            #endregion

            #region Методы
            /// <summary>
            /// Решить капчу Google без прокси, передать параметры
            /// </summary>
            public NoCaptchaTaskProxyless()
            {
                json = Json;
                sleep = Sleep;
                websiteURL = null;
                websiteKey = null;
                websiteSToken = null;
                isInvisible = false;
            }
            /// <summary>
            /// Решить капчу Google без прокси
            /// </summary>
            public NoCaptchaTaskProxyless NoCaptcha()
            {
                //Составляем запросс для json
                string queryDowload = Query.NoCaptchaTaskProxyless(Key, websiteURL, websiteKey, websiteSToken, isInvisible);
                string Verify = Anticaptcha.DecisionCaptcha(queryDowload, sleep);
                if (json == false)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Error = js.Deserialize<wAnticaptcha.JsonDes.Error>(Verify);
                    Result = js.Deserialize<getTask>(Verify);
                }
                else
                    JsonResult = Verify;
                return this;
            }
            #endregion
        }
        #endregion

        #region FunCaptcha
        /// <summary>
        /// FunCaptchaTask - крутящаяся капча funcaptcha.com
        /// </summary>
        public class FunCaptchaTask : wAnticaptcha.JsonSer.FunCaptchaTask.Task
        {
            #region Данные которые надо передать
            /// <summary>
            /// В каком виде получать данные
            /// true - вернуть в json
            /// false - вернуть десириализированные данные
            /// </summary>
            public bool json { get; set; }
            /// <summary>
            /// Задержка ожидания запросса
            /// </summary>
            public int sleep { get; set; }
            #endregion

            #region Данные которые получаем
            /// <summary>
            /// Получать данные об ошибке если json = false
            /// </summary>
            public wAnticaptcha.JsonDes.Error Error { get; set; }
            /// <summary>
            /// Получить результат работе если json = false
            /// </summary>
            public getTask Result { get; set; }
            /// <summary>
            /// Получить данные о решении капчи
            /// </summary>
            public class getTask : wAnticaptcha.JsonDes.getTaskResult
            {
                /// <summary>
                /// Получить данные капчи
                /// </summary>
                public wAnticaptcha.JsonDes.FunCaptcha solution { get; set; }
            }
            /// <summary>
            /// Получить данные если Json = true
            /// </summary>
            public string JsonResult { get; set; }
            #endregion

            #region Дополнительные переменные
            private wAnticaptcha.Query Query = new wAnticaptcha.Query();
            private Anticaptcha Anticaptcha = new Anticaptcha();
            #endregion

            #region Методы
            /// <summary>
            /// Решить funcaptcha без прокси, передать параметры
            /// </summary>
            public FunCaptchaTask()
            {
                json = Json;
                sleep = Sleep;
                websiteURL = null;
                funcaptchaApiJSSubdomain = null;
                websitePublicKey = null;
                proxyType = null;
                proxyAddress = null;
                proxyPort = 0;
                proxyLogin = null;
                proxyPassword = null;
                userAgent = null;
                cookies = null;
            }

            /// <summary>
            /// Решить funcaptcha без прокси
            /// </summary>
            public FunCaptchaTask FunCaptcha()
            {
                string queryDowload = Query.FunCaptchaTask(Key, websiteURL, websitePublicKey, proxyType, proxyAddress,
                    proxyPort, userAgent, funcaptchaApiJSSubdomain, proxyLogin, proxyPassword, cookies);
                string Verify = Anticaptcha.DecisionCaptcha(queryDowload, sleep);
                if (json == false)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Error = js.Deserialize<wAnticaptcha.JsonDes.Error>(Verify);
                    Result = js.Deserialize<getTask>(Verify);
                }
                else
                    JsonResult = Verify;
                return this;
            }
            #endregion
        }

        /// <summary>
        /// FunCaptchaTaskProxyless - funcaptcha без прокси
        /// </summary>
        public class FunCaptchaTaskProxyless : wAnticaptcha.JsonSer.FunCaptchaTaskProxyless.Task
        {
            #region Данные которые надо передать
            /// <summary>
            /// В каком виде получать данные
            /// true - вернуть в json
            /// false - вернуть десириализированные данные
            /// </summary>
            public bool json { get; set; }
            /// <summary>
            /// Задержка ожидания запросса
            /// </summary>
            public int sleep { get; set; }
            #endregion

            #region Данные которые получаем
            /// <summary>
            /// Получать данные об ошибке если json = false
            /// </summary>
            public wAnticaptcha.JsonDes.Error Error { get; set; }
            /// <summary>
            /// Получить результат работе если json = false
            /// </summary>
            public getTask Result { get; set; }
            /// <summary>
            /// Получить данные о решении капчи
            /// </summary>
            public class getTask : wAnticaptcha.JsonDes.getTaskResult
            {
                /// <summary>
                /// Получить данные капчи
                /// </summary>
                public wAnticaptcha.JsonDes.FunCaptcha solution { get; set; }
            }
            /// <summary>
            /// Получить данные если Json = true
            /// </summary>
            public string JsonResult { get; set; }
            #endregion

            #region Дополнительные переменные
            private wAnticaptcha.Query Query = new wAnticaptcha.Query();
            private Anticaptcha Anticaptcha = new Anticaptcha();
            #endregion

            #region Методы
            /// <summary>
            /// Решить funcaptcha без прокси, передать параметры
            /// </summary>
            public FunCaptchaTaskProxyless()
            {
                json = Json;
                sleep = Sleep;
                websiteURL = null;
                funcaptchaApiJSSubdomain = null;
                websitePublicKey = null;
            }
            /// <summary>
            /// Решить funcaptcha без прокси
            /// </summary>
            public FunCaptchaTaskProxyless FunCaptcha()
            {
                string queryDowload = Query.FunCaptchaTaskProxyless(Key, websiteURL, websitePublicKey, funcaptchaApiJSSubdomain);
                string Verify = Anticaptcha.DecisionCaptcha(queryDowload, sleep);
                if (json == false)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Error = js.Deserialize<wAnticaptcha.JsonDes.Error>(Verify);
                    Result = js.Deserialize<getTask>(Verify);
                }
                else
                    JsonResult = Verify;
                return this;
            }
            #endregion
        }
        #endregion

        #region SquareNetText
        /// <summary>
        /// Решить капчу где нужно выбрать нужный объект на картинке с сеткой изображений
        /// </summary>
        /// <returns></returns>
        public class SquareNetText : wAnticaptcha.JsonSer.SquareNetTextTask.Task
        {
            #region Данные которые надо передать
            /// <summary>
            /// В каком виде получать данные
            /// true - вернуть в json
            /// false - вернуть десириализированные данные
            /// </summary>
            public bool json { get; set; }
            /// <summary>
            /// Задержка ожидания запросса
            /// </summary>
            public int sleep { get; set; }
            #endregion

            #region Данные которые получаем
            /// <summary>
            /// Получать данные об ошибке если json = false
            /// </summary>
            public wAnticaptcha.JsonDes.Error Error { get; set; }
            /// <summary>
            /// Получить результат работе если json = false
            /// </summary>
            public getTask Result { get; set; }
            /// <summary>
            /// Получить данные о решении капчи
            /// </summary>
            public class getTask : wAnticaptcha.JsonDes.getTaskResult
            {
                /// <summary>
                /// Получить данные капчи
                /// </summary>
                public wAnticaptcha.JsonDes.SquareNetTextTask solution { get; set; }
            }
            /// <summary>
            /// Получить данные если Json = true
            /// </summary>
            public string JsonResult { get; set; }
            #endregion

            #region Дополнительные переменные
            private wAnticaptcha.Query Query = new wAnticaptcha.Query();
            private Anticaptcha Anticaptcha = new Anticaptcha();
            #endregion

            #region Методы
            /// <summary>
            /// Решить капчу где нужно выбрать нужный объект на картинке с сеткой изображений, передать параметры
            /// </summary>
            /// <returns></returns>
            public SquareNetText()
            {
                json = Json;
                sleep = Sleep;
                body = null;
                objectName = null;
                rowsCount = 0;
                columnsCount = 0;
            }

            /// <summary>
            /// Решить капчу где нужно выбрать нужный объект на картинке с сеткой изображений
            /// </summary>
            /// <returns></returns>
            public SquareNetText SquareNet()
            {
                //Составляем запросс для json
                string queryDowload = Query.SquareNetTextTask(Key, body, objectName, rowsCount, columnsCount);
                string Verify = Anticaptcha.DecisionCaptcha(queryDowload, sleep);
                if (json == false)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Error = js.Deserialize<wAnticaptcha.JsonDes.Error>(Verify);
                    Result = js.Deserialize<getTask>(Verify);
                }
                else
                    JsonResult = Verify;
                return this;
            }
            #endregion
        }
        #endregion

        #region GeeTestTask
        /// <summary>
        /// Решить капчу от geetest.com с использованием прокси
        /// </summary>
        /// <returns></returns>
        public class GeeTestTask: wAnticaptcha.JsonSer.GeeTestTask.Task
        {
            #region Данные которые надо передать
            /// <summary>
            /// В каком виде получать данные
            /// true - вернуть в json
            /// false - вернуть десириализированные данные
            /// </summary>
            public bool json { get; set; }
            /// <summary>
            /// Задержка ожидания запросса
            /// </summary>
            public int sleep { get; set; }
            #endregion

            #region Данные которые получаем
            /// <summary>
            /// Получать данные об ошибке если json = false
            /// </summary>
            public wAnticaptcha.JsonDes.Error Error { get; set; }
            /// <summary>
            /// Получить результат работе если json = false
            /// </summary>
            public getTask Result { get; set; }
            /// <summary>
            /// Получить данные о решении капчи
            /// </summary>
            public class getTask : wAnticaptcha.JsonDes.getTaskResult
            {
                /// <summary>
                /// Получить данные капчи
                /// </summary>
                public wAnticaptcha.JsonDes.GeeTestTask solution { get; set; }
            }
            /// <summary>
            /// Получить данные если Json = true
            /// </summary>
            public string JsonResult { get; set; }
            #endregion

            #region Дополнительные переменные
            private wAnticaptcha.Query Query = new wAnticaptcha.Query();
            private Anticaptcha Anticaptcha = new Anticaptcha();
            #endregion

            #region Методы
            /// <summary>
            /// Капча от geetest.com, передать параметры
            /// </summary>
            public GeeTestTask()
            {
                json = Json;
                sleep = Sleep;
                websiteURL = null;
                gt = null;
                challenge = null;
                geetestApiServerSubdomain = null;
                proxyType = null;
                proxyAddress = null;
                proxyPort = 0;
                proxyLogin = null;
                proxyPassword = null;
                userAgent = null;
                cookies = null;
            }

            /// <summary>
            /// Решить капчу от geetest.com с использованием прокси
            /// </summary>
            /// <param name="websiteURL">Адрес страницы на которой решается капча</param>
            /// <param name="gt">Ключ-индентификатор капчи на целевой странице. </param>
            /// <param name="challenge">Переменный токен который необходимо обновлять каждый раз перед созданием задачи.</param>
            /// <param name="proxyType">http - обычный http/https прокси. socks4 - socks4 прокси. socks5 - socks5 прокси</param>
            /// <param name="proxyAddress">P адрес прокси ipv4/ipv6. Не допускается: - использование имен хостов. -использование прозрачных прокси(там где можно видеть IP клиента). -использование прокси на локальных машинах</param>
            /// <param name="proxyPort">Порт прокси</param>
            /// <param name="userAgent">User-Agent браузера, используемый в эмуляции. Необходимо использовать подпись современного браузера, иначе Google будет возвращать ошибку, требуя обновить браузер.</param>
            /// <param name="proxyLogin">Логин от прокси-сервера</param>
            /// <param name="proxyPassword">Пароль от прокси-сервера</param>
            /// <param name="sleep">Задержка для обновления данных о решении. Пример 1000мс - 1с</param>
            /// <returns></returns>
            public GeeTestTask GeeTest()
            {
                string queryDowload = Query.GeeTestTask(Key, websiteURL, gt, challenge,proxyType,proxyAddress, proxyPort, userAgent,
                    geetestApiServerSubdomain, proxyLogin, proxyPassword, cookies);
                string Verify = Anticaptcha.DecisionCaptcha(queryDowload, sleep);
                if (json == false)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Error = js.Deserialize<wAnticaptcha.JsonDes.Error>(Verify);
                    Result = js.Deserialize<getTask>(Verify);
                }
                else
                    JsonResult = Verify;
                return this;
            }
            #endregion
        }

        /// <summary>
        /// GeeTestTaskProxyless - капча от geetest.com без прокси
        /// </summary>
        public class GeeTestTaskProxyless : wAnticaptcha.JsonSer.GeeTestTaskProxyless.Task
        {
            #region Данные которые надо передать
            /// <summary>
            /// В каком виде получать данные
            /// true - вернуть в json
            /// false - вернуть десириализированные данные
            /// </summary>
            public bool json { get; set; }
            /// <summary>
            /// Задержка ожидания запросса
            /// </summary>
            public int sleep { get; set; }
            #endregion

            #region Данные которые получаем
            /// <summary>
            /// Получать данные об ошибке если json = false
            /// </summary>
            public wAnticaptcha.JsonDes.Error Error { get; set; }
            /// <summary>
            /// Получить результат работе если json = false
            /// </summary>
            public getTask Result { get; set; }
            /// <summary>
            /// Получить данные о решении капчи
            /// </summary>
            public class getTask : wAnticaptcha.JsonDes.getTaskResult
            {
                /// <summary>
                /// Получить данные капчи
                /// </summary>
                public wAnticaptcha.JsonDes.GeeTestTask solution { get; set; }
            }
            /// <summary>
            /// Получить данные если Json = true
            /// </summary>
            public string JsonResult { get; set; }
            #endregion

            #region Дополнительные переменные
            private wAnticaptcha.Query Query = new wAnticaptcha.Query();
            private Anticaptcha Anticaptcha = new Anticaptcha();
            #endregion

            #region Методы
            /// <summary>
            /// Капча от geetest.com, передать параметры
            /// </summary>
            public GeeTestTaskProxyless()
            {
                json = Json;
                sleep = Sleep;
                websiteURL = null;
                gt = null;
                challenge = null;
                geetestApiServerSubdomain = null;
            }

            /// <summary>
            /// Решить капчу от geetest.com без прокси
            /// </summary>
            /// <param name="websiteURL">Адрес страницы на которой решается капча</param>
            /// <param name="gt">Ключ-индентификатор капчи на целевой странице. </param>
            /// <param name="challenge">Переменный токен который необходимо обновлять каждый раз перед созданием задачи.</param>
            /// <param name="sleep">Задержка для обновления данных о решении. Пример 1000мс - 1с</param>
            /// <returns></returns>
            public GeeTestTaskProxyless GeeTest()
            {
                //Составляем запросс для json
                string queryDowload = Query.GeeTestTaskProxyless(Key, websiteURL, gt, challenge, geetestApiServerSubdomain);
                string Verify = Anticaptcha.DecisionCaptcha(queryDowload, sleep);
                if (json == false)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Error = js.Deserialize<wAnticaptcha.JsonDes.Error>(Verify);
                    Result = js.Deserialize<getTask>(Verify);
                }
                else
                    JsonResult = Verify;
                return this;
            }
            #endregion
        }
        #endregion

        #region RecaptchaV1
        /// <summary>
        /// RecaptchaV1Task : старая версия рекапчи, решение через прокси
        /// </summary>
        public class RecaptchaV1Task: wAnticaptcha.JsonSer.RecaptchaV1Task.Task
        {
            #region Данные которые надо передать
            /// <summary>
            /// В каком виде получать данные
            /// true - вернуть в json
            /// false - вернуть десириализированные данные
            /// </summary>
            public bool json { get; set; }
            /// <summary>
            /// Задержка ожидания запросса
            /// </summary>
            public int sleep { get; set; }
            #endregion

            #region Данные которые получаем
            /// <summary>
            /// Получать данные об ошибке если json = false
            /// </summary>
            public wAnticaptcha.JsonDes.Error Error { get; set; }
            /// <summary>
            /// Получить результат работе если json = false
            /// </summary>
            public getTask Result { get; set; }
            /// <summary>
            /// Получить данные о решении капчи
            /// </summary>
            public class getTask : wAnticaptcha.JsonDes.getTaskResult
            {
                /// <summary>
                /// Получить данные капчи
                /// </summary>
                public wAnticaptcha.JsonDes.RecaptchaV1Task solution { get; set; }
            }
            /// <summary>
            /// Получить данные если Json = true
            /// </summary>
            public string JsonResult { get; set; }
            #endregion

            #region Дополнительные переменные
            private wAnticaptcha.Query Query = new wAnticaptcha.Query();
            private Anticaptcha Anticaptcha = new Anticaptcha();
            #endregion

            #region Методы
            /// <summary>
            /// RecaptchaV1Task : старая версия рекапчи, передать параметры
            /// </summary>
            public RecaptchaV1Task()
            {
                json = Json;
                sleep = Sleep;
                websiteURL = null;
                websiteKey = null;
                proxyType = null;
                proxyAddress = null;
                proxyLogin = null;
                proxyPassword = null;
                userAgent = null;
                cookies = null;
            }

            /// <summary>
            /// Решить старую версия рекапчи с использованием прокси
            /// </summary>
            /// <param name="websiteURL">Адрес страницы на которой решается капча</param>
            /// <param name="websiteKey">Ключ-индентификатор рекапчи на целевой странице.  (data-sitekey="ВОТ_ЭТОТ") </param>
            /// <param name="proxyType">http - обычный http/https прокси. socks4 - socks4 прокси. socks5 - socks5 прокси</param>
            /// <param name="proxyAddress">P адрес прокси ipv4/ipv6. Не допускается: - использование имен хостов. -использование прозрачных прокси(там где можно видеть IP клиента). -использование прокси на локальных машинах</param>
            /// <param name="proxyPort">Порт прокси</param>
            /// <param name="userAgent">User-Agent браузера, используемый в эмуляции. Необходимо использовать подпись современного браузера, иначе Google будет возвращать ошибку, требуя обновить браузер.</param>
            /// <param name="proxyLogin">Логин от прокси-сервера</param>
            /// <param name="proxyPassword">Пароль от прокси-сервера</param>
            /// <param name="sleep">Задержка для обновления данных о решении. Пример 1000мс - 1с</param>
            /// <returns></returns>
            public RecaptchaV1Task RecaptchaV1(string websiteURL, string websiteKey, string proxyType, string proxyAddress, int proxyPort, string userAgent,
                string proxyLogin, string proxyPassword, int sleep)
            {
                //Составляем запросс для json
                string queryDowload = Query.RecaptchaV1Task(Key, websiteURL, websiteKey, proxyType, proxyAddress, proxyPort, userAgent,
                    proxyLogin, proxyPassword, cookies);
                string Verify = Anticaptcha.DecisionCaptcha(queryDowload, sleep);
                if (json == false)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Error = js.Deserialize<wAnticaptcha.JsonDes.Error>(Verify);
                    Result = js.Deserialize<getTask>(Verify);
                }
                else
                    JsonResult = Verify;
                return this;
            }
            #endregion
        }

        /// <summary>
        /// RecaptchaV1TaskProxyless : решение старой рекапчи без прокси
        /// </summary>
        public class RecaptchaV1TaskProxyless : wAnticaptcha.JsonSer.RecaptchaV1TaskProxyless.Task
        {
            #region Данные которые надо передать
            /// <summary>
            /// В каком виде получать данные
            /// true - вернуть в json
            /// false - вернуть десириализированные данные
            /// </summary>
            public bool json { get; set; }
            /// <summary>
            /// Задержка ожидания запросса
            /// </summary>
            public int sleep { get; set; }
            #endregion

            #region Данные которые получаем
            /// <summary>
            /// Получать данные об ошибке если json = false
            /// </summary>
            public wAnticaptcha.JsonDes.Error Error { get; set; }
            /// <summary>
            /// Получить результат работе если json = false
            /// </summary>
            public getTask Result { get; set; }
            /// <summary>
            /// Получить данные о решении капчи
            /// </summary>
            public class getTask : wAnticaptcha.JsonDes.getTaskResult
            {
                /// <summary>
                /// Получить данные капчи
                /// </summary>
                public wAnticaptcha.JsonDes.RecaptchaV1Task solution { get; set; }
            }
            /// <summary>
            /// Получить данные если Json = true
            /// </summary>
            public string JsonResult { get; set; }
            #endregion

            #region Дополнительные переменные
            private wAnticaptcha.Query Query = new wAnticaptcha.Query();
            private Anticaptcha Anticaptcha = new Anticaptcha();
            #endregion

            #region Методы
            /// <summary>
            /// RecaptchaV1Task : старая версия рекапчи без прокси, передать параметры
            /// </summary>
            public RecaptchaV1TaskProxyless()
            {
                json = Json;
                sleep = Sleep;
                websiteURL = null;
                websiteKey = null;
            }

            /// <summary>
            /// Решить старую версия рекапчи без прокси
            /// </summary>
            /// <param name="websiteURL">Адрес страницы на которой решается капча</param>
            /// <param name="websiteKey">Ключ-индентификатор рекапчи на целевой странице.  (data-sitekey="ВОТ_ЭТОТ") </param>
            /// <param name="sleep">Задержка для обновления данных о решении. Пример 1000мс - 1с</param>
            /// <returns></returns>
            public RecaptchaV1TaskProxyless RecaptchaV1(string websiteURL, string websiteKey, int sleep)
            {
                //Составляем запросс для json
                string queryDowload = Query.RecaptchaV1TaskProxyless(Key, websiteURL, websiteKey);
                string Verify =  Anticaptcha.DecisionCaptcha(queryDowload, sleep);
                if (json == false)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Error = js.Deserialize<wAnticaptcha.JsonDes.Error>(Verify);
                    Result = js.Deserialize<getTask>(Verify);
                }
                else
                    JsonResult = Verify;
                return this;
            }
            #endregion
        }
        #endregion
    }
}