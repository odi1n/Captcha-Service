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
    public class CptchNet
    {
        private const int SoftId = 147;
        private Request _request = new Request();
        private const string _link = "cptch.net";
        private const string _urlIn = "https://"+_link+"/in.php?";
        private const string _urlRes = "https://" + _link + "/res.php?";

        /// <summary>
        /// Указать ключ
        /// </summary>
        /// <param name="key">Ключ</param>
        public CptchNet(string key)
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
                var response = _request.GetRequest(_urlRes, check.ToString());

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
            return _request.GetRequest(_urlRes, new Addition(Actions.GetBalance).ToString());
        }

        /// <summary>
        /// Решить капчу картинку
        /// </summary>
        /// <param name="regular">Модель данных</param>
        /// <returns></returns>
        public Response Regular(Regular regular, int sleep = 2000)
        {
            var response = _request.PostRequest(_urlIn, regular.ToString());
            return Check(new Check(response.Request, sleep: sleep));
        }

        /// <summary>
        /// Решить рекапча 2
        /// </summary>
        /// <param name="recaptcha">Модель данных</param>
        /// <returns></returns>
        public Response ReCaptchaV2(ReCaptchaV2 recaptcha, int sleep = 2000)
        {
            var recap = _request.GetRequest(_urlIn, recaptcha.ToString());
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
            var response = _request.GetRequest(_urlIn,  recaptcha.ToString());
            return Check(new Check(response.Request, sleep: sleep));
        }
    }
}
