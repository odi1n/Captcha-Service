using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;
using System.Threading;
using System.IO;
using Captcha_Service.Models.Rucaptcha;
using Captcha_Service.Request;

namespace Captcha_Service.Rucaptcha.wRucaptcha
{
    partial class Query
    {
        private static readonly string _softId = "2392";
        private static readonly string _url = "http://rucaptcha.com/res.php?";
        private static readonly RuCapRequest _request = new RuCapRequest();
        private static string _key { get; set; }


        public Query(string key)
        {
            _key = key;
        }

        /// <summary>
        /// Получить наш баланс в байтах
        /// </summary>
        /// <returns></returns>
        public string GetBalanceByte(GetBalnceModels data)
        {
            string Data = "&key=" + data.Key + 
                "&action=" +data.Action +
                "&id=" + data.Id +
                "&ids=" + data.Ids;

            return _request.ByteToString(WebRequest.Create(_url + "?" + Data));
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
            while ( true )
            {
                var testss = WebRequest.Create(_url + $"&key={key}&action=get&id={IdCaptcha}&json={json.GetHashCode()}");
                string Decision = _request.ByteToString(testss);

                if ( Decision.Contains("OK") )
                    return Decision.Replace("OK|", "");
                else if ( Decision.Contains("request") )
                    return Decision;
                else if ( Decision.Contains("ERROR") )
                    return Decision;

                Thread.Sleep(sleep);
            }
        }

        /// <summary>
        /// Загрузка картинки на сервис
        /// </summary>
        /// <returns></returns>
        public string RegularUpload(RegularModels regular)
        {
            using ( var webClient = new WebClient() )
            {
                webClient.QueryString.Add("key", _key);
                webClient.QueryString.Add("Soft_id", _softId);

                var tets = webClient.UploadFile(_url, regular.ImapePath);
                return Encoding.UTF8.GetString(tets).Replace("OK|", ""); ;
            }
        }

        /// <summary>
        /// Загрузить текст на сервис для решения
        /// </summary>
        /// <returns></returns>
        public string TextUpload(string TextCaptcha)
        {
            string data = $"key={_key}&textcaptcha={TextCaptcha}&Soft_id={_softId}";
            return _request.Get(_url, data).Replace("OK|", "");
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
        public string RcV2Upload(RcV2Models recaptcha)
        {
            string data = $"key={_key}&method=userrecaptcha&googlekey={recaptcha.GoogleKey}&pageurl={recaptcha.PageUrl}&Soft_id={_softId}";
            return _request.Get(_url, data).Replace("OK|", "");
        }

        /// <summary>
        /// Загрузить капчу ReCaptcha V2
        /// </summary>
        /// <returns></returns>
        public string RcV3Upload(RcV3Models recaptcha)
        {
            string data = $"key={_key}&method=userrecaptcha&version=v3&googlekey={recaptcha.GoogleKey}&pageurl={recaptcha.PageUrl}&action={recaptcha.Action}&Soft_id={_softId}";
            return _request.Get(_url, data).Replace("OK|", "");
        }
    }
}
