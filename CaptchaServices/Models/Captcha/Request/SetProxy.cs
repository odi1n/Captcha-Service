using Captcha_Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Captcha.Request
{
    public class SetProxy
    {
        public string Proxy { get; set; } 
        /// <summary>
        /// Тип вашего прокси-сервера: HTTP, HTTPS, SOCKS4, SOCKS5.
        /// </summary>
        public ProxyType? ProxyType { get; set; } 
    }
}
