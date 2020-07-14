using Captcha_Service.Additions;
using Captcha_Service.Enums;
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
        /// geetest - указывает, что вы отправляете капчу GeeTest
        /// </summary>
        public string Methods { get; private set; } = Method.GeeTest;
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
        public GeeTest(string gt, string challenge, string pageurl)
        {
            this.Gt = gt;
            this.Challenge = challenge;
            this.PageUrl = pageurl;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["method"] = this.Methods,
                ["gt"] = this.Gt,
                ["challenge"] = this.Challenge,
                ["api_server"] = this.ApiServer,
                ["pageurl"] = this.PageUrl,
                ["header_acao"] = this.HeaderAcao,
                ["pingback"] = this.Pingback,
            };
            return Converts.StringToDictionary(Data); ;
        }
    }
}
