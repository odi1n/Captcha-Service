using Captcha_Service.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Request
{
    public class RecaptchaV3
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("websiteURL")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("websiteKey")]
        public string WebsiteKey { get; set; }

        [JsonProperty("minScore")]
        public double MinScore { get; set; }

        [JsonProperty("pageAction")]
        public string PageAction { get; set; }

        public RecaptchaV3(string websiteURL, string websiteKey, double minScore)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            this.Type = Method.RecaptchaV3TaskProxyless;
            this.WebsiteUrl = websiteURL;
            this.WebsiteKey = websiteKey;
            this.MinScore = minScore;
        }
    }
}
