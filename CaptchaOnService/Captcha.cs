using System;
using System.Net;
using System.IO;
using Captcha_Service.Rucaptcha;
using Captcha_Service.File;
namespace Captcha_Service
{
    /// <summary>
    /// Класс для работы с капчей
    /// </summary>
    public class Captcha
    {
        /// <summary>
        /// Для работы с сохранением
        /// </summary>
        static Direct Directorys = new Direct();
        /// <summary>
        /// Для сохранения файла
        /// </summary>
        static CaptchaRequest capReq = new CaptchaRequest();
        /// <summary>
        /// Путь к файлу
        /// </summary>
        static string PathFile
        {
            get
            {
                return $"captcha_{new Random().Next()}.jpg";
            }
        }

        /// <summary>
        /// Сохранить картинку, получить путь на нее
        /// </summary>
        /// <param name="LinkImage">Ссылка на картинку, которую сохранить</param>
        /// <returns></returns>
        public static string DownloadImage(string LinkImage)
        {
            bool CheckDownload = capReq.DownloadFile(LinkImage, PathFile);
            if ( CheckDownload )
                return PathFile;
            else
                return null;
        }

        /// <summary>
        /// Сохранить картинку в указанную папку и получить путь на нее
        /// </summary>
        /// <param name="LinkImage">Ссылка на картинку, которую сохранить</param>
        /// <param name="PathSave">Папка для сохранения картинки, если папки нет, будет создана</param>
        /// <returns></returns>
        public static string DownloadImage(string LinkImage, string PathSave)
        {
            Directorys.Create(PathSave);
            string path = PathSave + "\\" + PathFile;

            bool CheckDownload = capReq.DownloadFile(LinkImage, path);
            if ( CheckDownload )
                return path;
            return null;
        }
    }
}
