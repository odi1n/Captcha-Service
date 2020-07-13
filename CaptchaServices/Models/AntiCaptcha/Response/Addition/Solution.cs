using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.ACResponse.Addition
{
    public class Solution
    {
        [JsonProperty( "text")]
        public string Text { get; set; }

        [JsonProperty( "url")]
        public string Url { get; set; }

        [JsonProperty("gRecaptchaResponse")]
        public string GRecaptchaResponse { get; set; }

        [JsonProperty("gRecaptchaResponseMD5")]
        public string GRecaptchaResponseMD5 { get; set; }

        [JsonProperty("cookies")]
        public Dictionary<string, object> Cookies { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("cellNumbers")]
        public List<long> CellNumbers { get; set; }

        [JsonProperty("challenge")]
        public string Challenge { get; set; }

        [JsonProperty("validate")]
        public string Validate { get; set; }

        [JsonProperty("seccode")]
        public string Seccode { get; set; }

        [JsonProperty("recaptchaChallenge")]
        public string RecaptchaChallenge { get; set; }

        [JsonProperty("recaptchaResponse")]
        public string RecaptchaResponse { get; set; }
    }
}
