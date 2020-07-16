using Captcha_Service.Enums;
using Captcha_Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Captcha.Addition
{
    public class Setting : SetProxy
    {
        /// <summary>
        /// Ключ пользователя
        /// </summary>
        internal static string Key { get; set; }
        /// <summary>
        /// Софт id
        /// </summary>
        internal static int SoftId { get; set; }
        /// <summary>
        /// Получаем ли данные в json
        /// </summary>
        internal bool Json { get; set; } = true;
        /// <summary>
        /// Метод 
        /// </summary>
        internal string Methods { get; set; }

        /// <summary>
        /// 0 — не определено
        /// 1 — капча содержит только кириллицу
        /// 2 — капча содержит только латиницу
        /// </summary>
        public int Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
                if (_language > 2 && _language < 0)
                    throw new ErrorParamsException("Значение должно быть от 0 до 2");
            }
        }

        /// <summary>
        /// Код языка. 
        /// </summary>
        public Lang? Lang { get; set; }

        /// <summary>
        /// Текст будет показан работнику, чтобы помочь ему правильно решить капчу.
        /// </summary>
        public string TextInstructions { get; set; }

        /// <summary>
        /// 0 — выключен
        /// 1 — включен
        /// Если включен, то in.php добавит заголовок Access-Control-Allow-Origin:* в ответ.
        /// Используется для кроссдоменных AJAX-запросов из веб-приложений.
        /// </summary>
        public bool HeaderAcao { get; set; }

        /// <summary>
        /// URL для автоматической отправки ответа на капчу (callback).
        /// URL должен быть зарегистрирован на сервере.Больше информации здесь.
        /// </summary>
        public string Pingback { get; set; }

        private int _language;

        internal static void SettSetting(string key, int? softId)
        {
            Key = key;
            SoftId = softId.Value;
        }
    }
}
