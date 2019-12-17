using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Captcha_Service.Models.Rucaptcha;
using Captcha_Service.Exception.Rucaptcha;

namespace Captcha_Service.Rucaptcha
{
    /// <summary>
    /// Класс для работы с сервисом Rucaptcha.com
    /// </summary>
    public class Rucaptcha
    {
        /// <summary>
        /// Ключ от сервиса
        /// </summary>
        private  string _key { get; set; }
        /// <summary>
        /// Для запросов
        /// </summary>
        private wRucaptcha.Query _query;

        public Rucaptcha(string key)
        {
            this._key = key; 
            this._query = new wRucaptcha.Query(key);
        }

        /// <summary>
        /// Узнать баланс пользователя
        /// </summary>
        /// <param name="data">Параметры</param>
        /// <returns></returns>
        public string GetBalance(GetBalnceModels data)
        {
            if ( _key == null )
                throw new ErrorParamsRucaptchaException("Проверьте свой ключ");
            else if ( data == null )
                throw new ErrorParamsRucaptchaException("Проверьте указали ли вы данные");
            else if ( data.Key == null && _key == null )
                throw new ErrorParamsRucaptchaException("Проверьте свой ключ");
            else
            {
                if ( data == null )
                    data.Key = _key;
                else if ( data.Key == null )
                    data.Key = _key;

                return _query.GetBalanceByte(data);
            }
        }

        /// <summary>
        /// Решить обычную капчу(картинка)
        /// </summary>
        /// <returns></returns>
        public string Regular(RegularModels regular)
        {
            if ( _key == null )
                return "Проверьте ключ";
            else if ( regular.ImapePath == null )
                return "Проверьте путь к картинке";
            else
            {
                string DowloadImage = _query.RegularUpload( regular);
                if ( DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11 )
                {
                    return _query.Check(_key, DowloadImage, regular.Sleep, regular.Json);
                }
                return DowloadImage;
            }
        }

        /// <summary>
        /// Решить текст капчу
        /// </summary>
        /// <returns></returns>
        public string Text(TextModels text)
        {
            if ( _key == null )
                return "Нет ключа";
            else if ( text.TextCaptcha == null )
                return "Проверьте указана ли капча";
            else
            {
                string DowloadImage = _query.TextUpload(text.TextCaptcha);
                if ( DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11 )
                {
                    return _query.Check(_key, DowloadImage, text.Sleep, text.Json);
                }
                return DowloadImage;
            }
        }

        /// <summary>
        /// Решить капчу ReCaptcha V2
        /// </summary>
        /// <returns></returns>
        public string ReCaptcha_V2(RcV2Models recaptcha)
        {
            if ( _key == null )
                return "Проверьте ключ";
            else if(recaptcha.GoogleKey == null)
                return "Проверьте указан ли гугл ключ";
            else if(recaptcha.PageUrl == null)
                return "Проверьте указана ли страница";
            {
                string DowloadImage = _query.RcV2Upload(recaptcha);
                if ( DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11 )
                {
                    return _query.Check(_key, DowloadImage, recaptcha.Sleep, recaptcha.Json);
                }
                return DowloadImage;
            }
        }

        /// <summary>
        /// Решить капчу ReCaptcha V3
        /// </summary>
        /// <returns></returns>
        public string ReCaptcha_V3(RcV3Models recaptcha)
        {
            if ( _key == null )
                return "Проверьте ключ";
            else if ( recaptcha.GoogleKey == null )
                return "Проверьте указан ли гугл ключ";
            else if ( recaptcha.PageUrl == null )
                return "Проверьте указана ли страница";
            {
                string DowloadImage = _query.RcV3Upload( recaptcha);
                if ( DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11 )
                {
                    return _query.Check(_key, DowloadImage, recaptcha.Sleep, recaptcha.Json);
                }
                return DowloadImage;
            }
        }
    }
}
