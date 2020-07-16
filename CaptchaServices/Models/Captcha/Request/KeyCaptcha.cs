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
    public class KeyCaptcha : Setting
    {
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
            string pageUrl, bool headerAcao = false, string pingBack = null)
        {
            this.Methods = Method.KeyCaptcha; 
            this.SSCUserId = s_s_c_user_id;
            this.SSCSessionId = s_s_c_session_id;
            this.SSCWebServerSign = s_s_c_web_server_sign;
            this.SSCWebServerSign2 = s_s_c_web_server_sign2;
            this.PageUrl = pageUrl;
            this.HeaderAcao = headerAcao;
            this.Pingback = pingBack;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["key"] = Key,

                ["method"] = this.Methods,
                ["s_s_c_user_id	"] = this.SSCUserId,
                ["s_s_c_session_id"] = this.SSCSessionId,
                ["s_s_c_web_server_sign"] = this.SSCWebServerSign,
                ["s_s_c_web_server_sign2"] = this.SSCWebServerSign2,
                ["pageurl"] =this.PageUrl,
                ["header_acao"] =this.HeaderAcao.GetHashCode(),
                ["pingback"] =this.Pingback,

                ["json"] = Json.GetHashCode(),
                ["soft_id"] = SoftId,
            };
            return Converts.StringToDictionary(Data); ;
        }
    }
}
