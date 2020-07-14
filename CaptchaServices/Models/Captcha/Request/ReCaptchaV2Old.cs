using Captcha_Service.Additions;
using Captcha_Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Captcha.Request
{
    public class ReCaptchaV2Old : Setting
    {
        /// <summary>
        /// Путь картинки
        /// </summary>
        public string File { get; set; }
        /// <summary>
        /// 1 — По умолчанию. говорит о том, что вы отправляете ReCaptcha в виде изображения
        /// </summary>
        public int Recaptcha { get; set; } = 1;
        /// <summary>
        /// По умолчанию 0. 1 — говорит о том, что вы хотите использовать метод canvas
        /// </summary>
        public int Canvas { get; set; } = 0;
        /// <summary>
        /// Количество строк в сетке.
        /// </summary>
        public int? RecaptchaRows { get; set; }
        /// <summary>
        /// Количество колонок в сетке.

        /// </summary>
        public int? RecaptchaCols { get; set; }
        /// <summary>
        /// Id вашего предыдущего запроса в рамках того же задания ReCaptcha
        /// </summary>
        public string PreviousID { get; set; }
        /// <summary>
        /// 0 — не определено
        /// 1 — возможно, что изображение не содержит картинок, которые удовлетворяют инструкции.
        /// Устанавливайте значение 1 только если на изображении может не быть картинок с правильным ответом.
        /// Мы покажем работнику кнопку "Нет подходящих картинок", а вы получите в ответе No_matching_images.
        /// </summary>
        public int CanNoAnswer { get; set; } = 0;
        public string Methods { get; private set; } = Method.Post;

        public ReCaptchaV2Old(string file, string textinstructions)
        {
            this.TextInstructions = textinstructions;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["method"] = this.Methods,
                ["recaptcha"] = this.Recaptcha,
                ["canvas"] = this.Canvas,
                ["textinstructions"] = this.TextInstructions,
                ["imginstructions"] = this.Imginstructions,
                ["recaptcharows"] = this.RecaptchaRows,
                ["recaptchacols"] = this.RecaptchaCols,
                ["previousID"] = this.PreviousID,
                ["can_no_answer"] = this.CanNoAnswer,
                ["language"] = this.Language,
                ["lang"] = this.Lang,
                ["header_acao"] = this.HeaderAcao,
                ["pingback"] = this.Pingback,
            };

            return Converts.StringToDictionary(Data);
        }
    }
}
