using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Captcha_Service.Rucaptcha.ReqModels;

namespace Captcha_Service.Rucaptcha
{
    /// <summary>
    /// Класс для работы с сервисом Rucaptcha.com
    /// </summary>
    public class Rucaptcha
    {
        private wRucaptcha.Query Query;
        /// <summary>
        /// Ключ от сервиса
        /// </summary>
        public string Key { get; set; }

        public Rucaptcha(string Key)
        {
            this.Key = Key;
            Query = new wRucaptcha.Query(Key);
        }

        /// <summary>
        /// Узнать баланс пользователя
        /// </summary>
        /// <param name="json">Получать ли данные в json. false - получить обычно, true - получить в json</param>
        /// <returns></returns>
        public string GetBalance(GetBalance data)
        {
            if ( Key == null )
                return "Проверьте ключ";
            else
            {
                if(data.Key == null)
                    data.Key = Key;
                return Query.GetBalanceByte(data);
            }
        }

        /// <summary>
        /// Решить обычную капчу(картинка)
        /// </summary>
        /// <returns></returns>
        public string Regular(Regular regular)
        {
            if ( Key == null )
                return "Проверьте ключ";
            else if ( regular.Imape_path == null )
                return "Проверьте путь к картинке";
            else
            {
                string DowloadImage = Query.RegularUpload( regular);
                if ( DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11 )
                {
                    return Query.Check(Key, DowloadImage, regular.Sleep, regular.Json);
                }
                return DowloadImage;
            }
        }

        /// <summary>
        /// Решить текст капчу
        /// </summary>
        /// <returns></returns>
        public string Text(Texts text)
        {
            if ( Key == null )
                return "Нет ключа";
            else if ( text.Text_captcha == null )
                return "Проверьте указана ли капча";
            else
            {
                string DowloadImage = Query.TextUpload(text.Text_captcha);
                if ( DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11 )
                {
                    return Query.Check(Key, DowloadImage, text.Sleep, text.Json);
                }
                return DowloadImage;
            }
        }

        /// <summary>
        /// Решить капчу ReCaptcha V2
        /// </summary>
        /// <returns></returns>
        public string ReCaptcha_V2(ReCaptcha_V2 recaptcha)
        {
            if ( Key == null )
                return "Проверьте ключ";
            else if(recaptcha.Google_key == null)
                return "Проверьте указан ли гугл ключ";
            else if(recaptcha.Page_url == null)
                return "Проверьте указана ли страница";
            {
                string DowloadImage = Query.ReCaptcha_V2_Upload(recaptcha);
                if ( DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11 )
                {
                    return Query.Check(Key, DowloadImage, recaptcha.Sleep, recaptcha.Json);
                }
                return DowloadImage;
            }
        }

        /// <summary>
        /// Решить капчу ReCaptcha V3
        /// </summary>
        /// <returns></returns>
        public string ReCaptcha_V3(ReCaptcha_V3 recaptcha)
        {
            if ( Key == null )
                return "Проверьте ключ";
            else if ( recaptcha.Google_key == null )
                return "Проверьте указан ли гугл ключ";
            else if ( recaptcha.Page_url == null )
                return "Проверьте указана ли страница";
            {
                string DowloadImage = Query.ReCaptcha_V3_Upload( recaptcha);
                if ( DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11 )
                {
                    return Query.Check(Key, DowloadImage, recaptcha.Sleep, recaptcha.Json);
                }
                return DowloadImage;
            }
        }
    }
}
