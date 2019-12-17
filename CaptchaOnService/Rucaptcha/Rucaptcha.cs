using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Captcha_Service.Models.Request.Rucaptcha;
using Captcha_Service.Exception.Rucaptcha;
using Captcha_Service.Enum.Rucaptcha;
using Captcha_Service.Models.Response.Rucaptcha;

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
        public ResponseInfoModels GetBalance()
        {
            if ( _key == null )
                throw new ErrorParamsRucaptchaException("Проверьте свой ключ", ERROR.KEY);
            {
                GetBalnceModels data = new GetBalnceModels()
                {
                    Key = _key,
                    Action = ACTION.GETBALANCE
                };
                return  _query.AdditionInfomation(data);
            }
        }

        /// <summary>
        /// Дополнительная информация о балансе
        /// </summary>
        /// <param name="data">Параметры</param>
        /// <returns></returns>
        public ResponseInfoModels AdditionInfo(GetBalnceModels data)
        {
            if ( _key == null )
                throw new ErrorParamsRucaptchaException("Проверьте свой ключ", ERROR.KEY);
            else if ( data == null )
                throw new ErrorParamsRucaptchaException("Проверьте указали ли вы данные", ERROR.DATA);
            else if ( data.Key == null && _key == null )
                throw new ErrorParamsRucaptchaException("Проверьте свой ключ", ERROR.KEY);
            else
            {
                if ( data == null )
                    data.Key = _key;
                else if ( data.Key == null )
                    data.Key = _key;

                return _query.AdditionInfomation(data);
            }
        }



        /// <summary>
        /// Решить текст капчу
        /// </summary>
        /// <returns></returns>
        public string Text(TextModels text)
        {
            if ( _key == null )
                throw new ErrorParamsRucaptchaException("Проверьте свой ключ", ERROR.KEY);
            else if ( text == null )
                throw new ErrorParamsRucaptchaException("Проверьте указали ли вы данные", ERROR.DATA);
            else if ( text.Key == null && _key == null )
                throw new ErrorParamsRucaptchaException("Проверьте свой ключ", ERROR.KEY);
            else if ( text.TextCaptcha == null )
                throw new ErrorParamsRucaptchaException("Проверьте указали ли вы текст", ERROR.TEXT);
            else
            {
                var jsonInfo = _query.Text(text);

                //if ( DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11 )
                //{
                //    return _query.Check(_key, DowloadImage, text.Sleep, text.Json);
                //}

                return jsonInfo.request;
            }
        }

        /// <summary>
        /// Решить капчу ReCaptcha V2
        /// </summary>
        /// <returns></returns>
        public string ReCaptchaV2(ReCaptchaV2Models recaptcha)
        {
            if ( _key == null )
                throw new ErrorParamsRucaptchaException("Проверьте свой ключ", ERROR.KEY);
            else if ( recaptcha == null )
                throw new ErrorParamsRucaptchaException("Проверьте указали ли вы данные", ERROR.DATA);
            else if ( recaptcha.Key == null && _key == null )
                throw new ErrorParamsRucaptchaException("Проверьте свой ключ", ERROR.KEY);
            else if ( recaptcha.GoogleKey == null )
                throw new ErrorParamsRucaptchaException("Проверьте не был указал гугл ключ", ERROR.GOOGLEKEY);
            else if ( recaptcha.PageUrl == null )
                throw new ErrorParamsRucaptchaException("Проверьте не была указана ссылка на сайт", ERROR.PAGEURL);
            else
            {
                var jsonInfo = _query.ReCaptchaV2(recaptcha);

                //if ( DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11 )
                //{
                //    return _query.Check(_key, DowloadImage, recaptcha.Sleep, recaptcha.Json);
                //}
                return jsonInfo.request;
            }
        }

        /// <summary>
        /// Решить капчу ReCaptcha V3
        /// </summary>
        /// <returns></returns>
        public string ReCaptcha_V3(ReCaptchaV3Models recaptcha)
        {
            if ( _key == null )
                throw new ErrorParamsRucaptchaException("Проверьте свой ключ", ERROR.KEY);
            else if ( recaptcha == null )
                throw new ErrorParamsRucaptchaException("Проверьте указали ли вы данные", ERROR.DATA);
            else if ( recaptcha.Key == null && _key == null )
                throw new ErrorParamsRucaptchaException("Проверьте свой ключ", ERROR.KEY);
            else if ( recaptcha.GoogleKey == null )
                throw new ErrorParamsRucaptchaException("Проверьте не был указал гугл ключ", ERROR.GOOGLEKEY);
            else if ( recaptcha.GoogleKey == null )
                throw new ErrorParamsRucaptchaException("Проверьте не была указана ссылка на сайт", ERROR.PAGEURL);
            else
            {
                var jsonInfo = _query.ReCaptchaV3(recaptcha);
                //if ( DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11 )
                //{
                //    return _query.Check(_key, DowloadImage, recaptcha.Sleep, recaptcha.Json);
                //}
                return jsonInfo.request;
            }
        }

        /// <summary>
        /// Решить обычную капчу(картинка)
        /// </summary>
        /// <returns></returns>
        public string Regular(RegularModels regular)
        {
            if ( _key == null )
                throw new ErrorParamsRucaptchaException("Проверьте свой ключ", ERROR.KEY);
            else if ( regular == null )
                throw new ErrorParamsRucaptchaException("Проверьте указали ли вы данные", ERROR.DATA);
            else if ( regular.Key == null && _key == null )
                throw new ErrorParamsRucaptchaException("Проверьте свой ключ", ERROR.KEY);
            else if ( regular.ImapePath == null )
                throw new ErrorParamsRucaptchaException("Проверьте путь к картинке (ImagePath)", ERROR.IMAGEPATH);
            else
            {
                var jsonInfo = _query.Regular(regular);
                //if ( DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11 )
                //{
                //    return _query.Check(_key, DowloadImage, regular.Sleep, regular.Json);
                //}
                return jsonInfo;
            }
        }
    }
}
