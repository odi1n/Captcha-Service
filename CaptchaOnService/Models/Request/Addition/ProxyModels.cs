using Captcha_Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Request
{
    public class ProxyModels
    {
        public string Proxy { get; set; } 
        /// <summary>
        /// Тип вашего прокси-сервера: HTTP, HTTPS, SOCKS4, SOCKS5.
        /// </summary>
        public ProxyType? ProxyType { get; set; } 
    }
}
