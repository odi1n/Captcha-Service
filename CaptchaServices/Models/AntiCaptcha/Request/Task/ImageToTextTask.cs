using Captcha_Service.Additions;
using Captcha_Service.Exceptions;
using Captcha_Service.Models.AntiCaptcha.Request.Addition;
using Captcha_Service.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Request.Task
{
    [DataContract]
    [KnownType(typeof(Task.ImageToTextTask))]
    public class ImageToTextTask : Setting
    {
        [DataMember(Name = "typE")]
        public string Type { get; set; }
        [DataMember(Name = "body")]
        public string Body { get; set; }
        [DataMember(Name = "phrase")]
        public bool Phrase { get; set; }
        [DataMember(Name = "case")]
        public bool Case { get; set; }
        [DataMember(Name = "numeric")]
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
        [DataMember(Name = "math")]
        public bool Math { get; set; }
        [DataMember(Name = "minLength")]
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
        [DataMember(Name = "maxLength")]
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
        [DataMember(Name = "comment")]
        public string Comment { get; set; }
        [DataMember(Name = "websiteURL")]
        public string WebsiteURL { get; set; }

        private int _minLength;
        public int _maxLength;

        public ImageToTextTask(string body)
        {
            //this.Type = ACType.ImageToTextTask;
            this.Type = "ImageToTextTask";
            this.Body = body;
        }

        public override string ToString()
        {
            return JsonConvert.Serializer(this);
        }
    }
}
