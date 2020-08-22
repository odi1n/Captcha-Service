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
    public class FunCaptcha : Setting
    {
        /// <summary>
        /// Значение параметра pk или data-pkey которое вы нашли в коде страницы
        /// </summary>
        public string PublicKey { get; set; }
        /// <summary>
        /// Значение параметра surl которое вы нашли в коде страницы
        /// </summary>
        public string Surl { get; set; }
        /// <summary>
        /// Дополнительные данные передаваемые при загрузке FunCaptcha.
        /// </summary>
        public string DataKey { get; set; }
        /// <summary>
        /// Полный URL страницы, на которой вы решаете FunCaptcha
        /// </summary>
        public string PageUrl { get; set; }
        /// <summary>
        /// Говорит нам решать FunCaptcha с выключенным javascript. Может быть использован в случае, если нормальный метод по какой-то причине не срабатывает.
        /// Важно: имейте в виду, что в этом случае мы вернём только часть токена.Выше описано, что делать в этом случае.
        /// </summary>
        public int Nojs { get; set; }
        /// <summary>
        /// Говорит нам использовать ваш user-agent.
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// FunCaptcha с токеном
        /// </summary>
        /// <param name="publicKey">Значение параметра pk или data-pkey которое вы нашли в коде страницы</param>
        /// <param name="pageUrl">Полный URL страницы, на которой вы решаете FunCaptcha</param>
        public FunCaptcha(string publicKey, string pageUrl, string surl = null, string dataKey = null, int? nojs = null, string userAgent = null,
            bool headerAcao = false, string pingback = null, string proxy = null, ProxyType? proxyType = null)
        {
            this.Methods = Method.FunCaptcha;
            this.PublicKey = publicKey;
            this.Surl = surl;
            this.DataKey = dataKey;
            this.PageUrl = pageUrl;
            this.Nojs = nojs.Value;
            this.UserAgent = userAgent;
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
                ["publickey"] = this.PublicKey,
                ["surl"] = this.Surl,
                ["data[key]"] = this.DataKey,
                ["pageurl"] = this.PageUrl,
                ["nojs"] = this.Nojs,
                ["userAgent"] = this.UserAgent,
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
