using Captcha_Service.Addition;
using Captcha_Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Request
{
    public class ClickCaptcha : Setting
    {
        /// <summary>
        /// hcaptcha — указывает, что вы решаете hCaptcha
        /// </summary>
        public Method Method { get; set; } = Method.hcaptcha;
        /// <summary>
        /// Файл
        /// </summary>
        public string File { get; set; }
        /// <summary>
        /// 1 — указывает, что вы отправляете ClickCaptcha
        /// </summary>
        public int CoordinatesCaptcha { get; set; } = 1;

        /// <summary>
        /// ClickCaptcha
        /// </summary>
        /// <param name="file">Файл загружаемый</param>
        public ClickCaptcha(string file)
        {
            this.File = file;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["method"] = this.Method,
                ["coordinatescaptcha"] = this.CoordinatesCaptcha,
                ["textinstructions"] = this.TextInstructions,
                ["imginstructions"] = this.Imginstructions,
                ["language"] = this.Language,
                ["lang"] = this.Lang,
                ["header_acao"] = this.HeaderAcao,
                ["pingback"] = this.Pingback,
            };
            return DictionaryConvert.Deserialization(Data); ;
        }
    }
}
