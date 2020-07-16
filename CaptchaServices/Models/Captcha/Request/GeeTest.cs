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
    public class GeeTest : Setting
    {
        /// <summary>
        /// Значение параметра gt найденное на сайте
        /// </summary>
        public string Gt { get; set; }
        /// <summary>
        /// Значение параметра challenge найденное на сайте
        /// </summary>
        public string Challenge { get; set; }
        /// <summary>
        /// Значение параметра api_server найденное на сайте
        /// </summary>
        public string ApiServer { get; set; }
        /// <summary>
        /// Полный URL страницы с капчей GeeTest
        /// </summary>
        public string PageUrl { get; set; }

        /// <summary>
        /// GeeTest
        /// </summary>
        /// <param name="gt">Значение параметра gt найденное на сайте</param>
        /// <param name="challenge">Значение параметра challenge найденное на сайте</param>
        /// <param name="pageurl">Полный URL страницы с капчей GeeTest</param>
        public GeeTest(string gt, string challenge, string pageurl, string apiServer = null, bool headerAcao = false, string pingBack = null)
        {
            this.Methods = Method.GeeTest;
            this.Gt = gt;
            this.Challenge = challenge;
            this.PageUrl = pageurl;
            this.ApiServer = apiServer;
            this.HeaderAcao = headerAcao;
            this.Pingback = pingBack;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["key"] = Key,

                ["method"] = this.Methods,
                ["gt"] = this.Gt,
                ["challenge"] = this.Challenge,
                ["api_server"] = this.ApiServer,
                ["pageurl"] = this.PageUrl,
                ["header_acao"] = this.HeaderAcao.GetHashCode(),
                ["pingback"] = this.Pingback,

                ["json"] = Json.GetHashCode(),
                ["soft_id"] = SoftId,
            };
            return Converts.StringToDictionary(Data); ;
        }
    }
}
