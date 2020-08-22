using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Captcha_Service.Enums;
using Captcha_Service.Models;
using Captcha_Service.Additions;
using System.Threading;
using Captcha_Service.Models.Captcha.Request;
using Captcha_Service.Models.Captcha;
using Captcha_Service.Models.Captcha.Addition;
using Captcha_Service.Models.Captcha.Other;

namespace Captcha_Service
{
    /// <summary>
    /// Класс для работы с сервисом Rucaptcha.com
    /// </summary>
    public class RuCaptcha
    {
        private const int SoftId = 2392;

        private Request _request = new Request();
        private const string _link = "rucaptcha.com";
        private const string _urlIn = "http://" + _link + "/in.php?";
        private const string _urlRes = "http://" + _link + "/res.php?";

        public delegate void GetAnswer(object e, Response response);
        public event GetAnswer Answer;

        public RuCaptcha(string key)
        {
            Setting.SettSetting(key, SoftId);
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
                var response = _request.Get(_urlRes, check.ToString());

                if (response.Status == true)
                {
                    response.Check = check;
                    Answer?.Invoke(this,response);
                    return response;
                }

                Thread.Sleep(check.Sleep);
            }
        }

        /// <summary>
        /// Узнать баланс пользователя
        /// </summary>
        /// <returns></returns>
        public Response GetBalance()
        {
            return _request.Get(_urlRes, new Addition(Actions.GetBalance).ToString());
        }

        /// <summary>
        /// Получить дополнительную информацию
        /// </summary>
        /// <param name="data">Параметры</param>
        /// <returns></returns>
        public Response Addition(Addition addition)
        {
            return _request.Get(_urlRes, addition.ToString());
        }

        /// <summary>
        /// Картинка капча
        /// </summary>
        /// <param name="regular">Модель параметров</param>
        /// <param name="sleep">Время задержки получения ответа </param>
        /// <returns></returns>
        public Response Regular(Regular regular, int sleep = 2000)
        {
            var response = _request.Multipart(_urlIn, regular.ToDictionary());
            return Check(new Check(response.Request, sleep: sleep));
        }

        /// <summary>
        /// Текст капча
        /// </summary>
        /// <param name="text">Модель параметров </param>
        /// <param name="sleep">Время задержки получения ответа </param>
        /// <returns></returns>
        public Response Text(Text text, int sleep = 1000)
        {
            var response = _request.Get(_urlIn, text.ToString());
            return Check(new Check(response.Request, sleep: sleep));
        }

        /// <summary>
        /// ReCaptch aV2
        /// </summary>
        /// <param name="recaptcha">Модель параметров</param>
        /// <param name="sleep">Время задержки получения ответа </param>
        /// <returns></returns>
        public Response ReCaptchaV2(ReCaptchaV2 recaptcha, int sleep = 2000)
        {
            var response = _request.Get(_urlIn, recaptcha.ToString());
            return Check(new Check(response.Request, sleep: sleep));
        }

        /// <summary>
        /// ReCaptcha V3
        /// </summary>
        /// <param name="recaptcha">Модель параметров</param>
        /// <param name="sleep">Время задержки получения ответа </param>
        /// <returns></returns>
        public Response ReCaptchaV3(ReCaptchaV3 recaptcha, int sleep = 2000)
        {
            var response = _request.Get(_urlIn, recaptcha.ToString());
            return Check(new Check(response.Request, sleep: sleep));
        }

        /// <summary>
        /// ReCaptcha V2 (устаревший метод)
        /// </summary>
        /// <param name="recaptcha">Модель параметров</param>
        /// <param name="sleep">Время задержки получения ответа</param>
        /// <returns></returns>
        public Response ReCaptchaV2Old(ReCaptchaV2Old recaptcha, int sleep = 2000)
        {
            var response = _request.Multipart(_urlIn, recaptcha.ToDictionary());
            return Check(new Check(response.Request, sleep: sleep));
        }

        /// <summary>
        /// ClickCaptcha
        /// </summary>
        /// <param name="clickCaptcha">Модель параметров</param>
        /// <param name="sleep">Время задержки получения ответа</param>
        /// <returns></returns>
        public Response ClickCaptcha(ClickCaptcha clickCaptcha, int sleep = 2000)
        {
            var response = _request.Multipart(_urlIn, clickCaptcha.ToDictionary());
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
            var response = _request.Get(_urlIn, funCaptcha.ToString());
            return Check(new Check(response.Request, sleep: sleep));
        }

        /// <summary>
        /// KeyCaptcha
        /// </summary>
        /// <param name="keyCaptcha">Модель параметров</param>
        /// <param name="sleep">Время задержки получения ответа</param>
        /// <returns></returns>
        public Response KeyCaptcha(KeyCaptcha keyCaptcha, int sleep = 2000)
        {
            var response = _request.Get(_urlIn, keyCaptcha.ToString());
            return Check(new Check(response.Request, sleep: sleep));
        }

        /// <summary>
        /// GeeTest
        /// </summary>
        /// <param name="geeTest">Модель параметров</param>
        /// <param name="sleep">Время задержки получения ответа</param>
        /// <returns></returns>
        public Response GeeTest(GeeTest geeTest, int sleep = 2000)
        {
            var response = _request.Get(_urlIn, geeTest.ToString());
            return Check(new Check(response.Request, sleep: sleep));
        }

        /// <summary>
        /// HCaptcha
        /// </summary>
        /// <param name="hCaptcha">Модель параметров</param>
        /// <param name="sleep">Время задержки получения ответа</param>
        /// <returns></returns>
        public Response HCaptcha(HCaptcha hCaptcha, int sleep = 2000)
        {
            var response = _request.Get(_urlIn, hCaptcha.ToString());
            return Check(new Check(response.Request, sleep: sleep));
        }

        /// <summary>
        /// Отчет об ответах
        /// </summary>
        /// <param name="report">Информация о капче</param>
        /// <returns></returns>
        public Response Report(ReportModels report)
        {
            return _request.Get(_urlRes, report.ToString());
        }
    }
}
