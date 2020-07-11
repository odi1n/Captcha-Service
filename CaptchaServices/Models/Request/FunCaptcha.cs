using Captcha_Service.Additions;
using Captcha_Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Request
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
        /// funcaptcha — указывает, что вы решаете FunCaptcha с помощью токена
        /// </summary>
        public Method Method { get; set; } = Method.funcaptcha;

        /// <summary>
        /// FunCaptcha с токеном
        /// </summary>
        /// <param name="publicKey">Значение параметра pk или data-pkey которое вы нашли в коде страницы</param>
        /// <param name="pageUrl">Полный URL страницы, на которой вы решаете FunCaptcha</param>
        public FunCaptcha(string publicKey, string pageUrl)
        {
            this.PublicKey = publicKey;
            this.PageUrl = pageUrl;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["method"] = this.Method,
                ["publickey"] = this.PublicKey,
                ["surl"] = this.Surl,
                ["pageurl"] = this.PageUrl,
                ["nojs"] = this.Nojs,
                ["userAgent"] = this.UserAgent,
                ["header_acao"] = this.HeaderAcao,
                ["pingback"] = this.Pingback,
                ["proxy"] = this.Proxy,
                ["proxytype"] = this.ProxyType,
            };
            return DictionaryConvert.Deserialization(Data); ;
        }
    }
}
