using Captcha_Service.Additions;
using Captcha_Service.Enums;
using Captcha_Service.Models.Captcha.Addition;
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
        /// 1 — По умолчанию. говорит о том, что вы отправляете ReCaptcha в виде изображения
        /// </summary>
        public int Recaptcha { get; set; }
        /// <summary>
        /// По умолчанию 0. 1 — говорит о том, что вы хотите использовать метод canvas
        /// </summary>
        public bool Canvas { get; set; }
        /// <summary>
        /// Путь картинки
        /// </summary>
        internal string Body { get; set; }

        /// <summary>
        /// Количество строк в сетке.
        /// </summary>
        public int RecaptchaRows { get; set; }
        /// <summary>
        /// Количество колонок в сетке.
        /// </summary>
        public int RecaptchaCols { get; set; }
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
        public bool CanNoAnswer { get; set; } 

        public ReCaptchaV2Old(Decode decode, string textinstructions, bool canvas = false, int? recaptcharows = null, int? recaptchacols = null, string previousID = null,
            bool canNoAnswer = false, int language =0, Lang? lang = null,  bool headerAcao = false, string pingback = null)
        {
            this.Methods = Method.Base64;
            this.Recaptcha = 1;
            this.Canvas = canvas;
            this.Body = decode.ToString();
            this.TextInstructions = textinstructions;
            this.RecaptchaRows = recaptcharows.Value;
            this.RecaptchaCols = recaptchacols.Value;
            this.PreviousID = previousID;
            this.CanNoAnswer = canNoAnswer;
            this.Language = language;
            this.Lang = lang;
            this.HeaderAcao = headerAcao;
            this.Pingback = pingback;
        }

        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>()
            {
                ["key"] = Key,

                ["method"] = this.Methods,
                ["body"] = this.Body,
                ["recaptcha"] = this.Recaptcha,
                ["canvas"] = this.Canvas.GetHashCode(),
                ["recaptcharows"] = this.RecaptchaRows,
                ["recaptchacols"] = this.RecaptchaCols,
                ["previousID"] = this.PreviousID,
                ["can_no_answer"] = this.CanNoAnswer.GetHashCode(),
                ["language"] = this.Language,
                ["lang"] = this.Lang,
                ["header_acao"] = this.HeaderAcao.GetHashCode(),
                ["pingback"] = this.Pingback,

                ["json"] = Json.GetHashCode(),
                ["soft_id"] = SoftId,
            };
        }

        public override string ToString()
        {
            return Converts.StringToDictionary(this.ToDictionary());
        }
    }
}
