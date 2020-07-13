using Captcha_Service.Enums;
using Captcha_Service.Task;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Request.Task
{
    public class FunCaptcha
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("websiteURL")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("funcaptchaApiJSSubdomain")]
        public string FuncaptchaApiJsSubdomain { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("websitePublicKey")]
        public string WebsitePublicKey { get; set; }

        [JsonProperty("proxyType")]
        public ProxyType ProxyType { get; set; }

        [JsonProperty("proxyAddress")]
        public string ProxyAddress { get; set; }

        [JsonProperty("proxyPort")]
        public long ProxyPort { get; set; }

        [JsonProperty("proxyLogin")]
        public string ProxyLogin { get; set; }

        [JsonProperty("proxyPassword")]
        public string ProxyPassword { get; set; }

        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }

        [JsonProperty("cookies")]
        public string Cookies { get; set; }

        public FunCaptcha(string websiteURL, string websitePublicKey)
        {
            this.Type = ACTask.FunCaptchaTaskProxyless;
            this.WebsiteUrl = websiteURL;
            this.WebsitePublicKey = websitePublicKey;
        }

        public FunCaptcha(string websiteURL, string websitePublicKey, ProxyType proxyType, string proxyAddress, int proxyPort, string userAgent)
        {
            this.Type = ACTask.FunCaptchaTask;
            this.WebsiteUrl = websiteURL;
            this.WebsitePublicKey = websitePublicKey;
            this.ProxyType = proxyType;
            this.ProxyAddress = proxyAddress ;
            this.ProxyPort = proxyPort;
            this.UserAgent = userAgent;
        }
    }
}
