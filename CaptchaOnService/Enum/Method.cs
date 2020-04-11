using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Enum
{
    public enum Method
    {
        /// <summary>
        /// Говорит о том, что вы отправляете изображение с помощью multipart-фомы
        /// </summary>
    post,
/// <summary>
        /// Говорит о том, что вы отправляете изображение в формате base64
        /// </summary>
        base64,
        /// <summary>
        /// Определяет, что вы решаете ReCaptcha V2 с помощью нового метода
        /// </summary>
        userrecaptcha,
    }
}
