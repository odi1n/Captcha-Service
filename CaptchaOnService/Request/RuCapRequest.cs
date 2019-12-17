using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Request
{
    partial class RuCapRequest
    {
        /// <summary>
        /// Переводим данные с байтов в текст
        /// </summary>
        /// <param name="request">Байт которые будем переводить в текст</param>
        /// <returns></returns>
        public  string ByteToString(WebRequest request)
        {
            using ( HttpWebResponse response = (HttpWebResponse)request.GetResponse() )
            using ( StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default, true, 8192) )
                return reader.ReadToEnd();
        }

        /// <summary>
        /// Отправить запросс 
        /// </summary>
        /// <param name="url">Ссылка по которой передаем параметры</param>
        /// <param name="data">Передаваемые параметры</param>
        /// <returns></returns>
        public string Get(string url, string data)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            using ( Stream dataStream = request.GetRequestStream() )
                dataStream.Write(byteArray, 0, byteArray.Length);

            WebResponse response = request.GetResponse();
            using ( Stream stream = response.GetResponseStream() )
            using ( StreamReader reader = new StreamReader(stream) )
                return reader.ReadToEnd();
        }
    }
}
