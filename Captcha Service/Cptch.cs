using Captcha_Service.Addition;
using Captcha_Service.Enum;
using Captcha_Service.Models;
using Captcha_Service.Models.Request;
using Captcha_Service.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Captcha_Service
{
    public class Cptch
    {
        private string _key;
        private static readonly int _json = 1;
        private static readonly string _softId = "147";
        private static readonly string _urlIn = "https://cptch.net/in.php?";
        private static readonly string _urlRes = "https://cptch.net/res.php?";
        private static readonly Request _request = new Request();

        /// <summary>
        /// Указать ключ
        /// </summary>
        /// <param name="key">Ключ</param>
        public Cptch(string key)
        {
            this._key = key;
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
                var response = _request.GetRequest(_urlRes, CreateDataParams() + check.ToString());

                if (response.Status == 1)
                    return response;

                Thread.Sleep(check.Sleep);
            }
        }

        /// <summary>
        /// Создание данных параметров
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
        /// <param name="data">Параметры</param>
        /// <returns></returns>
        public Response GetBalance()
        {
            return _request.GetRequest(_urlRes, CreateDataParams() + new Models.Request.Addition(Actions.getbalance).ToString());
        }

        /// <summary>
        /// Решить капчу картинку
        /// </summary>
        /// <param name="regular">Модель данных</param>
        /// <returns></returns>
        public Response Regular(Regular regular, int sleep = 2000)
        {
            var reg = _request.UploadFile(_urlIn + CreateDataParams() + regular.ToString(), regular.File);
            return Check(new Check(reg.Request, sleep:sleep));
        }

        /// <summary>
        /// Решить рекапча 2
        /// </summary>
        /// <param name="recaptcha">Модель данных</param>
        /// <returns></returns>
        public Response ReCaptchaV2(ReCaptchaV2 recaptcha, int sleep = 2000)
        {
            var recap = _request.GetRequest(_urlIn, CreateDataParams() + recaptcha.ToString());
            return Check(new Check(recap.Request, sleep: sleep));
        }
    }
}
