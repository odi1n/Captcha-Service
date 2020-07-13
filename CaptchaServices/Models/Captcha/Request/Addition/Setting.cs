using Captcha_Service.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Request
{
    public class Setting : SetProxy
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
        public int HeaderAcao { get; set; } = 0;
        /// <summary>
        /// URL для автоматической отправки ответа на капчу (callback).
        /// URL должен быть зарегистрирован на сервере.Больше информации здесь.
        /// </summary>
        public string Pingback { get; set; }

        /// <summary>
        /// Текст будет показан работнику, чтобы помочь ему правильно решить капчу.
        /// Например: введите только красные буквы.
        /// </summary>
        public string TextInstructions { get; set; }
        /// <summary>
        /// Изображение будет показано работнику, чтобы помочь ему решить капчу правильно.
        /// Сервер принимает изображения в формате multipart или base64.
        /// </summary>
        public Image Imginstructions { get; set; }
    }
}
