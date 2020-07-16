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
    public class HCaptcha : Setting
    {
        /// <summary>
        /// Значение параметра data-sitekey, которое вы нашли в коде страницы
        /// </summary>
        public string SiteKey { get; set; }
        /// <summary>
        /// Полный URL страницы, на которой вы решаете hCaptcha
        /// </summary>
        public string PageUrl { get; set; }

        /// <summary>
        /// hCaptcha
        /// </summary>
        /// <param name="siteKey">Значение параметра data-sitekey, которое вы нашли в коде страницы</param>
        /// <param name="pageUrl">Полный URL страницы, на которой вы решаете hCaptcha</param>
        public HCaptcha(string siteKey, string pageUrl, bool headerAcao = false, string pingback = null, string proxy = null, ProxyType? proxyType = null)
        {
            this.Methods = Method.HCaptcha;
            this.SiteKey = siteKey;
            this.PageUrl = pageUrl;
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
                ["sitekey"] = this.SiteKey,
                ["pageurl"] = this.PageUrl,
                ["header_acao"] = this.HeaderAcao.GetHashCode(),
                ["pingback"] = this.Pingback,
                ["proxy"] = this.Proxy,
                ["proxytype"] = this.ProxyType,

                ["json"] = Json.GetHashCode(),
                ["soft_id"] = SoftId,
            };
            return Converts.StringToDictionary(Data); ;
        }
    }
}
