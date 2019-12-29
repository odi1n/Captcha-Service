using Captcha_Service.Enum.Rucaptcha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Request.Rucaptcha
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
        public Method Method { get; set; } = Method.USERRECAPTCHA;
    }
}
