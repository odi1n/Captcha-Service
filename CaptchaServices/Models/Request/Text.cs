using Captcha_Service.Additions;
using Captcha_Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Request
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
        public Text(string textCaptcha, Lang? lang = null, int language = 0, int headerAcao = 0, string pingback = null)
        {
            this.TextCaptcha = textCaptcha;
            this.Lang = lang;
            this.Language = language;
            this.HeaderAcao = headerAcao;
            this.Pingback = pingback;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["language"] = this.Language,
                ["lang"] = this.Lang,
                ["textcaptcha"] = this.TextCaptcha,
                ["header_acao"] = this.HeaderAcao,
                ["pingback"] = this.Pingback,
            };
            return DictionaryConvert.Deserialization(Data); ;
        }
    }
}
