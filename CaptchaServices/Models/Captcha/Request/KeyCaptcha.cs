using Captcha_Service.Additions;
using Captcha_Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Captcha.Request
{
    public class KeyCaptcha : Setting
    {
        /// <summary>
        /// keycaptcha — говорит о том, что вы отправляете KeyCaptcha
        /// </summary>
        public string Methods { get; private set; } = Method.KeyCaptcha;
        /// <summary>
        /// Значение параметра s_s_c_user_id, найденное на странице
        /// </summary>
        public string SSCUserId { get; set; }
        /// <summary>
        /// Значение параметра s_s_c_session_id, найденное на странице
        /// </summary>
        public string SSCSessionId { get; set; }
        /// <summary>
        /// Значение параметра s_s_c_web_server_sign, найденное на странице
        /// </summary>
        public string SSCWebServerSign { get; set; }
        /// <summary>
        /// Значение параметра s_s_c_web_server_sign2, найденное на странице
        /// </summary>
        public string SSCWebServerSign2 { get; set; }
        /// <summary>
        /// Полный URL страницы с KeyCaptcha
        /// </summary>
        public string PageUrl { get; set; }

        /// <summary>
        /// KeyCaptcha
        /// </summary>
        /// <param name="s_s_c_user_id">Значение параметра s_s_c_user_id, найденное на странице</param>
        /// <param name="s_s_c_session_id">Значение параметра s_s_c_session_id, найденное на странице</param>
        /// <param name="s_s_c_web_server_sign">Значение параметра s_s_c_web_server_sign, найденное на странице</param>
        /// <param name="s_s_c_web_server_sign2">Значение параметра s_s_c_web_server_sign2, найденное на странице</param>
        /// <param name="pageUrl">Полный URL страницы с KeyCaptcha</param>
        public KeyCaptcha(string s_s_c_user_id, string s_s_c_session_id, string s_s_c_web_server_sign, string s_s_c_web_server_sign2, 
            string pageUrl)
        {
            this.SSCUserId = s_s_c_user_id;
            this.SSCSessionId = s_s_c_session_id;
            this.SSCWebServerSign = s_s_c_web_server_sign;
            this.SSCWebServerSign2 = s_s_c_web_server_sign2;
            this.PageUrl = pageUrl;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["method"] = this.Methods,
                ["s_s_c_user_id	"] = this.SSCUserId,
                ["s_s_c_session_id"] = this.SSCSessionId,
                ["s_s_c_web_server_sign"] = this.SSCWebServerSign,
                ["s_s_c_web_server_sign2"] = this.SSCWebServerSign2,
                ["pageurl"] =this.PageUrl,
                ["header_acao"] =this.HeaderAcao,
                ["pingback"] =this.Pingback,
            };
            return DictionaryConvert.Deserialization(Data); ;
        }
    }
}
