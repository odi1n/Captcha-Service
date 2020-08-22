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
    public class ReCaptchaV2 : Setting
    {
        /// <summary>
        /// Значение параметра k или data-sitekey, которое вы нашли в коде страницы
        /// </summary>
        public string GoogleKey { get; set; }
        /// <summary>
        /// Полный URL страницы, на которой вы решаете ReCaptcha V2
        /// </summary>
        public string PageUrl { get; set; }
        /// <summary>
        /// 1 — говорит нам, что на сайте невидимая ReCaptcha. 0 — обычная ReCaptcha.
        /// </summary>
        public bool Invisible { get; set; } = false;
        /// <summary>
        /// Значение параметра data-s найденное на странице. Актуально для поиска в Google и других сервисов Google.
        /// </summary>
        public string DataS { get; set; }
        /// <summary>
        /// Ваши cookies которые будут использованы работником для решения капчи.
        /// </summary>
        public string Cookies { get; set; }
        /// <summary>
        /// Подставляем у работника ваш userAgent
        /// </summary>
        public string UserAgent { get; set; } 

        public ReCaptchaV2(string pageurl, string googlekey, bool invisible = false, string dataS = null, string cookies = null, string userAgent = null,
            bool headerAcao = false, string pingback = null, string proxy = null, ProxyType? proxyType = null)
        {
            this.Methods = Method.UserreCaptcha;
            this.GoogleKey = googlekey;
            this.PageUrl = pageurl;
            this.Invisible = invisible;
            this.DataS = dataS;
            this.Cookies = cookies;
            this.UserAgent = UserAgent;
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
                ["googlekey"] = this.GoogleKey,
                ["pageurl"] = this.PageUrl,
                ["invisible"] = this.Invisible.GetHashCode(),
                ["data-s"] = this.DataS,
                ["cookies"] = this.Cookies,
                ["userAgent"] = this.UserAgent,
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
