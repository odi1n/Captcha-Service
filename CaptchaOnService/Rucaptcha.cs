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
        private ResponseModels Check(CheckModels check)
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
        /// <param name="data">Параметры</param>
        /// <returns></returns>
        public ResponseModels GetBalance()
        {
            return _request.GetRequest(_urlRes, CreateDataParams() + new AdditionModels(Actions.getbalance).ToString());
        }

        /// <summary>
        /// Дополнительная информация о балансе
        /// </summary>
        /// <param name="data">Параметры</param>
        /// <returns></returns>
        public ResponseModels AdditionInfo(AdditionModels data)
        {
            return _request.GetRequest(_urlRes, CreateDataParams() + data.ToString());
        }

        /// <summary>
        /// Решить капчу
        /// </summary>
        /// <param name="sleep">Время задержки получения ответа </param>
        /// <returns></returns>
        public ResponseModels Text(TextModels text, int sleep = 1000)
        {
            var response = _request.GetRequest(_urlIn, CreateDataParams() + text.ToString());
            return Check(new CheckModels(response.Request, sleep: sleep));
        }

        /// <summary>
        /// Решить капчу картинку
        /// </summary>
        /// <param name="imagePath">Путь к картинке</param>
        /// <param name="method">post — говорит о том, что вы отправляете изображение с помощью multipart-фомы base64 — говорит о том, что вы отправляете изображение в формате base64</param>
        /// <param name="phrase">0 — капча состоит из одного слова 1 — капча состоит из двух или более слов</param>
        /// <param name="regsense">0 — капча не чувствительна к регистру 1 — капча чувствительна к регистру</param>
        /// <param name="numeric">0 — не определено 1 — капча состоит только из цифр 2 — капча состоит только из букв 3 — капча состоит либо только из букв, либо только из цифр 4 — в капче могут быть и буквы, и цифры</param>
        /// <param name="calc">0 — не определено 1 — капча требует совершения математического действия (например: напишите результат 4 + 8 = )</param>
        /// <param name="min_len">0 — не определено 1..20 — минимальное количетсво символов в ответе</param>
        /// <param name="max_len">0 — не определено 1..20 — максимальное количетсво символов в ответе</param>
        /// <param name="language">0 — не определено 1 — капча содержит только кириллицу 2 — капча содержит только латиницу</param>
        /// <param name="lang">Код языка</param>
        /// <param name="textinstructions">Текст будет показан работнику, чтобы помочь ему правильно решить капчу.</param>
        /// <param name="imginstructions">Изображение будет показано работнику, чтобы помочь ему решить капчу правильно.</param>
        /// <param name="header_acao">0 — выключен 1 — включен</param>
        /// <param name="pingback">URL для автоматической отправки ответа на капчу (callback).</param>
        /// <param name="sleep">Время задержки получения ответа </param>
        /// <returns></returns>
        public ResponseModels Regular(RegularModels regular, int sleep = 2000)
        {
            var response = _request.UploadFile(_urlIn + CreateDataParams() + regular.ToString(), regular.File);
            return Check(new CheckModels(response.Request, sleep:sleep));
        }

        /// <summary>
        /// Решить капчу ReCaptchaV2
        /// </summary>
        /// <param name="googlekey">Значение параметра k или data-sitekey, которое вы нашли в коде страницы</param>
        /// <param name="pageurl">Полный URL страницы, на которой вы решаете ReCaptcha V2</param>
        /// <param name="method">userrecaptcha — определяет, что вы решаете ReCaptcha V2 с помощью нового метода</param>
        /// <param name="invisible">1 — говорит нам, что на сайте невидимая ReCaptcha. 0 — обычная ReCaptcha.</param>
        /// <param name="header_acao">0 — выключен 1 — включен</param>
        /// <param name="pingback">URL для автоматической отправки ответа на капчу (callback). </param>
        /// <param name="proxy">Формат: логин:пароль@123.123.123.123:3128</param>
        /// <param name="proxy_type">Тип вашего прокси-сервера: HTTP, HTTPS, SOCKS4, SOCKS5.</param>
        /// <param name="sleep">Время задержки получения ответа </param>
        /// <returns></returns>
        public ResponseModels ReCaptchaV2(ReCaptchaV2Models recaptcha, int sleep = 2000)
        {
            var response = _request.GetRequest(_urlIn, CreateDataParams() + recaptcha.ToString());
            return Check(new CheckModels(response.Request, sleep:sleep));
        }

        /// <summary>
        /// Решить капчу ReCaptcha_V3
        /// </summary>
        /// <param name="googlekey">Значение параметра k или data-sitekey, которое вы нашли в коде страницы</param>
        /// <param name="pageurl">Полный URL страницы, на которой вы решаете ReCaptcha V2</param>
        /// <param name="version">v3 — указывает на то, что это ReCaptcha V3</param>
        /// <param name="method">userrecaptcha — определяет, что вы решаете ReCaptcha V2 с помощью нового метода</param>
        /// <param name="action">Значение параметра action, которые вы нашли в коде сайта</param>
        /// <param name="min_score">Требуемое значение рейтинга (score). На текущий момент сложно получить токен со score выше 0.3</param>
        /// <param name="header_acao">0 — выключен 1 — включен</param>
        /// <param name="pingback">URL для автоматической отправки ответа на капчу (callback). </param>
        /// <param name="proxy">Формат: логин:пароль@123.123.123.123:3128</param>
        /// <param name="proxy_type">Тип вашего прокси-сервера: HTTP, HTTPS, SOCKS4, SOCKS5.</param>
        /// <param name="sleep">Время задержки получения ответа </param>
        /// <returns></returns>
        public ResponseModels ReCaptchaV3(ReCaptchaV3Models recaptcha, int sleep = 2000)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            var response = _request.GetRequest(_urlIn, CreateDataParams() + recaptcha.ToString());
            return Check(new CheckModels(response.Request, sleep:sleep));
        }

        /// <summary>
        /// Отчет об ответах
        /// </summary>
        /// <param name="report">Информация о капче</param>
        /// <returns></returns>
        public ResponseModels Report(ReportModels report)
        {
            return _request.GetRequest(_urlRes, CreateDataParams() + report.ToString());
        }
    }
}
