using Captcha_Service.Addition;
using Captcha_Service.Enum;
using Captcha_Service.Models.Cptch.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Cptch.Request
{
    public class RegularModels : SettingModels
    {
        public Method Method { get; set; }
        public string File { get; set; }
        public string Base64 { get; set; }
        public RegularModels( string file, Method method = Method.post, string base64 = null, int headerAcao = 0)
        {
            this.Method = method;
            this.File = file;
            this.Base64 = base64;
            this.HeaderAcao = headerAcao;
        }

        public override string ToString()
        {
            var data = new Dictionary<string, object>()
            {
                ["base64"] = this.Base64,
                ["method"] = this.Method,
                ["header_acao"] = this.HeaderAcao,
            };

            return DictionaryConvert.Deserialization(data);
        }
    }
}
