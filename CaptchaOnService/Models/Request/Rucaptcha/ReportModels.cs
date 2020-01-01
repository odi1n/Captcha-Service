using Captcha_Service.Enum.Rucaptcha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Captcha_Service.Models.Request.Rucaptcha
{
    public class ReportModels
    {
        /// <summary>
        /// Указан по умолчанию
        /// get — получить ответ на капчу
        /// </summary>
        public Actions Action { get; set; } = Enum.Rucaptcha.Actions.GET;
        /// <summary>
        /// ID капчи, полученный от in.php.
        /// </summary>
        public string Id { get; set; }
    }
}
