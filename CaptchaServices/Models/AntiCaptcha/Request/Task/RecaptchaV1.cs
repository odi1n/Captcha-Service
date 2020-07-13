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
    public class RecaptchaV1
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("websiteURL")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("websiteKey")]
        public string WebsiteKey { get; set; }

        [JsonProperty("proxyType")]
        public ProxyType ProxyType { get; set; }

        [JsonProperty("proxyAddress")]
        public string ProxyAddress { get; set; }

        [JsonProperty("proxyPort")]
        public int ProxyPort { get; set; }

        [JsonProperty("proxyLogin")]
        public string ProxyLogin { get; set; }

        [JsonProperty("proxyPassword")]
        public string ProxyPassword { get; set; }

        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }

        [JsonProperty("cookies")]
        public string Cookies { get; set; }

        public RecaptchaV1(string websiteURL, string websiteKey)
        {
            this.Type = ACTask.RecaptchaV1TaskProxyless;
            this.WebsiteUrl = websiteURL;
            this.WebsiteKey = websiteKey;
        }

        public RecaptchaV1(string websiteURL, string websiteKey, ProxyType proxyType, string proxyAddress, int proxyPort, string userAgent)
        {
            this.Type = ACTask.RecaptchaV1Task;
            this.WebsiteUrl = websiteURL;
            this.WebsiteKey = websiteKey;
            this.ProxyType = proxyType;
            this.ProxyAddress = proxyAddress;
            this.ProxyPort = proxyPort;
            this.UserAgent = userAgent;
        }
    }
}
