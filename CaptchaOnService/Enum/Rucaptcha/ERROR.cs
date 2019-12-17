using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Enum.Rucaptcha
{
    public enum ERROR
    {
        /// <summary>
        /// Ошибка проверьте свой ключ
        /// </summary>
        KEY,
        /// <summary>
        /// Ошибка в получении данных
        /// </summary>
        DATA,
        /// <summary>
        /// Ошибка, проверьте путь картинки
        /// </summary>
        IMAGEPATH,
        /// <summary>
        /// Ошибка, проверьте текст
        /// </summary>
        TEXT,
        /// <summary>
        /// Ошибка, Гугл ключ не указан
        /// </summary>
        GOOGLEKEY,
        /// <summary>
        /// Ошибка, Ссылка на страницу не указана
        /// </summary>
        PAGEURL,
        /// <summary>
        /// Ошибка, Версия не указана
        /// </summary>
        VERSION,
        /// <summary>
        /// Ошибка, Метод не указан
        /// </summary>
        METHOD,
        /// <summary>
        /// Success равен 0
        /// </summary>
        SUCCESS,
    }
}
