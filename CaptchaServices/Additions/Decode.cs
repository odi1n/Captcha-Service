using Captcha_Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service
{
    public class Decode
    {
        /// <summary>
        /// Декодированная картинка
        /// </summary>
        internal string Base64 { get; private set; }

        /// <summary>
        /// Метод для декодирования фото. Задать готовый base64
        /// </summary>
        public Decode() { }

        /// <summary>
        /// Метод декодирования фотографии
        /// </summary>
        /// <param name="pathPhoto">Передать путь к картинке</param>
        public Decode(string pathPhoto)
        {
            this.Base64 = Converts.ImageToBase64(File.ReadAllBytes(pathPhoto));
        }

        /// <summary>
        /// Метод декодирования фотографии
        /// </summary>
        /// <param name="fileInfo">Передать путь к фотографии</param>
        public Decode(FileInfo fileInfo)
        {
            this.Base64 = Converts.ImageToBase64(File.ReadAllBytes(fileInfo.FullName));
        }

        /// <summary>
        /// Метод декодирования фотографии
        /// </summary>
        /// <param name="stream">Для конвертации в base64</param>
        public Decode(Stream stream)
        {
            this.Base64 = Converts.ImageToBase64(Converts.StreamToByte(stream));
        }

        /// <summary>
        /// Метод декодирования фотографии
        /// </summary>
        /// <param name="memoryStream">Для конвертации в base64</param>
        public Decode(MemoryStream memoryStream)
        {
            this.Base64 = Converts.ImageToBase64(Converts.MemoryStreamToByte(memoryStream));
        }

        /// <summary>
        /// Метод декодирования фотографии
        /// </summary>
        /// <param name="streamReader">Для конвертации в base64</param>
        public Decode(StreamReader streamReader)
        {
            byte[] bytes = streamReader.CurrentEncoding.GetBytes(streamReader.ReadToEnd());
            this.Base64 = Converts.ImageToBase64(bytes);
        }

        /// <summary>
        /// Метод декодирования фотографии
        /// </summary>
        /// <param name="fileStream">Для конвертации в base64</param>
        public Decode(FileStream fileStream)
        {
            this.Base64 = Converts.ImageToBase64(Converts.FileStreamToByte(fileStream));
        }

        /// <summary>
        /// Метод декодирования фотографии
        /// </summary>
        /// <param name="uri">Передать ссылку на фото</param>
        public Decode(Uri uri)
        {
            this.Base64 = Converts.UriToByte(uri);
        }

        /// <summary>
        /// Метод декодирования фотографии
        /// </summary>
        /// <param name="bytes">Передать байты картинки</param>
        public Decode(byte[] bytes)
        {
            this.Base64 = Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Задать готовый base64
        /// </summary>
        /// <param name="base64">Указать base64</param>
        /// <returns></returns>
        public string SetBase64(string base64)
        {
            this.Base64 = base64;
            return base64;
        }

        public override string ToString()
        {
            return Base64;
        }
    }
}
