using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;
using System.Threading;
using System.IO;
using Captcha_Service.Models.Request.Rucaptcha;
using Captcha_Service.Request;
using Captcha_Service.Addition;
using Captcha_Service.Models.Response.Rucaptcha;
using Captcha_Service.Exception.Rucaptcha;
using Captcha_Service.Enum.Rucaptcha;

namespace Captcha_Service.Rucaptcha.wRucaptcha
{
    partial class Query
    {
        private static readonly string _softId = "2392";
        private static readonly string _urlIn = "http://rucaptcha.com/in.php?";
        private static readonly string _urlRes = "http://rucaptcha.com/res.php?";
        private static readonly RucaptchaRequest _request = new RucaptchaRequest();
        private static string _key { get; set; }

        public Query(string key)
        {
            _key = key;
        }

        

        /// <summary>
        /// Получить наш баланс в байтах
        /// </summary>
        /// <returns></returns>
        public ResponseInfoModels AdditionInfomation(GetBalnceModels data)
        {
            var Data = new Dictionary<string, object>()
            {
                ["key"] = data.Key,
                ["action"] = data.Action,
                ["id"] = data.Id,
                ["ids"] = data.Ids,
                ["json"] = data.Json,
            };

            return _request.GetRequest(_urlRes, Data);
        }

        /// <summary>
        /// Проверить решилась ли наша капча
        /// </summary>
        /// <param name="key">Ключ для решения капчи</param>
        /// <param name="IdCaptcha">Id капчи</param>
        /// <param name="json">Получать ли данные в json. false(0) - получить обычно, true(1) - получить в json</param>
        /// <returns></returns>
        public string Check(string key, string IdCaptcha, int sleep = 1000, int json = 1)
        {
            while ( true )
            {
                var testss = WebRequest.Create(_urlRes + $"&key={key}&action=get&id={IdCaptcha}&json={json.GetHashCode()}");
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
        /// Загрузить текст на сервис для решения
        /// </summary>
        /// <returns></returns>
        public ResponseInfoModels Text(TextModels text)
        {
            var Data = new Dictionary<string, object>()
            {
                ["key"] = text.Key,
                ["language"] = text.Language,
                ["lang"] = text.Lang,
                ["textcaptcha"] = text.TextCaptcha,
                ["header_acao"] = text.HeaderAcao,
                ["pingback"] = text.HeaderAcao,
                ["json"] = text.Json,
                ["soft_id"] = _softId,
            };

            return _request.GetRequest(_urlIn, Data);
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
        public ResponseInfoModels ReCaptchaV2(ReCaptchaV2Models recaptcha)
        {
            var Data = new Dictionary<string, object>()
            {
                ["key"] = recaptcha.Key,
                ["method"] = recaptcha.Method,
                ["googlekey"] = recaptcha.GoogleKey,
                ["pageurl"] = recaptcha.PageUrl,
                ["invisible"] = recaptcha.Invisible,
                ["header_acao"] = recaptcha.HeaderAcao,
                ["pingback"] = recaptcha.HeaderAcao,
                ["json"] = recaptcha.Json,
                ["soft_id"] = recaptcha.Sleep,
                ["proxy"] = recaptcha.Proxy,
                ["proxytype"] = recaptcha.Proxytype,
                ["soft_id"] = _softId,

            };

            return _request.GetRequest(_urlIn, Data);
        }

        /// <summary>
        /// Загрузить капчу ReCaptcha V2
        /// </summary>
        /// <returns></returns>
        public ResponseInfoModels ReCaptchaV3(ReCaptchaV3Models recaptcha)
        {
            var Data = new Dictionary<string, object>()
            {
                ["key"] = recaptcha.Key,
                ["method"] = recaptcha.Method,
                ["version"] = recaptcha.Version,
                ["googlekey"] = recaptcha.GoogleKey,
                ["pageurl"] = recaptcha.PageUrl,
                ["action"] = recaptcha.Action,
                ["min_score"] = recaptcha.MinScore,
                ["header_acao"] = recaptcha.HeaderAcao,
                ["pingback"] = recaptcha.HeaderAcao,
                ["json"] = recaptcha.Json,
                ["soft_id"] = recaptcha.Sleep,
                ["proxy"] = recaptcha.Proxy,
                ["proxytype"] = recaptcha.Proxytype,
                ["soft_id"] = _softId,

            };

            return _request.GetRequest(_urlIn, Data);
        }

        /// <summary>
        /// Загрузка картинки на сервис
        /// </summary>
        /// <returns></returns>
        public string Regular(RegularModels regular)
        {
            using ( var webClient = new WebClient() )
            {
                var data = new Dictionary<string, object>()
                {
                    ["key"] = regular.Key,
                    ["method"] = regular.Method,
                    ["phrase"] = regular.Phrase,
                    ["regsense"] = regular.Regsense,
                    ["numeric"] = regular.Numeric,
                    ["calc"] = regular.Calc,
                    ["min_len"] = regular.MinLen,
                    ["max_len"] = regular.MaxLen,
                    ["language"] = regular.Language,
                    ["lang"] = regular.Lang,
                    ["textinstructions"] = regular.Textinstructions,
                    ["imginstructions"] = regular.Imginstructions,
                    ["header_acao"] = regular.HeaderAcao,
                    ["pingback"] = regular.Pingback,
                    ["json"] = regular.Json,
                    ["soft_id"] = _softId,
                };

                var request = webClient.UploadFile(_urlIn + DictionaryConvert.Deserialization(data), regular.ImapePath);
                return Encoding.UTF8.GetString(request);
            }
        }
    }
}
