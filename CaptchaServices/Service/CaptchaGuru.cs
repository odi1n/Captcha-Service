using Captcha_Service.Additions;
using Captcha_Service.Enums;
using Captcha_Service.Models;
using Captcha_Service.Models.Captcha;
using Captcha_Service.Models.Captcha.Addition;
using Captcha_Service.Models.Captcha.Other;
using Captcha_Service.Models.Captcha.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Captcha_Service
{
    public class CaptchaGuru
    {
        private const int SoftId = 102564;
        private Request _request = new Request();
        private const string _link = "api.captcha.guru";
        private const string _urlIn = "http://" + _link + "/in.php?";
        private const string _urlRes = "http://" + _link + "/res.php?";

        /// <summary>
        /// Указать ключ
        /// </summary>
        /// <param name="key">Ключ</param>
        public CaptchaGuru(string key)
        {
            Setting.SettSetting(key, SoftId);
        }

        /// <summary>
        /// Проверка капчи
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
                    return response;
                }

                Thread.Sleep(check.Sleep);
            }
        }

        /// <summary>
        /// Узнать баланс пользователя
        /// </summary>
        /// <param name="data">Параметры</param>
        /// <returns></returns>
        public Response GetBalance()
        {
            return _request.Get(_urlRes, new Addition(Actions.GetBalance).ToString());
        }

        /// <summary>
        /// Решить капчу картинку
        /// </summary>
        /// <param name="regular">Модель данных</param>
        /// <returns></returns>
        public Response Regular(Regular regular, int sleep = 2000)
        {
            var response = _request.Multipart(_urlIn, regular.ToDictionary());
            return Check(new Check(response.Request, sleep: sleep));
        }

        /// <summary>
        /// Решить рекапча 2
        /// </summary>
        /// <param name="recaptcha">Модель данных</param>
        /// <returns></returns>
        public Response ReCaptchaV2(ReCaptchaV2 recaptcha, int sleep = 2000)
        {
            var recap = _request.Get(_urlIn, recaptcha.ToString());
            return Check(new Check(recap.Request, sleep: sleep));
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
    }
}
