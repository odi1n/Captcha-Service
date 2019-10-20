using System.IO;
using System.Net;
using System.Text;

namespace Captcha_Service.Rucaptcha.wRucaptcha
{
    /// <summary>
    /// Класс с дополнительными функциями
    /// </summary>
    partial class Additional
    {
        /// <summary>
        /// Переводим данные с байтов в текст
        /// </summary>
        /// <param name="request">Байт которые будем переводить в текст</param>
        /// <returns></returns>
        public static string ByteToString(WebRequest request)
        {
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default, true, 8192))
                return reader.ReadToEnd();
        }
    }
}
