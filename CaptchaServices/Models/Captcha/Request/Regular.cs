using Captcha_Service.Additions;
using Captcha_Service.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Captcha.Request
{
    public class Regular : Setting
    {
        /// <summary>
        /// base64
        /// </summary>
        internal string Body { get; private set; }
        /// <summary>
        /// Метод загрузки фото
        /// </summary>
        internal string Methods { get; private set; } 

        /// <summary>
        /// false — капча состоит из одного слова
        /// true — капча состоит из двух или более слов
        /// </summary>
        public bool Phrase { get; set; }
        /// <summary>
        /// false — капча не чувствительна к регистру
        /// true — капча чувствительна к регистру
        /// </summary>
        public bool Regsense { get; set; }
        /// <summary>
        /// 0 — не определено
        /// 1 — капча состоит только из цифр
        /// 2 — капча состоит только из букв
        /// 3 — капча состоит либо только из букв, либо только из цифр
        /// 4 — в капче могут быть и буквы, и цифры
        /// </summary>
        public int? Numeric { get; set; }
        /// <summary>
        /// 0 — не определено
        /// 1 — капча требует совершения математического действия(например: напишите результат 4 + 8 = )
        /// </summary>
        public int? Calc { get; set; }
        /// <summary>
        /// 0 — не определено
        /// 1..20 — минимальное количетсво символов в ответе
        /// </summary>
        public int? MinLen { get; set; }
        /// <summary>
        /// 0 — не определено
        /// 1..20 — максимальное количетсво символов в ответе
        /// </summary>
        public int? MaxLen { get; set; }

        private int _numeric { get; set; }


        public Regular(Decode decode)
        {
            this.Methods = Method.Base64;
            this.Body = decode.ToString();
        }

        public override string ToString()
        {
            var data = new Dictionary<string, object>()
            {
                ["body"] = this.Body,
                ["method"] = this.Methods,
                ["phrase"] = this.Phrase.GetHashCode(),
                ["regsense"] = this.Regsense.GetHashCode(),
                ["numeric"] = this.Numeric,
                ["calc"] = this.Calc,
                ["min_len"] = this.MinLen,
                ["max_len"] = this.MaxLen,
                ["language"] = this.Language,
                ["lang"] = this.Lang,
                ["textinstructions"] = this.TextInstructions,
                ["imginstructions"] = this.Imginstructions,
                ["header_acao"] = this.HeaderAcao,
                ["pingback"] = this.Pingback,
            };

            var info = Converts.StringToDictionary(data);
            return info;
        }
    }
}
