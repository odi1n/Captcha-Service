using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;
using System.Threading;
using System.IO;

namespace Captcha_Service.Rucaptcha.wRucaptcha
{
    partial class Query
    {
        private static string soft_id = "2392";

        #region Дополнительные методы
        /// <summary>
        /// Отправить запросс 
        /// </summary>
        /// <param name="url">Ссылка по которой передаем параметры</param>
        /// <param name="data">Передаваемые параметры</param>
        /// <returns></returns>
        private string RequestSend(string url, string data)
        {
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
                return reader.ReadToEnd();
        }

        /// <summary>
        /// Получить наш баланс в байтах
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="json">Указываем что получаем данные в json</param>
        /// <returns></returns>
        public static WebRequest GetBalanceByte(string key, bool json = false)
        {
            string Url = "http://rucaptcha.com/res.php";
            string Data = "&key=" + key + "&action=getbalance" + "&json=" + json.GetHashCode();
            return WebRequest.Create(Url + "?" + Data);
        }

        /// <summary>
        /// Проверить решилась ли наша капча
        /// </summary>
        /// <param name="key">Ключ для решения капчи</param>
        /// <param name="IdCaptcha">Id капчи</param>
        /// <param name="json">Получать ли данные в json. false(0) - получить обычно, true(1) - получить в json</param>
        /// <returns></returns>
        public string Check(string key, string IdCaptcha, int sleep = 1000, bool json = false)
        {
            string urlChek = "http://rucaptcha.com/res.php?";
            //Проверяем решение капчи 
            while (true)
            {
                //Делаем запроссы
                var testss = WebRequest.Create(urlChek + $"&key={key}&action=get&id={IdCaptcha}&json={json.GetHashCode()}");
                //Получаем запросс в нормальном виде
                string  Decision = Additional.ByteToString(testss);

                //Если вершно но без json
                if (Decision.Contains("OK"))
                    return Decision.Replace("OK|", "");

                //если есть json
                else if (Decision.Contains("request"))
                    return Decision;

                //если ошибка
                else if (Decision.Contains("ERROR"))
                    return Decision;

                //Задержка
                Thread.Sleep(sleep);
            }
        }
        #endregion

        #region Решение капчи
        /// <summary>
        /// Загрузка картинки на сервис
        /// </summary>
        /// <param name="key">Ключ для решения капчи</param>
        /// <param name="ImagePath">Ссылка на картинку</param>
        /// <param name="soft_id">ID разработчика ПО</param>
        /// <returns></returns>
        public string RegularUpload(string key, string ImagePath)
        {
            string DowloadInf = "";
            string url = "http://rucaptcha.com/in.php";
            using (var webClient = new WebClient())
            {
                webClient.QueryString.Add("key", key);
                webClient.QueryString.Add("soft_id", soft_id);

                var tets = webClient.UploadFile(url, ImagePath);
                DowloadInf = Encoding.UTF8.GetString(tets);
            }
            return DowloadInf.Replace("OK|", "");
        }

        /// <summary>
        /// Загрузить текст на сервис для решения
        /// </summary>
        /// <param name="key">Ключ от сервиса</param>
        /// <param name="TextCaptcha">Текс-Капча который требуется решить</param>
        /// <param name="soft_id">id разработчика</param>
        /// <returns></returns>
        public string TextUpload(string key, string TextCaptcha)
        {
            string DowloadInf = "";
            string url = "http://rucaptcha.com/in.php?";
            using (var webClient = new WebClient())
            {
                string data = $"key={key}&textcaptcha={TextCaptcha}&soft_id={soft_id}";
                DowloadInf = RequestSend(url, data);
            }
            return DowloadInf.Replace("OK|", "");
        }

        /// <summary>
        /// Загрузить капчу ReCaptcha V2
        /// </summary>
        /// <param name="key">Ключ для решения капчи</param>
        /// <param name="googlekey">Значение параметра k или data-sitekey</param>
        /// <param name="pageurl">Полный URL страницы, на которой вы решаете ReCaptcha V2</param>
        /// <param name="invisible">1 — говорит нам, что на сайте невидимая ReCaptcha. 0 — обычная ReCaptcha.</param>
        /// <param name="soft_id">ID разработчика ПО</param>
        /// <returns></returns>
        public string ReCaptcha_V2_Upload(string key, string googlekey, string pageurl)
        {
            string DowloadInf = "";
            string url = "http://rucaptcha.com/in.php?";
            using (var webClient = new WebClient())
            {
                string data = $"key={key}&method=userrecaptcha&googlekey={googlekey}&pageurl={pageurl}&soft_id={soft_id}";
                DowloadInf = RequestSend(url, data);
            }
            return DowloadInf.Replace("OK|", "");
        }

        /// <summary>
        /// Загрузить капчу ReCaptcha V2
        /// </summary>
        /// <param name="key">Ключ для решения капчи</param>
        /// <param name="googlekey">Значение параметра k или data-sitekey</param>
        /// <param name="pageurl">Полный URL страницы, на которой вы решаете ReCaptcha V2</param>
        /// <param name="invisible">1 — говорит нам, что на сайте невидимая ReCaptcha. 0 — обычная ReCaptcha.</param>
        /// <param name="soft_id">ID разработчика ПО</param>
        /// <returns></returns>
        public string ReCaptcha_V3_Upload(string key, string googlekey, string pageurl, string action)
        {
            string DowloadInf = "";
            string url = "http://rucaptcha.com/in.php?";
            using (var webClient = new WebClient())
            {
                string data = $"key={key}&method=userrecaptcha&version=v3&googlekey={googlekey}&pageurl={pageurl}&action={action}&soft_id={soft_id}";
                DowloadInf = RequestSend(url, data);
            }
            return DowloadInf.Replace("OK|", "");
        }
        #endregion
    }
}
