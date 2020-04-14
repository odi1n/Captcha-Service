using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Captcha_Service.Models.Request;
using Captcha_Service.Enum;
using Captcha_Service.Models;
using System.Drawing;
using System.Globalization;
using Captcha_Service.Query;
using Captcha_Service.Addition;
using System.Threading;

namespace Captcha_Service.Rucaptcha
{
    /// <summary>
    /// Класс для работы с сервисом Rucaptcha.com
    /// </summary>
    public class Rucaptcha
    {
        private string _key;
        private static readonly int _json = 1;
        private static readonly string _softId = "2392";
        private static readonly string _urlIn = "http://rucaptcha.com/in.php?";
        private static readonly string _urlRes = "http://rucaptcha.com/res.php?";
        private static readonly Request _request = new Request();

        public Rucaptcha(string key)
        {
            this._key = key;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }

        /// <summary>
        /// Проверить капчу
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        private Response Check(Check check)
        {
            while (true)
            {
                var response = _request.GetRequest(_urlRes, CreateDataParams() + check);

                if (response.Status == 1)
                    return response;

                Thread.Sleep(check.Sleep);
            }
        }

        /// <summary>
        /// Создать данные параметры
        /// </summary>
        /// <returns></returns>
        private string CreateDataParams()
        {
            var Data = new Dictionary<string, object>()
            {
                ["key"] = _key,
                ["json"] = _json,
                ["soft_id"] = _softId,
            };
            var data = DictionaryConvert.Deserialization(Data) + "&";
            return data;
        }

        /// <summary>
        /// Узнать баланс пользователя
        /// </summary>
        /// <returns></returns>
        public Response GetBalance()
        {
            return _request.GetRequest(_urlRes, CreateDataParams() + new Models.Request.Addition(Actions.getbalance).ToString());
        }

        /// <summary>
        /// Дополнительная информация о балансе
        /// </summary>
        /// <param name="data">Параметры</param>
        /// <returns></returns>
        public Response AdditionInfo(Models.Request.Addition data)
        {
            return _request.GetRequest(_urlRes, CreateDataParams() + data.ToString());
        }

        /// <summary>
        /// Решить капчу
        /// </summary>
        /// <param name="text">Модель параметров </param>
        /// <param name="sleep">Время задержки получения ответа </param>
        /// <returns></returns>
        public Response Text(Text text, int sleep = 1000)
        {
            var response = _request.GetRequest(_urlIn, CreateDataParams() + text.ToString());
            return Check(new Check(response.Request, sleep: sleep));
        }

        /// <summary>
        /// Решить капчу картинку
        /// </summary>
        /// <param name="regular">Модель параметров</param>
        /// <param name="sleep">Время задержки получения ответа </param>
        /// <returns></returns>
        public Response Regular(Regular regular, int sleep = 2000)
        {
            var response = _request.UploadFile(_urlIn + CreateDataParams() + regular.ToString(), regular.File);
            return Check(new Check(response.Request, sleep:sleep));
        }

        /// <summary>
        /// Решить капчу ReCaptchaV2
        /// </summary>
        /// <param name="recaptcha">Модель параметров</param>
        /// <param name="sleep">Время задержки получения ответа </param>
        /// <returns></returns>
        public Response ReCaptchaV2(ReCaptchaV2 recaptcha, int sleep = 2000)
        {
            var response = _request.GetRequest(_urlIn, CreateDataParams() + recaptcha.ToString());
            return Check(new Check(response.Request, sleep:sleep));
        }

        /// <summary>
        /// Решить капчу ReCaptcha_V3
        /// </summary>
        /// <param name="recaptcha">Модель параметров</param>
        /// <param name="sleep">Время задержки получения ответа </param>
        /// <returns></returns>
        public Response ReCaptchaV3(ReCaptchaV3 recaptcha, int sleep = 2000)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            var response = _request.GetRequest(_urlIn, CreateDataParams() + recaptcha.ToString());
            return Check(new Check(response.Request, sleep:sleep));
        }

        /// <summary>
        /// ReCaptcha V2 (устаревший метод)
        /// </summary>
        /// <param name="recaptcha">Модель параметров</param>
        /// <param name="sleep">Время задержки получения ответа</param>
        /// <returns></returns>
        public Response ReCaptchaV2Old(ReCaptchaV2Old recaptcha, int sleep = 2000)
        {
            var response = _request.UploadFile(_urlIn + CreateDataParams() + recaptcha.ToString(), recaptcha.File);
            return Check(new Check(response.Request, sleep: sleep));
        }

        /// <summary>
        /// FunCaptcha с токеном
        /// </summary>
        /// <param name="funCaptcha">Модель параметров</param>
        /// <param name="sleep">Время задержки получения ответа</param>
        /// <returns></returns>
        public Response FunCaptchaToken(FunCaptcha funCaptcha, int sleep = 2000)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            var response = _request.GetRequest(_urlIn, CreateDataParams() + funCaptcha.ToString());
            return Check(new Check(response.Request, sleep: sleep));
        }

        /// <summary>
        /// KeyCaptcha
        /// </summary>
        /// <param name="keyCaptcha">>Модель параметров</param>
        /// <param name="sleep">Время задержки получения ответа</param>
        /// <returns></returns>
        public Response KeyCaptcha(KeyCaptcha keyCaptcha, int sleep = 2000)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            var response = _request.GetRequest(_urlIn, CreateDataParams() + keyCaptcha.ToString());
            return Check(new Check(response.Request, sleep: sleep));
        }

        /// <summary>
        /// Отчет об ответах
        /// </summary>
        /// <param name="report">Информация о капче</param>
        /// <returns></returns>
        public Response Report(ReportModels report)
        {
            return _request.GetRequest(_urlRes, CreateDataParams() + report.ToString());
        }
    }
}
