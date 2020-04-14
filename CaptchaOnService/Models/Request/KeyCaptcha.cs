using Captcha_Service.Addition;
using Captcha_Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Request
{
    public class KeyCaptcha : Setting
    {
        public string TextCaptcha { get; set; }

       
        public KeyCaptcha(string textCaptcha, Lang? lang = null, int language = 0, int headerAcao = 0, string pingback = null)
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
