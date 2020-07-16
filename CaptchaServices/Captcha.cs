using System;
using System.Net;
using System.IO;
using Captcha_Service;
using Captcha_Service.Additions;

namespace Captcha_Service
{
    /// <summary>
    /// Класс для работы с капчей
    /// </summary>
    public class Captcha
    {
        private static Request _request = new Request();
        private static string _pathFile
        {
            get
            {
                return $"captcha_{new Random().Next()}.jpg";
            }
        }

        /// <summary>
        /// Создать папку если ее нет
        /// </summary>
        /// <param name="DirectName"></param>
        private static void Create(string DirectName)
        {
            if (!Directory.Exists(DirectName))
                Directory.CreateDirectory(DirectName);
        }

        /// <summary>
        /// Сохранить картинку, получить путь на нее
        /// </summary>
        /// <param name="LinkImage">Ссылка на картинку, которую сохранить</param>
        /// <returns></returns>
        public static string DownloadImage(string linkImage)
        {
            bool CheckDownload = _request.Download(linkImage, _pathFile);

            if (!CheckDownload)
                return null;

            return _pathFile;
        }

        /// <summary>
        /// Сохранить картинку в указанную папку и получить путь на нее
        /// </summary>
        /// <param name="LinkImage">Ссылка на картинку, которую сохранить</param>
        /// <param name="PathSave">Папка для сохранения картинки, если папки нет, будет создана</param>
        /// <returns></returns>
        public static string DownloadImage(string linkImage, string pathSave)
        {
            Create(pathSave);
            string path = pathSave + "\\" + _pathFile;

            bool CheckDownload = _request.Download(linkImage, path);

            if (CheckDownload)
                return null;

            return path;
        }
    }
}
