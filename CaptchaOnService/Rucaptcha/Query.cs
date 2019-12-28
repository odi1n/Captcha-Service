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
        private static string _key { get { return Rucaptcha.Key; } }
        private static readonly int _json = 1;
        private static readonly string _softId = "2392";
        private static readonly string _urlIn = "http://rucaptcha.com/in.php?";
        private static readonly string _urlRes = "http://rucaptcha.com/res.php?";
        private static readonly RucaptchaRequest _request = new RucaptchaRequest();

        /// <summary>
        /// Получить наш баланс в байтах
        /// </summary>
        /// <returns></returns>
        public ResponseInfoModels AdditionInfomation(GetBalnceModels data)
        {
            var Data = new Dictionary<string, object>()
            {
                ["key"] = _key,
                ["json"] = _json,
                ["action"] = data.Action,
                ["id"] = data.Id,
                ["ids"] = data.Ids,
            };

            return _request.GetRequest(_urlRes, Data);
        }

        /// <summary>
        /// Проверить решилась ли наша капча
        /// </summary>
        /// <param name="check">Данные капчи</param>
        /// <returns></returns>
        public ResponseInfoModels Check(CheckModels check)
        {
            while ( true )
            {
                var Data = new Dictionary<string, object>()
                {
                    ["key"] = _key,
                    ["json"] = _json,
                    ["action"] = check.Action,
                    ["id"] = check.Id,
                    ["header_acao"] = check.HeaderAcao,
                };

                var response = _request.GetRequest(_urlRes, Data);

                if ( response.status == 1 && response.request != "CAPCHA_NOT_READY" )
                    return response;

                Thread.Sleep(check.Sleep);
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
                ["key"] = _key,
                ["json"] = _json,
                ["soft_id"] = _softId,
                ["language"] = text.Language,
                ["lang"] = text.Lang,
                ["textcaptcha"] = text.TextCaptcha,
                ["header_acao"] = text.HeaderAcao,
                ["pingback"] = text.HeaderAcao,
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
                ["key"] = _key,
                ["json"] = _json,
                ["soft_id"] = _softId,
                ["method"] = recaptcha.Method,
                ["googlekey"] = recaptcha.GoogleKey,
                ["pageurl"] = recaptcha.PageUrl,
                ["invisible"] = recaptcha.Invisible,
                ["header_acao"] = recaptcha.HeaderAcao,
                ["pingback"] = recaptcha.HeaderAcao,
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
                ["key"] = _key,
                ["json"] = _json,
                ["soft_id"] = _softId,
                ["method"] = recaptcha.Method,
                ["version"] = recaptcha.Version,
                ["googlekey"] = recaptcha.GoogleKey,
                ["pageurl"] = recaptcha.PageUrl,
                ["action"] = recaptcha.Action,
                ["min_score"] = recaptcha.MinScore,
                ["header_acao"] = recaptcha.HeaderAcao,
                ["pingback"] = recaptcha.HeaderAcao,
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
        public ResponseInfoModels Regular(RegularModels regular)
        {
            var data = new Dictionary<string, object>()
            {
                ["key"] = _key,
                ["json"] = _json,
                ["soft_id"] = _softId,
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
            };

            var photo = _request.UploadFile(_urlIn + DictionaryConvert.Deserialization(data), regular.ImapePath);

            return photo;
        }
    }
}
