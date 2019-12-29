using Captcha_Service.Enum.Rucaptcha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Request.Rucaptcha
{
    public class ReCaptchaV3Models : SettingModels
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
        public Method Method { get; set; } = Method.USERRECAPTCHA;
        /// <summary>
        /// v3 — указывает на то, что это ReCaptcha V3. указана по умолчанию
        /// </summary>
        public string Version { get; set; } = "v3";
        /// <summary>
        /// Значение параметра action, которые вы нашли в коде сайта
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// Требуемое значение рейтинга (score). На текущий момент сложно получить токен со score выше 0.3
        /// </summary>
        public double? MinScore { get; set; } 
    }
}
