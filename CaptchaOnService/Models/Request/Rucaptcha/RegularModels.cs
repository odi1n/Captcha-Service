using Captcha_Service.Enum.Rucaptcha;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Request.Rucaptcha
{
    public class RegularModels : SettingModels
    {
        /// <summary>
        /// Путь картинки
        /// </summary>
        public string ImapePath { get; set; }
        /// <summary>
        /// Метод загрузки фото
        /// </summary>
        public Method Method { get; set; }
        /// <summary>
        /// 0 — капча состоит из одного слова
        /// 1 — капча состоит из двух или более слов
        /// </summary>
        public int? Phrase { get; set; }
        /// <summary>
        /// 0 — капча не чувствительна к регистру
        /// 1 — капча чувствительна к регистру
        /// </summary>
        public int? Regsense { get; set; }
        /// <summary>
        /// 0 — не определено
        /// 1 — капча состоит только из цифр
        /// 2 — капча состоит только из букв
        /// 3 — капча состоит либо только из букв, либо только из цифр
        /// 4 — в капче могут быть и буквы, и цифры
        /// </summary>
        public int? Numeric { get; set; }
        /// <summary>
        /// 0 — не определено
        /// 1 — капча требует совершения математического действия(например: напишите результат 4 + 8 = )
        /// </summary>
        public int? Calc { get; set; }
        /// <summary>
        /// 0 — не определено
        /// 1..20 — минимальное количетсво символов в ответе
        /// </summary>
        public int? MinLen { get; set; }
        /// <summary>
        /// 0 — не определено
        /// 1..20 — максимальное количетсво символов в ответе
        /// </summary>
        public int? MaxLen { get; set; }

        /// <summary>
        /// Текст будет показан работнику, чтобы помочь ему правильно решить капчу.
        /// Например: введите только красные буквы.
        /// </summary>
        public string Textinstructions { get; set; }
        /// <summary>
        /// Изображение будет показано работнику, чтобы помочь ему решить капчу правильно.
        /// Сервер принимает изображения в формате multipart или base64.
        /// </summary>
        public Image Imginstructions { get; set; }
    }
}
