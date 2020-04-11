using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models
{
    public class ResponseModels
    {
        /// <summary>
        /// Информация успешен ли ответ, 0 - нет, 1 - да
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Ответ
        /// </summary>
        public string Request { get; set; }
    }
}
