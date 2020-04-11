using Captcha_Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Rucaptcha.Request
{
    public class SettingModels : ProxyModels
    {
        /// <summary>
        /// 0 — не определено
        /// 1 — капча содержит только кириллицу
        /// 2 — капча содержит только латиницу
        /// </summary>
        public int? Language { get; set; }
        /// <summary>
        /// Код языка. 
        /// </summary>
        public Lang? Lang { get; set; }
        /// <summary>
        /// 0 — выключен
        /// 1 — включен
        /// Если включен, то in.php добавит заголовок Access-Control-Allow-Origin:* в ответ.
        /// Используется для кроссдоменных AJAX-запросов из веб-приложений.
        /// </summary>
        public int? HeaderAcao { get; set; }
        /// <summary>
        /// URL для автоматической отправки ответа на капчу (callback).
        /// URL должен быть зарегистрирован на сервере.Больше информации здесь.
        /// </summary>
        public string Pingback { get; set; }
    }
}
