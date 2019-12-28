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
        /// Ключ от сервиса Rucaptcha
        /// </summary>
        public static string Key { get { return _key; } }
        private static string _key { get; set; }

        /// <summary>
        /// Для запросов
        /// </summary>
        private wRucaptcha.Query _query;

        public Rucaptcha(string key)
        {
            _key = key;
            this._query = new wRucaptcha.Query();
        }

        /// <summary>
        /// Проверить решение капчи
        /// </summary>
        /// <returns></returns>
        public ResponseInfoModels CheckCaptchaId(CheckModels captchaInfo)
        {
            return _query.Check(captchaInfo);
        }

        /// <summary>
        /// Узнать баланс пользователя
        /// </summary>
        /// <param name="data">Параметры</param>
        /// <returns></returns>
        public ResponseInfoModels GetBalance()
        {
            GetBalnceModels data = new GetBalnceModels()
            {
                Action = ACTION.GETBALANCE
            };
            return _query.AdditionInfomation(data);
        }

        /// <summary>
        /// Дополнительная информация о балансе
        /// </summary>
        /// <param name="data">Параметры</param>
        /// <returns></returns>
        public ResponseInfoModels AdditionInfo(GetBalnceModels data)
        {
            return _query.AdditionInfomation(data);
        }

        /// <summary>
        /// Решить текст капчу
        /// </summary>
        /// <returns></returns>
        public ResponseInfoModels Text(TextModels text)
        {
            return _query.Text(text);
        }

        /// <summary>
        /// Решить капчу ReCaptcha V2
        /// </summary>
        /// <returns></returns>
        public ResponseInfoModels ReCaptchaV2(ReCaptchaV2Models recaptcha)
        {
            return  _query.ReCaptchaV2(recaptcha);
        }

        /// <summary>
        /// Решить капчу ReCaptcha V3
        /// </summary>
        /// <returns></returns>
        public ResponseInfoModels ReCaptcha_V3(ReCaptchaV3Models recaptcha)
        {
            return _query.ReCaptchaV3(recaptcha);
        }

        /// <summary>
        /// Решить обычную капчу(картинка)
        /// </summary>
        /// <returns></returns>
        public ResponseInfoModels Regular(RegularModels regular)
        {
            return _query.Regular(regular);
        }
    }
}
