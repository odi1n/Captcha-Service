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
using System.Net.Http;
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

        internal Response Get(string url, string data)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            var request = WebRequest.Create(url + data);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default, true, 8192))
                return CheckErrorInfo(reader.ReadToEnd());
        }

        internal bool Download(string link, string pathFile)
        {
            bool CheckDownload = false;
            using ( WebClient Client = new WebClient() )
            {
                Client.DownloadFile(link, pathFile);
                CheckDownload = true;
            }
            return CheckDownload;
        }

        internal Response Upload(string link, string pathFile)
        {
            using (var webClient = new WebClient())
            {
                var infoUpload = webClient.UploadFile(link, pathFile);
                string response = Encoding.UTF8.GetString(infoUpload);

                return CheckErrorInfo(response);
            }
        }

        internal string PostMultipart(string url, Dictionary<string, object> postParameters)
        {
            HttpWebResponse webResponse = FormUpload.MultipartFormDataPost(url, postParameters);
            StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
            string fullResponse = responseReader.ReadToEnd();
            webResponse.Close();
            return fullResponse;
        }

        internal Response FormData(string url, string data)
        {
            return CheckErrorInfo(Post(url, data));
        }

        internal Response Multipart(string url, Dictionary<string, object> data)
        {
            return CheckErrorInfo(PostMultipart(url, data));
        }

        private Response CheckErrorInfo(string response)
        {
            var json = Converts.JsonDeserializ<Response>(response);
            if ( json.Status == false && json.Request != "CAPCHA_NOT_READY" )
                throw new ErrorParamsException(json.Request);
            else
                return json;
        }
    }
    
}
