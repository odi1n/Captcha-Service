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

namespace Captcha_Service
{
    /// <summary>
    /// Класс для работы с сервисом Rucaptcha.com
    /// </summary>
    public class RuCaptcha
    {
        private SettingCap setting;
        private Request _request = new Request();
        private const string _link = "rucaptcha.com";
        private const string _urlIn = "http://"+ _link + "/in.php?";
        private const string _urlRes = "http://" + _link + "/res.php?";

        public RuCaptcha(string key)
        {
            setting = new SettingCap(key, true, 2392);
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
                var response = _request.GetRequest(_urlRes, setting.ToString() + check);

                if (response.Status == true)
                {
                    response.Check = check;
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
            return _request.GetRequest(_urlRes, setting.ToString() + new Addition(Actions.GetBalance).ToString());
        }

        /// <summary>
        /// Получить дополнительную информацию
        /// </summary>
        /// <param name="data">Параметры</param>
        /// <returns></returns>
        public Response Addition(Addition data)
        {
            return _request.GetRequest(_urlRes, setting.ToString() + data.ToString());
        }

        /// <summary>
        /// Картинка капча
        /// </summary>
        /// <param name="regular">Модель параметров</param>
        /// <param name="sleep">Время задержки получения ответа </param>
        /// <returns></returns>
        public Response Regular(Regular regular, int sleep = 2000)
        {
            var response = _request.PostRequest(_urlIn, setting.ToString() + regular.ToString());
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
            var response = _request.GetRequest(_urlIn, setting.ToString() + text.ToString());
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
            var response = _request.GetRequest(_urlIn, setting.ToString() + recaptcha.ToString());
            return Check(new Check(response.Request, sleep:sleep));
        }

        /// <summary>
        /// ReCaptcha V3
        /// </summary>
        /// <param name="recaptcha">Модель параметров</param>
        /// <param name="sleep">Время задержки получения ответа </param>
        /// <returns></returns>
        public Response ReCaptchaV3(ReCaptchaV3 recaptcha, int sleep = 2000)
        {
            var response = _request.GetRequest(_urlIn, setting.ToString() + recaptcha.ToString());
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
            var response = _request.UploadFile(_urlIn + setting.ToString() + recaptcha.ToString(), recaptcha.File);
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
            var response = _request.UploadFile(_urlIn + setting.ToString() + clickCaptcha.ToString(), clickCaptcha.File);
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
            var response = _request.GetRequest(_urlIn, setting.ToString() + funCaptcha.ToString());
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
            var response = _request.GetRequest(_urlIn, setting.ToString() + keyCaptcha.ToString());
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
            var response = _request.GetRequest(_urlIn, setting.ToString() + geeTest.ToString());
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
            var response = _request.GetRequest(_urlIn, setting.ToString() + hCaptcha.ToString());
            return Check(new Check(response.Request, sleep: sleep));
        }

        /// <summary>
        /// Отчет об ответах
        /// </summary>
        /// <param name="report">Информация о капче</param>
        /// <returns></returns>
        public Response Report(ReportModels report)
        {
            return _request.GetRequest(_urlRes, setting.ToString() + report.ToString());
        }
    }
}
