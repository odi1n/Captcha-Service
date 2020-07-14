using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Captcha
{
    public class Response
    {
        /// <summary>
        /// Информация успешен ли ответ, 0 - нет, 1 - да
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// Ответ
        /// </summary>
        public string Request { get; set; }
        /// <summary>
        /// Выполненная задача
        /// </summary>
        public Check Check { get; set; }
    }
}
