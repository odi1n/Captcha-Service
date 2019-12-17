using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Rucaptcha
{
    partial class CaptchaRequest
    {
        public bool DownloadFile(string Image, String Path)
        {
            bool CheckDownload = false;
            using ( WebClient Client = new WebClient() )
            {
                Client.DownloadFile(Image, Path);
                CheckDownload= true;
            }
            return CheckDownload;
        }
    }
}
