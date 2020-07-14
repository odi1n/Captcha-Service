using Captcha_Service.Additions;
using Captcha_Service.Enums;
using Captcha_Service.Exceptions;
using Captcha_Service.Models;
using Captcha_Service.Models.Captcha;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Additions
{
    partial class Request
    {
        internal string Post(string url, string json)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                streamWriter.Write(json);

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }
        }

        internal bool DownloadFile(string link, string path)
        {
            bool CheckDownload = false;
            using ( WebClient Client = new WebClient() )
            {
                Client.DownloadFile(link, path);
                CheckDownload = true;
            }
            return CheckDownload;
        }

        internal Response GetRequest(string url, string data)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            var request = WebRequest.Create(url + data);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default, true, 8192))
                return CheckErrorInfo(reader.ReadToEnd());
        }

        internal Response UploadFile(string link, string path)
        {
            using(var webClient = new WebClient() )
            {
                var infoUpload = webClient.UploadFile(link, path);
                string response = Encoding.UTF8.GetString(infoUpload);

                return CheckErrorInfo(response);
            }
        }

        private Response CheckErrorInfo(string response)
        {
            var json = JsonConverts.Deserializ<Response>(response);
            if ( json.Status == false && json.Request != "CAPCHA_NOT_READY" )
                throw new ErrorParamsException(json.Request);
            else
                return json;
        }
    }
}
