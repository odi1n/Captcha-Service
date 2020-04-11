using Captcha_Service.Addition;
using Captcha_Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Rucaptcha.Request
{
    public class ReCaptchaV2Models : SettingModels
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
        /// 1 — говорит нам, что на сайте невидимая ReCaptcha. 0 — обычная ReCaptcha.
        /// </summary>
        public int? Invisible { get; set; }
        /// <summary>
        /// Метод указан по умолчанию
        /// </summary>
        public Method Method { get; set; } = Method.userrecaptcha;

        public ReCaptchaV2Models(string googlekey, string pageurl, Method method = Method.userrecaptcha, int? invisible = null, int? header_acao = null, string pingback = null,
            string proxy = null, ProxyType? proxy_type = null)
        {
            this.Method = method;
            this.GoogleKey = googlekey;
            this.PageUrl = pageurl;
            this.Invisible = invisible;
            this.HeaderAcao = header_acao;
            this.Proxy = proxy;
            this.Proxytype = proxy_type;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["method"] = this.Method,
                ["googlekey"] = this.GoogleKey,
                ["pageurl"] = this.PageUrl,
                ["invisible"] = this.Invisible,
                ["header_acao"] = this.HeaderAcao,
                ["pingback"] = this.Pingback,
                ["proxy"] = this.Proxy,
                ["proxytype"] = this.Proxytype,
            };

            return DictionaryConvert.Deserialization(Data);
        }
    }
}
