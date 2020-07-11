using Captcha_Service.Addition;
using Captcha_Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Request
{
    public class ReCaptchaV3 : Setting
    {
        /// <summary>
        /// Полный URL страницы, на которой вы решаете ReCaptcha V2
        /// </summary>
        public string PageUrl { get; set; }
        /// <summary>
        /// Значение параметра k или data-sitekey, которое вы нашли в коде страницы
        /// </summary>
        public string GoogleKey { get; set; }
        /// <summary>
        /// Метод указан по умолчанию
        /// </summary>
        public Method Method { get; set; } = Method.userrecaptcha;
        /// <summary>
        /// v3 — указывает на то, что это ReCaptcha V3. указана по умолчанию
        /// </summary>
        public string Version { get; set; } = "v3";
        /// <summary>
        /// Значение параметра action, которые вы нашли в коде сайта
        /// </summary>
        public string Action { get; set; } = "verify";
        /// <summary>
        /// Требуемое значение рейтинга (score). На текущий момент сложно получить токен со score выше 0.3
        /// </summary>
        public double? MinScore { get; set; } = 0.4;

        public ReCaptchaV3(string googlekey, string pageurl)
        {
            this.GoogleKey = googlekey;
            this.PageUrl = pageurl;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["method"] = this.Method,
                ["version"] = this.Version,
                ["googlekey"] = this.GoogleKey,
                ["pageurl"] = this.PageUrl,
                ["action"] = this.Action,
                ["min_score"] = this.MinScore,
                ["header_acao"] = this.HeaderAcao,
                ["pingback"] = this.Pingback,
                ["proxy"] = this.Proxy,
                ["proxytype"] = this.ProxyType,
            };
            return DictionaryConvert.Deserialization(Data);
        }
    }
}
