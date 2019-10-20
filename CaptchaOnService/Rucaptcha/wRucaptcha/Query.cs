using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;
using System.Threading;
using System.IO;
using Captcha_Service.Rucaptcha.ReqModels;

namespace Captcha_Service.Rucaptcha.wRucaptcha
{
    partial class Query
    {
        private static readonly string Soft_id = "2392";
        private static readonly string Url = "http://rucaptcha.com/res.php?";
        public string Key { get; set; }
        public Query(string Key)
        {
            this.Key = Key;
        }

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
        /// Переводим данные с байтов в текст
        /// </summary>
        /// <param name="request">Байт которые будем переводить в текст</param>
        /// <returns></returns>
        public static string ByteToString(WebRequest request)
        {
            using ( HttpWebResponse response = (HttpWebResponse)request.GetResponse() )
            using ( StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default, true, 8192) )
                return reader.ReadToEnd();
        }

        /// <summary>
        /// Получить наш баланс в байтах
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="json">Указываем что получаем данные в json</param>
        /// <returns></returns>
        public string GetBalanceByte(GetBalance data)
        {
            string Data = "&key=" + data.Key + "&action=getbalance" + "&json=" + data.Json.GetHashCode();
            return ByteToString( WebRequest.Create(Url + "?" + Data));
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
            while (true)
            {
                var testss = WebRequest.Create(Url + $"&key={key}&action=get&id={IdCaptcha}&json={json.GetHashCode()}");
                string  Decision = ByteToString(testss);

                if (Decision.Contains("OK"))
                    return Decision.Replace("OK|", "");
                else if (Decision.Contains("request"))
                    return Decision;
                else if (Decision.Contains("ERROR"))
                    return Decision;

                Thread.Sleep(sleep);
            }
        }

        /// <summary>
        /// Загрузка картинки на сервис
        /// </summary>
        /// <param name="key">Ключ для решения капчи</param>
        /// <param name="ImagePath">Ссылка на картинку</param>
        /// <param name="Soft_id">ID разработчика ПО</param>
        /// <returns></returns>
        public string RegularUpload(Regular regular)
        {
            using (var webClient = new WebClient())
            {
                webClient.QueryString.Add("key", Key);
                webClient.QueryString.Add("Soft_id", Soft_id);

                var tets = webClient.UploadFile(Url, regular.Imape_path);
                return Encoding.UTF8.GetString(tets).Replace("OK|", ""); ;
            }
        }

        /// <summary>
        /// Загрузить текст на сервис для решения
        /// </summary>
        /// <param name="key">Ключ от сервиса</param>
        /// <param name="TextCaptcha">Текс-Капча который требуется решить</param>
        /// <param name="Soft_id">id разработчика</param>
        /// <returns></returns>
        public string TextUpload(string TextCaptcha)
        {
                string data = $"key={Key}&textcaptcha={TextCaptcha}&Soft_id={Soft_id}";
                return  RequestSend(Url, data).Replace("OK|", "");
        }

        /// <summary>
        /// Загрузить капчу ReCaptcha V2
        /// </summary>
        /// <param name="key">Ключ для решения капчи</param>
        /// <param name="googlekey">Значение параметра k или data-sitekey</param>
        /// <param name="pageurl">Полный URL страницы, на которой вы решаете ReCaptcha V2</param>
        /// <param name="invisible">1 — говорит нам, что на сайте невидимая ReCaptcha. 0 — обычная ReCaptcha.</param>
        /// <param name="Soft_id">ID разработчика ПО</param>
        /// <returns></returns>
        public string ReCaptcha_V2_Upload(ReCaptcha_V2 recaptcha)
        {
                string data = $"key={Key}&method=userrecaptcha&googlekey={recaptcha.Google_key}&pageurl={recaptcha.Page_url}&Soft_id={Soft_id}";
                return RequestSend(Url, data).Replace("OK|", "");
        }

        /// <summary>
        /// Загрузить капчу ReCaptcha V2
        /// </summary>
        /// <param name="key">Ключ для решения капчи</param>
        /// <param name="googlekey">Значение параметра k или data-sitekey</param>
        /// <param name="pageurl">Полный URL страницы, на которой вы решаете ReCaptcha V2</param>
        /// <param name="invisible">1 — говорит нам, что на сайте невидимая ReCaptcha. 0 — обычная ReCaptcha.</param>
        /// <param name="Soft_id">ID разработчика ПО</param>
        /// <returns></returns>
        public string ReCaptcha_V3_Upload( ReCaptcha_V3 recaptcha)
        {
                string data = $"key={Key}&method=userrecaptcha&version=v3&googlekey={recaptcha.Google_key}&pageurl={recaptcha.Page_url}&action={recaptcha.Action}&Soft_id={Soft_id}";
                return RequestSend(Url, data).Replace("OK|", "");
        }
    }
}
