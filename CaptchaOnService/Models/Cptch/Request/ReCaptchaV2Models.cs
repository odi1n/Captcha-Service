using Captcha_Service.Addition;
using Captcha_Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Cptch.Request
{
    public class ReCaptchaV2Models : SettingModels
    {
        public Method Method { get; set; }
        public string GoogleKey { get; set; }
        public string PageUrl { get; set; }

        public ReCaptchaV2Models(string googleKey, string pageUrl, Method method = Method.userrecaptcha, int headerAcao = 0)
        {
            this.Method = method;
            this.GoogleKey = googleKey;
            this.PageUrl = pageUrl;
            this.HeaderAcao = headerAcao;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["method"] = this.Method,
                ["googlekey"] = this.GoogleKey,
                ["pageurl"] = this.PageUrl,
                ["header_acao"] = this.HeaderAcao,
            };

            return DictionaryConvert.Deserialization(Data);
        }
    }
}
