using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace Captcha_Service.Anticaptcha.wAnticaptcha
{
    partial class Query
    {
        private static string softId = null;

        #region Работа данных
        /// <summary>
        /// Сериализирует данные с класса в строку типа string 
        /// </summary>
        /// <param name="Serial">Что нужно привести в нормальный вид</param>
        /// <returns></returns>
        private static string serializer(object Serial)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(Serial);
        }

        /// <summary>
        /// Десериализирует данные с json в строку
        /// </summary>
        /// <returns></returns>
        public static dynamic Deserializ(string Deserial)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            /*
                BlogSites blogObject = js.Deserialize<BlogSites>(jsonData);
                string name = blogObject.Name;
                string description = blogObject.Description;
                */
            // Other way to whithout help of BlogSites class  

            dynamic jsonObject = js.Deserialize<dynamic>(Deserial);
            /*
             string name = blogObject["Name"];  
             string description = blogObject["Description"];  
            */
            return jsonObject;
        }
        #endregion

        #region Информационные данные
        /// <summary>
        /// Узнать баланс пользовалея
        /// </summary>
        /// <param name="key">Ключ от сервиса</param>
        /// <returns></returns>
        public static string getBalance(string key)
        {
            string DowloadInf = "";
            string url = "https://api.anti-captcha.com/getBalance?";
            using (var webClient = new WebClient())
            {
                JsonSer.balance getKey = new JsonSer.balance() { clientKey = key };
                string data = serializer(getKey);

                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;

                using (Stream dataStream = request.GetRequestStream())
                    dataStream.Write(byteArray, 0, byteArray.Length);

                WebResponse response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                    DowloadInf = reader.ReadToEnd();
            }
            return DowloadInf;
        }

        /// <summary>
        /// Получить информацию о загрузке очереди
        /// </summary>
        /// <param name="key">Ключ от сервиса</param>
        /// <returns></returns>
        public string getQueueStats(string key, int queueId)
        {
            string DowloadInf = "";
            string url = "https://api.anti-captcha.com/getQueueStats?";
            using (var webClient = new WebClient())
            {
                JsonSer.getQueueStats getQueueStats = new JsonSer.getQueueStats() { queueId = queueId };
                string data = serializer(getQueueStats);

                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;

                using (Stream dataStream = request.GetRequestStream())
                    dataStream.Write(byteArray, 0, byteArray.Length);

                WebResponse response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                    DowloadInf = reader.ReadToEnd();
            }
            return DowloadInf;
        }

        /// <summary>
        /// Получить результат задачи
        /// </summary>
        /// <param name="clientKey">Ключ от учетной записи, найти его можно здесь</param>
        /// <param name="taskId">Идентификатор задания полученный в методе createTask</param>
        /// <returns></returns>
        public string getTaskResult(string clientKey, int taskId)
        {
            string DowloadInf = "";
            string url = "https://api.anti-captcha.com/getTaskResult?";
            using (var webClient = new WebClient())
            {
                JsonSer.getTaskResult getTaskResult = new JsonSer.getTaskResult() { clientKey = clientKey, taskId = taskId };
                string data = serializer(getTaskResult);

                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;

                using (Stream dataStream = request.GetRequestStream())
                    dataStream.Write(byteArray, 0, byteArray.Length);

                WebResponse response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                    DowloadInf = reader.ReadToEnd();
            }
            return DowloadInf;

        }

        /// <summary>
        /// Составить задание и отправить запросс
        /// </summary>
        /// <param name="jsonPost">Запросс который отправляем на сервис</param>
        /// <returns></returns>
        public string createTask(string jsonPost)
        {
            string DowloadInf = "";
            string url = "https://api.anti-captcha.com/createTask?";
            using (var webClient = new WebClient())
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(jsonPost);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;

                using (Stream dataStream = request.GetRequestStream())
                    dataStream.Write(byteArray, 0, byteArray.Length);

                WebResponse response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                    DowloadInf = reader.ReadToEnd();
            }
            return DowloadInf;
        }
        #endregion

        #region ImageToTextTask : решение обычной капчи с текстом
        /// <summary>
        /// Составить запрос для Решение обычной капчи с текстом
        /// </summary>
        /// <returns></returns>
        public string ImageToTextTask(string clientKey, 
            string ImapePath,
            bool phrase = false,
            bool _case = false,
            int numeric = 0,
            bool math = false,
            int minLength = 0,
            int maxLength = 0,
            string comment = null)
        {
            var query = new JsonSer.ImageToTextTask()
            {
                clientKey = clientKey,
                softId = softId,
                task = new JsonSer.ImageToTextTask.Task
                {
                    type = "ImageToTextTask",
                    body = Addition.Base64ToString(ImapePath),
                    phrase = phrase,
                    _case = _case,
                    numeric = numeric,
                    math = math,
                    minLength = minLength,
                    maxLength = maxLength,
                    comment = comment,
                },
            };
            string data = serializer(query).Replace("_case", "case");
            return data;
        }
        #endregion

        #region NoCaptchaTaskProxyless : решение капчи Google
        /// <summary>
        /// Составить запрос для решение капчи Google
        /// </summary>
        /// <returns></returns>
        public string NoCaptchaTask(string clientKey, 
            string websiteURL, 
            string websiteKey, 
            string proxyType, 
            string proxyAddress, 
            int proxyPort, 
            string userAgent,
            string websiteSToken = null,
            string proxyLogin = null, 
            string proxyPassword = null,
            string cookie = null,
            bool isInvisible = false)
        {
            var query = new JsonSer.NoCaptchaTask()
            {
                clientKey = clientKey,
                softId = softId,
                task = new JsonSer.NoCaptchaTask.Task
                {

                    type = "NoCaptchaTask",
                    websiteURL = websiteURL,
                    websiteKey = websiteKey,
                    proxyType = proxyType,
                    proxyAddress = proxyAddress,
                    proxyPort = proxyPort,
                    userAgent = userAgent,

                    websiteSToken = websiteSToken,
                    proxyLogin = proxyLogin,
                    proxyPassword = proxyPassword,
                    cookies = cookie,
                    isInvisible = isInvisible,
                },
            };
            string data = serializer(query);
            return data;
        }

        /// <summary>
        /// Составить запрос для Решение капчи Google без прокси
        /// </summary>
        /// <returns></returns>
        public string NoCaptchaTaskProxyless(string clientKey, 
            string websiteURL, 
            string websiteKey, 
            string websiteSToken = null, 
            bool isInvisible = false)
        {
            var query = new JsonSer.NoCaptchaTaskProxyless()
            {
                clientKey = clientKey,
                softId = softId,
                task = new JsonSer.NoCaptchaTaskProxyless.Task
                {
                    type = "NoCaptchaTaskProxyless",
                    websiteURL = websiteURL,
                    websiteKey = websiteKey,
                    websiteSToken = websiteSToken,

                    isInvisible = isInvisible,
                },
            };
            string data = serializer(query);
            return data;
        }
        #endregion

        #region FunCaptchaTask - крутящаяся капча funcaptcha.com
        /// <summary>
        /// Составить запрос для решение, крутящаяся капча funcaptcha.com
        /// </summary>
        /// <param name="clientKey">Ключ от сервиса</param>
        /// <param name="websiteURL">Адрес страницы на которой решается капча</param>
        /// <param name="websiteKey">Ключ-индентификатор рекапчи на целевой странице.</param>
        /// <param name="proxyType">http - обычный http/https прокси. socks4 - socks4 прокси. socks5 - socks5 прокси</param>
        /// <param name="proxyAddress">P адрес прокси ipv4/ipv6. Не допускается: - использование имен хостов. -использование прозрачных прокси(там где можно видеть IP клиента). -использование прокси на локальных машинах</param>
        /// <param name="proxyPort">Порт прокси</param>
        /// <param name="userAgent">User-Agent браузера, используемый в эмуляции. Необходимо использовать подпись современного браузера, иначе Google будет возвращать ошибку, требуя обновить браузер.</param>
        /// <param name="proxyLogin">Логин от прокси-сервера</param>
        /// <param name="proxyPassword">Пароль от прокси-сервера</param>
        /// <returns></returns>
        public string FunCaptchaTask(string clientKey, 
            string websiteURL, 
            string websitePublicKey, 
            string proxyType, 
            string proxyAddress, 
            int proxyPort, 
            string userAgent,
            string funcaptchaApiJSSubdomain = null, 
            string proxyLogin = null, 
            string proxyPassword = null,
            string cookie = null)
        {
            var query = new JsonSer.FunCaptchaTask()
            {
                clientKey = clientKey,
                softId = softId,
                task = new JsonSer.FunCaptchaTask.Task
                {
                    type = "FunCaptchaTask",
                    websiteURL = websiteURL,
                    websitePublicKey = websitePublicKey,
                    proxyType = proxyType,
                    proxyAddress = proxyAddress,
                    proxyPort = proxyPort,
                    userAgent = userAgent,

                    funcaptchaApiJSSubdomain = funcaptchaApiJSSubdomain,
                    proxyLogin = proxyLogin,
                    proxyPassword = proxyPassword,
                    cookies = cookie,
                },
            };
            string data = serializer(query);
            return data;
        }

        /// <summary>
        /// Составить запрос для решение, крутящаяся капча funcaptcha.com
        /// </summary>
        /// <param name="clientKey">Ключ от сервиса</param>
        /// <param name="websiteURL">Адрес страницы на которой решается капча</param>
        /// <param name="websiteKey">Ключ-индентификатор рекапчи на целевой странице.</param>
        /// <returns></returns>
        public string FunCaptchaTaskProxyless(string clientKey, 
            string websiteURL, 
            string websiteKey, 
            string funcaptchaApiJSSubdomain = null)
        {
            var query = new JsonSer.FunCaptchaTaskProxyless()
            {
                clientKey = clientKey,
                softId = softId,
                task = new JsonSer.FunCaptchaTaskProxyless.Task
                {
                    type = "FunCaptchaTaskProxyless ",
                    websiteURL = websiteURL,
                    funcaptchaApiJSSubdomain = funcaptchaApiJSSubdomain,
                    websitePublicKey = websiteKey,
                },
            };
            string data = serializer(query);
            return data;
        }
        #endregion

        #region SquareNetTextTask : выбрать нужный объект на картинке с сеткой изображений
        /// <summary>
        /// Составить запрос для того где нужно выбрать нужный объект на картинке с сеткой изображений
        /// </summary>
        /// <returns></returns>
        public string SquareNetTextTask(string clientKey, 
            string body, 
            string objectName, 
            int rowsCount, 
            int columnsCount)
        {
            var query = new JsonSer.SquareNetTextTask()
            {
                clientKey = clientKey,
                softId = softId,
                task = new JsonSer.SquareNetTextTask.Task
                {
                    type = "SquareNetTextTask",
                    body = Addition.Base64ToString(body),
                    objectName = objectName,
                    rowsCount = rowsCount,
                    columnsCount = columnsCount,
                },
            };
            string data = serializer(query);
            return data;
        }
        #endregion

        #region GeeTestTask - капча от geetest.com

        /// <summary>
        /// Составить запрос для решение, капчи от geetest.com
        /// </summary>
        /// <returns></returns>
        public string GeeTestTask(string clientKey, 
            string websiteURL, 
            string gt, 
            string challenge, 
            string proxyType, 
            string proxyAddress, 
            int proxyPort, 
            string userAgent,
            string geetestApiServerSubdomain = null,
            string proxyLogin = null, 
            string proxyPassword = null,
            string cookie = null)
        {
            var query = new JsonSer.GeeTestTask()
            {
                clientKey = clientKey,
                softId = softId,
                task = new JsonSer.GeeTestTask.Task
                {
                    type = "GeeTestTask",
                    websiteURL = websiteURL,
                    gt = gt,
                    challenge = challenge,
                    proxyType = proxyType,
                    proxyAddress = proxyAddress,
                    proxyPort = proxyPort,
                    userAgent = userAgent,

                    geetestApiServerSubdomain = geetestApiServerSubdomain,
                    proxyLogin = proxyLogin,
                    proxyPassword = proxyPassword,
                    cookies = cookie,
                },
            };
            string data = serializer(query);
            return data;
        }

        /// <summary>
        /// Составить запрос для решение, капчи от geetest.com, без прокси
        /// </summary>
        public string GeeTestTaskProxyless(string clientKey, 
            string websiteURL, 
            string gt, 
            string challenge,
            string geetestApiServerSubdomain = null)
        {
            var query = new JsonSer.GeeTestTaskProxyless()
            {
                clientKey = clientKey,
                softId = softId,
                task = new JsonSer.GeeTestTaskProxyless.Task
                {
                    type = "GeeTestTaskProxyless",
                    websiteURL = websiteURL,
                    gt = gt,
                    challenge = challenge,
                    geetestApiServerSubdomain = geetestApiServerSubdomain,
                },
            };
            string data = serializer(query);
            return data;
        }

        #endregion

        #region RecaptchaV1TaskProxyless : решение старой рекапчи
        /// <summary>
        /// Составить запрос для решение старай версия рекапчи, решение через прокси
        /// </summary>
        /// <returns></returns>
        public string RecaptchaV1Task(string clientKey, 
            string websiteURL, 
            string websiteKey, 
            string proxyType, 
            string proxyAddress, 
            int proxyPort, 
            string userAgent,
            string proxyLogin = null, 
            string proxyPassword = null, 
            string cookie = null)
        {
            var query = new JsonSer.RecaptchaV1Task()
            {
                clientKey = clientKey,
                softId = softId,
                task = new JsonSer.RecaptchaV1Task.Task
                {
                    type = "RecaptchaV1Task",
                    websiteURL = websiteURL,
                    websiteKey = websiteKey,
                    proxyType = proxyType,
                    proxyAddress = proxyAddress,
                    proxyPort = proxyPort,
                    userAgent = userAgent,

                    proxyLogin = proxyLogin,
                    proxyPassword = proxyPassword,
                    cookies = cookie,
                },
            };
            string data = serializer(query);
            return data;
        }

        /// <summary>
        /// Составить запрос для решение старай версия рекапчи, без прокси
        /// </summary>
        /// <returns></returns>
        public string RecaptchaV1TaskProxyless(string clientKey, 
            string websiteURL, 
            string websiteKey)
        {
            var query = new JsonSer.RecaptchaV1TaskProxyless()
            {
                clientKey = clientKey,
                softId = softId,
                task = new JsonSer.RecaptchaV1TaskProxyless.Task
                {
                    type = "RaptchaV1TaskProxyless",
                    websiteURL = websiteURL,
                    websiteKey = websiteKey,
                },
            };
            string data = serializer(query);
            return data;
        }

        #endregion
    }
}
