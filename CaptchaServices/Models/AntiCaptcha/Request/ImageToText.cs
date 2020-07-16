using Captcha_Service.Additions;
using Captcha_Service.Enums;
using Captcha_Service.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Request
{
    public class ImageToText
    {
        [JsonProperty("type")]
        public string Type { get; private set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonProperty("phrase")]
        public bool Phrase { get; set; }
        [JsonProperty("case")]
        public bool Case { get; set; }
        [JsonProperty("numeric")]
        public int Numeric
        {
            get
            {
                return _minLength;
            }
            set
            {
                if (value > 2 || value < 0)
                    throw new ErrorParamsException("Должно быть указано значение в рамках, от 0 до 20");
                _minLength = value;
            }
        }
        [JsonProperty("math")]
        public bool Math { get; set; }
        [JsonProperty("minLength")]
        public int MinLength
        {
            get
            {
                return _minLength;
            }
            set
            {
                if (value > 20 || value < 0)
                    throw new ErrorParamsException("Должно быть указано значение в рамках, от 0 до 20");
                _minLength = value;
            }
        }
        [JsonProperty("maxLength")]
        public int MaxLength
        {
            get
            {
                return _maxLength;
            }
            set
            {
                if (value > 20 || value < 0)
                    throw new ErrorParamsException("Должно быть указано значение в рамках, от 0 до 20");
                _maxLength = value;
            }
        }
        [JsonProperty("comment")]
        public string Comment { get; set; }
        [JsonProperty("websiteURL")]
        public string WebsiteURL { get; set; }

        [NonSerialized]
        private int _minLength;
        [NonSerialized]
        public int _maxLength;

        public ImageToText(Decode decode)
        {
            this.Type = Method.ImageToTextTask;
            this.Body = decode.ToString();
        }
    }
}
