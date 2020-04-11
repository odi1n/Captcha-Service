using System;
using System.Net;
using System.IO;
using Captcha_Service.Rucaptcha;
using Captcha_Service.Query;

namespace Captcha_Service
{
    /// <summary>
    /// Класс для работы с капчей
    /// </summary>
    public class Captcha
    {
        private static Request _capReq = new Request();
        private static string _pathFile
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
        public static string DownloadImage(string linkImage)
        {
            bool CheckDownload = _capReq.DownloadFile(linkImage, _pathFile);
            if ( CheckDownload ) return _pathFile;
            return null;
        }

        /// <summary>
        /// Сохранить картинку в указанную папку и получить путь на нее
        /// </summary>
        /// <param name="LinkImage">Ссылка на картинку, которую сохранить</param>
        /// <param name="PathSave">Папка для сохранения картинки, если папки нет, будет создана</param>
        /// <returns></returns>
        public static string DownloadImage(string linkImage, string pathSave)
        {
            Addition.Directorys.Create(pathSave);
            string path = pathSave + "\\" + _pathFile;

            bool CheckDownload = _capReq.DownloadFile(linkImage, path);
            if ( CheckDownload ) return path;
            return null;
        }
    }
}
