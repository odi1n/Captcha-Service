using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Enum.Rucaptcha
{
    public enum METHOD
    {
        /// <summary>
        /// Говорит о том, что вы отправляете изображение с помощью multipart-фомы
        /// </summary>
        POST,
        /// <summary>
        /// Говорит о том, что вы отправляете изображение в формате base64
        /// </summary>
        BASE64,
        /// <summary>
        /// Определяет, что вы решаете ReCaptcha V2 с помощью нового метода
        /// </summary>
        USERRECAPTCHA,
    }
}
