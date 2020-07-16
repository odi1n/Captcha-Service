using Captcha_Service.Additions;
using Captcha_Service.Enums;
using Captcha_Service.Exceptions;
using Captcha_Service.Models.Captcha.Addition;
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
        public int Numeric {
            get
            {
                return _numeric;
            }
            set
            {
                _numeric = value;
                if (_numeric > 4 && _numeric < 0)
                    throw new ErrorParamsException("Значение должно быть от 0 до 4");
            }
        }
        /// <summary>
        /// 0 — не определено
        /// 1 — капча требует совершения математического действия(например: напишите результат 4 + 8 = )
        /// </summary>
        public bool Calc { get; set; }
        /// <summary>
        /// 0 — не определено
        /// 1..20 — минимальное количетсво символов в ответе
        /// </summary>
        public int MinLen
        {
            get
            {
                return _minLen;
            }
            set
            {
                _minLen = value;
                if (_minLen > 20 && _minLen < 0)
                    throw new ErrorParamsException("Значение должно быть от 0 до 20");
            }
        }
        /// <summary>
        /// 0 — не определено
        /// 1..20 — максимальное количетсво символов в ответе
        /// </summary>
        public int MaxLen
        {
            get
            {
                return _maxLen;
            }
            set
            {
                _maxLen = value;
                if (_maxLen > 20 && _maxLen < 0)
                    throw new ErrorParamsException("Значение должно быть от 0 до 20");
            }
        }

        private int _numeric;
        private int _minLen;
        private int _maxLen;

        public Regular(Decode decode, bool phrase = false, bool regsense = false, int numeric = 0, bool calc = false , int minLen = 0, int maxLen = 0,
            int language = 0, Lang? lang = null, string textinstructions = null, bool headerAcao = false, string pingback = null)
        {
            this.Methods = Method.Base64;
            this.Body = decode.ToString();
            this.Phrase = phrase;
            this.Regsense = regsense;
            this.Numeric = numeric;
            this.Calc = calc;
            this.MinLen = minLen;
            this.MaxLen = maxLen;
            this.Language = language;
            this.Lang = lang;
            this.TextInstructions = textinstructions;
            this.HeaderAcao = headerAcao;
            this.Pingback = pingback;
        }

        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>()
            {
                ["key"] = Key,
                ["json"] = Json.GetHashCode(),
                ["soft_id"] = SoftId,

                ["method"] = this.Methods,
                ["body"] = this.Body,
                ["phrase"] = this.Phrase.GetHashCode(),
                ["regsense"] = this.Regsense.GetHashCode(),
                ["numeric"] = this.Numeric,
                ["calc"] = this.Calc.GetHashCode(),
                ["min_len"] = this.MinLen,
                ["max_len"] = this.MaxLen,
                ["language"] = this.Language,
                ["lang"] = this.Lang,
                ["textinstructions"] = this.TextInstructions,
                ["header_acao"] = this.HeaderAcao.GetHashCode(),
                ["pingback"] = this.Pingback,

            };
        }

        public override string ToString()
        {
            return Converts.StringToDictionary(this.ToDictionary());
        }
    }
}
