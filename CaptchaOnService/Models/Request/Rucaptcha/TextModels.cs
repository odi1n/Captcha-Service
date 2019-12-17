using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Request.Rucaptcha
{
    public class TextModels : SettingModels
    {
        /// <summary>
        /// Текст капчи.
        /// </summary>
        public string TextCaptcha { get; set; }
    }
}
