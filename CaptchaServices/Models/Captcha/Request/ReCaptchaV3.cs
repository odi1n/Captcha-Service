using Captcha_Service.Additions;
using Captcha_Service.Enums;
using Captcha_Service.Models.Captcha.Addition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Captcha.Request
{
    public class ReCaptchaV3 : Setting
    {
        /// <summary>
        /// v3 — указывает на то, что это ReCaptcha V3. указана по умолчанию
        /// </summary>
        internal string Version { get; set; }
        /// <summary>
        /// Значение параметра k или data-sitekey, которое вы нашли в коде страницы
        /// </summary>
        public string GoogleKey { get; set; }
        /// <summary>
        /// Полный URL страницы, на которой вы решаете ReCaptcha V2
        /// </summary>
        public string PageUrl { get; set; }
        /// <summary>
        /// Значение параметра action, которые вы нашли в коде сайта
        /// </summary>
        public string Action { get; set; } = "verify";
        /// <summary>
        /// Требуемое значение рейтинга (score). На текущий момент сложно получить токен со score выше 0.3
        /// </summary>
        public double MinScore { get; set; } = 0.4;

        public ReCaptchaV3(string googlekey, string pageurl, string action = "verify", double minScore = 0.4,
            bool headerAcao = false, string pingback = null, string proxy = null, ProxyType? proxyType = null)
        {
            this.Methods = Method.UserreCaptcha;
            this.Version =  "v3";
            this.GoogleKey = googlekey;
            this.PageUrl = pageurl;
            this.Action = action;
            this.MinScore = minScore;
            this.HeaderAcao = headerAcao;
            this.Pingback = pingback;
            this.Proxy = proxy;
            this.ProxyType = proxyType;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["key"] = Key,

                ["method"] = this.Methods,
                ["version"] = this.Version,
                ["googlekey"] = this.GoogleKey,
                ["pageurl"] = this.PageUrl,
                ["action"] = this.Action,
                ["min_score"] = this.MinScore,
                ["header_acao"] = this.HeaderAcao.GetHashCode(),
                ["pingback"] = this.Pingback,
                ["proxy"] = this.Proxy,
                ["proxytype"] = this.ProxyType,

                ["json"] = Json.GetHashCode(),
                ["soft_id"] = SoftId,
            };
            return Converts.StringToDictionary(Data);
        }
    }
}
