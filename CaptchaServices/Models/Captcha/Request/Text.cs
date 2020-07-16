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
    public class Text : Setting
    {
        /// <summary>
        /// Текст капчи.
        /// </summary>
        public string TextCaptcha { get; set; }

        /// <summary>
        /// Модель текстовой капчи
        /// </summary>
        /// <param name="textCaptcha">Текст капчи</param>
        /// <param name="lang">Код языка</param>
        /// <param name="language">0 — не определено 1 — капча содержит только кириллицу 2 — капча содержит только латиницу</param>
        /// <param name="headerAcao">0 — выключен 1 — включен</param>
        /// <param name="pingback">URL для автоматической отправки ответа на капчу (callback)</param>
        public Text(string textCaptcha, int language = 0, Lang? lang = null,  bool headerAcao = false, string pingback = null)
        {
            this.TextCaptcha = textCaptcha;
            this.Language = language;
            this.Lang = lang;
            this.HeaderAcao = headerAcao;
            this.Pingback = pingback;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["key"] = Key,

                ["language"] = this.Language,
                ["lang"] = this.Lang,
                ["textcaptcha"] = this.TextCaptcha,
                ["header_acao"] = this.HeaderAcao.GetHashCode(),
                ["pingback"] = this.Pingback,

                ["json"] = Json.GetHashCode(),
                ["soft_id"] = SoftId,
            };
            return Converts.StringToDictionary(Data); ;
        }
    }
}
