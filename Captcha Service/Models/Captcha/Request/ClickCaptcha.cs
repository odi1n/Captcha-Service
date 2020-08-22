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
    public class ClickCaptcha : Setting
    {
        /// <summary>
        /// Файл
        /// </summary>
        internal string Body { get; set; }
        /// <summary>
        /// 1 — указывает, что вы отправляете ClickCaptcha
        /// </summary>
        internal int CoordinatesCaptcha { get; set; } 

        /// <summary>
        /// ClickCaptcha
        /// </summary>
        /// <param name="file">Файл загружаемый</param>
        public ClickCaptcha(Decode decode, string textinstructions, int language = 0, Lang? lang = null, bool headerAcao = false, string pingBack = null)
        {
            this.Methods = Method.HCaptcha;
            this.CoordinatesCaptcha = 1;
            this.Body = decode.ToString();
            this.TextInstructions = textinstructions;
            this.Language = language;
            this.Lang = lang;
            this.HeaderAcao = headerAcao;
            this.Pingback = pingBack;
        }

        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>()
            {
                ["key"] = Key,

                ["method"] = this.Methods,
                ["body"] = this.Body,
                ["coordinatescaptcha"] = this.CoordinatesCaptcha,
                ["textinstructions"] = this.TextInstructions,
                ["language"] = this.Language,
                ["lang"] = this.Lang,
                ["header_acao"] = this.HeaderAcao,
                ["pingback"] = this.Pingback,

                ["json"] = Json.GetHashCode(),
                ["soft_id"] = SoftId,
            };
        }

        public override string ToString()
        {
            return Converts.StringToDictionary(this.ToDictionary()); ;
        }
    }
}
