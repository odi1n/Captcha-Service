using Captcha_Service.Additions;
using Captcha_Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Captcha.Request
{
    public class ReCaptchaV2 : Setting
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
        public int? Invisible { get; set; } = 0;
        /// <summary>
        /// Метод указан по умолчанию
        /// </summary>
        public string Methods { get; private set; } = Method.UserreCaptcha;

        public ReCaptchaV2(string googlekey, string pageurl)
        {
            this.GoogleKey = googlekey;
            this.PageUrl = pageurl;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["method"] = this.Methods,
                ["googlekey"] = this.GoogleKey,
                ["pageurl"] = this.PageUrl,
                ["invisible"] = this.Invisible,
                ["header_acao"] = this.HeaderAcao,
                ["pingback"] = this.Pingback,
                ["proxy"] = this.Proxy,
                ["proxytype"] = this.ProxyType,
            };

            return DictionaryConvert.Deserialization(Data);
        }
    }
}
