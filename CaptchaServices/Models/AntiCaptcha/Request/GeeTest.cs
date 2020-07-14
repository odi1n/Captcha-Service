using Captcha_Service.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Request
{
    public class GeeTest
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("websiteURL")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("gt")]
        public string Gt { get; set; }

        [JsonProperty("challenge")]
        public string Challenge { get; set; }

        [JsonProperty("geetestApiServerSubdomain")]
        public string GeetestApiServerSubdomain { get; set; }

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

        public GeeTest(string websiteURL, string gt, string challenge)
        {
            this.Type = Method.GeeTestTaskProxyless;
            this.WebsiteUrl = websiteURL;
            this.Gt = gt;
            this.Challenge = challenge;
        }

        public GeeTest(string websiteURL, string gt, string challenge, ProxyType proxyType, string proxyAddress, int proxyPort, string userAgent)
        {
            this.Type = Method.GeeTestTask;
            this.WebsiteUrl = websiteURL;
            this.Gt = gt;
            this.Challenge = challenge;
            this.ProxyType = proxyType;
            this.ProxyAddress = proxyAddress;
            this.ProxyPort = proxyPort;
            this.UserAgent = userAgent;
        }
    }
}
