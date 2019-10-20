using System;
using System.Net;
using System.IO;

namespace Captcha_Service
{
    /// <summary>
    /// Класс для работы с капчей
    /// </summary>
    public class Captcha
    {
        private static Captcha captcha = new Captcha();

        /// <summary>
        /// Сохранить картинку, получить путь на нее
        /// </summary>
        /// <param name="LinkImage">Ссылка на картинку, которую сохранить</param>
        /// <returns></returns>
        public static string DownloadImage(string LinkImage)
        {
            Random random = new Random();
            string pathFile = "captcha_" + random.Next().ToString() + ".jpg";

            using (WebClient Client = new WebClient())
            {
                Client.DownloadFile(LinkImage, pathFile);
            }

            return pathFile;
        }

        /// <summary>
        /// Сохранить картинку в папку и получить путь на нее
        /// </summary>
        /// <param name="LinkImage">Ссылка на картинку, которую сохранить</param>
        /// <param name="PathSave">Папка для сохранения картинки, если папки нет, будет создана</param>
        /// <returns></returns>
        public static string DownloadImage(string LinkImage, string PathSave)
        {
            Random random = new Random();
            captcha.DirectCreate(PathSave);

            string pathFile = PathSave + "\\captcha_" + random.Next().ToString() + ".jpg";

            using (WebClient Client = new WebClient())
            {
                Client.DownloadFile(LinkImage, pathFile);
            }

            return pathFile;
        }

        /// <summary>
        /// Создать папку если ее нет
        /// </summary>
        /// <param name="DirectName"></param>
        private void DirectCreate(string DirectName)
        {
            if (!Directory.Exists(DirectName))
                Directory.CreateDirectory(DirectName);
        }
    }
}
