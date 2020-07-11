using Captcha_Service.Addition;
using Captcha_Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Request
{
    public class HCaptcha : Setting
    {
        /// <summary>
        /// hcaptcha — указывает, что вы решаете hCaptcha
        /// </summary>
        public Method Method { get; set; } = Method.hcaptcha;
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
        public HCaptcha(string siteKey, string pageUrl)
        {
            this.SiteKey = siteKey;
            this.PageUrl = pageUrl;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["method"] = this.Method,
                ["sitekey"] = this.SiteKey,
                ["pageurl"] = this.PageUrl,
                ["header_acao"] = this.HeaderAcao,
                ["pingback"] = this.Pingback,
                ["proxy"] = this.Proxy,
                ["proxytype"] = this.ProxyType,
            };
            return DictionaryConvert.Deserialization(Data); ;
        }
    }
}
