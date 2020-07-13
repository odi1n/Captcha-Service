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
    public class NoCaptcha
    {
        [JsonProperty("type")]
        public string Type { get; private set; }

        [JsonProperty("websiteURL")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("websiteKey")]
        public string WebsiteKey { get; set; }

        [JsonProperty("websiteSToken")]
        public string WebsiteSToken { get; set; }

        [JsonProperty("recaptchaDataSValue")]
        public string RecaptchaDataSValue { get; set; }

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

        [JsonProperty("isInvisible")]
        public bool IsInvisible { get; set; }

        /// <summary>
        /// Решение капчи Google без прокси
        /// </summary>
        /// <param name="websiteURL">Адрес страницы на которой решается капча</param>
        /// <param name="websiteKey">Ключ-индентификатор рекапчи на целевой странице.</param>
        public NoCaptcha(string websiteURL, string websiteKey)
        {
            this.Type = ACTask.NoCaptchaTaskProxyless;
            this.WebsiteUrl = websiteURL;
            this.WebsiteKey = websiteKey;
        }

        /// <summary>
        /// Решение капчи Google с прокси
        /// </summary>
        /// <param name="websiteURL">Адрес страницы на которой решается капча</param>
        /// <param name="websiteKey">Ключ-индентификатор рекапчи на целевой странице.</param>
        /// <param name="proxyType">Тип прокси</param>
        /// <param name="proxyAddress">IP адрес прокси ipv4/ipv6. Не допускается:</param>
        /// <param name="proxyPort">Порт прокси</param>
        /// <param name="userAgent">User-Agent браузера, используемый в эмуляции.</param>
        public NoCaptcha(string websiteURL, string websiteKey, ProxyType proxyType, string proxyAddress,  int proxyPort, string userAgent)
        {
            this.Type = ACTask.NoCaptchaTask;
            this.WebsiteUrl = websiteURL;
            this.WebsiteKey = websiteKey;
            this.ProxyAddress = proxyAddress;
            this.ProxyType = proxyType;
            this.ProxyPort = proxyPort;
            this.UserAgent = userAgent;
        }
    }
}
