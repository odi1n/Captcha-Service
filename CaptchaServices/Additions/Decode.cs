using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service
{
    public class Decode
    {
        public static string ToBase64String(string ImagePath)
        {
            Image image = Image.FromFile(ImagePath);
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] bate = memoryStream.ToArray();
            string base64 = Convert.ToBase64String(bate);
            return base64;
        }
    }
}
