using Captcha_Service.Addition;
using Captcha_Service.Enum.Rucaptcha;
using Captcha_Service.Exception.Rucaptcha;
using Captcha_Service.Models.Response.Rucaptcha;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Request
{
    partial class RucaptchaRequest
    {
        /// <summary>
        /// Переводим данные с байтов в текст
        /// </summary>
        /// <param name="request">Байт которые будем переводить в текст</param>
        /// <returns></returns>
        private  string ByteToString(WebRequest request)
        {
            using ( HttpWebResponse response = (HttpWebResponse)request.GetResponse() )
            using ( StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default, true, 8192) )
                return reader.ReadToEnd();
        }

        public bool DownloadFile(string link, string path)
        {
            bool CheckDownload = false;
            using ( WebClient Client = new WebClient() )
            {
                Client.DownloadFile(link, path);
                CheckDownload = true;
            }
            return CheckDownload;
        }

        public ResponseModels GetRequest(string url, Dictionary<string, object> data)
        {
            var request = WebRequest.Create(url + DictionaryConvert.Deserialization(data));
            var response = ByteToString(request);
            return CheckErrorInfo( response);
        }

        public ResponseModels UploadFile(string link, string path)
        {
            using(var webClient = new WebClient() )
            {
                var infoUpload = webClient.UploadFile(link, path);

                string response = Encoding.UTF8.GetString(infoUpload);

                return CheckErrorInfo(response);
            }
        }

        private ResponseModels CheckErrorInfo(string response)
        {
            var json = JsonConvert.Deserializ<ResponseModels>(response);
            if ( json.Status == 0 && json.Request != "CAPCHA_NOT_READY" )
                throw new ErrorParamsRucaptchaException(json.Request);
            else
                return json;
        }
    }
}
