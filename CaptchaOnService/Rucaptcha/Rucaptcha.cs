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
using System.Drawing;

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
        public ResponseModels CheckCaptchaId(CheckModels captchaInfo)
        {
            return _query.Check(captchaInfo);
        }

        /// <summary>
        /// Узнать баланс пользователя
        /// </summary>
        /// <param name="data">Параметры</param>
        /// <returns></returns>
        public ResponseModels GetBalance()
        {
            GetBalnceModels data = new GetBalnceModels()
            {
                Action = Enum.Rucaptcha.Actions.GETBALANCE
            };
            return _query.AdditionInfomation(data);
        }

        /// <summary>
        /// Дополнительная информация о балансе
        /// </summary>
        /// <param name="data">Параметры</param>
        /// <returns></returns>
        public ResponseModels AdditionInfo(GetBalnceModels data)
        {
            return _query.AdditionInfomation(data);
        }

        /// <summary>
        /// Решить текст капчу
        /// </summary>
        /// <returns></returns>
        public ResponseModels Text(TextModels text)
        {
            return _query.Text(text);
        }

        /// <summary>
        /// Решить капчу
        /// </summary>
        /// <param name="textcaptcha">Текст капчи</param>
        /// <param name="lang">Код языка</param>
        /// <param name="language">0 — не определено 1 — капча содержит только кириллицу 2 — капча содержит только латиницу</param>
        /// <param name="header_acao">0 — выключен 1 — включен</param>
        /// <param name="pingback">URL для автоматической отправки ответа на капчу (callback). </param>
        /// <param name="sleep">Время задержки получения ответа </param>
        /// <returns></returns>
        public ResponseModels Text(string textcaptcha, Lang? lang = null, int? language = null, int? header_acao = null, string pingback = null, int sleep = 1000)
        {
            var text = new TextModels
            {
                TextCaptcha = textcaptcha,
                Lang = lang,
                Language = language,
                HeaderAcao = header_acao,
                Pingback = pingback,
            };
            var response =  _query.Text(text);
            return CheckCaptchaId(new CheckModels()
            {
                Action = Enum.Rucaptcha.Actions.GET,
                Id = response.Request,
                Sleep = sleep,
            });
        }

        /// <summary>
        /// Решить обычную капчу(картинка)
        /// </summary>
        /// <returns></returns>
        public ResponseModels Regular(RegularModels regular)
        {
            return _query.Regular(regular);
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
        public ResponseModels Regular(string imagePath, Method method = Method.POST, int? phrase = null, int? regsense = null,  int? numeric = null,
            int? calc = null, int? min_len = null, int? max_len = null, int? language = null, Lang? lang = null, string textinstructions = null,
            Image imginstructions = null, int? header_acao = null, string pingback = null, int sleep = 2000)
        {
            RegularModels regular = new RegularModels()
            {
                ImapePath = imagePath,
                Method = method,
                Phrase = phrase,
                Regsense = regsense,
                Numeric = numeric,
                Calc = calc,
                MinLen = min_len,
                MaxLen = max_len,
                Language = language,
                Lang = lang,
                Textinstructions = textinstructions,
                Imginstructions = imginstructions,
                HeaderAcao = header_acao,
                Pingback = pingback,
            };
            var response = _query.Regular(regular);
            return CheckCaptchaId(new CheckModels()
            {
                Action = Enum.Rucaptcha.Actions.GET,
                Id = response.Request,
                Sleep = sleep,
            });
        }

        /// <summary>
        /// Решить капчу ReCaptcha V2
        /// </summary>
        /// <returns></returns>
        public ResponseModels ReCaptchaV2(ReCaptchaV2Models recaptcha)
        {
            return  _query.ReCaptchaV2(recaptcha);
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
        public ResponseModels ReCaptchaV2(string googlekey, string pageurl, Method method = Method.userrecaptcha, int? invisible = null, int? header_acao = null, string pingback = null,
            string proxy = null, ProxyType? proxy_type = null, int sleep = 2000)
        {
            ReCaptchaV2Models recaptcha = new ReCaptchaV2Models()
            {
                Method = method,
                GoogleKey = googlekey,
                PageUrl = pageurl,
                Invisible = invisible,
                HeaderAcao = header_acao,
                Proxy = proxy,
                Proxytype = proxy_type,
            };
            var response = _query.ReCaptchaV2(recaptcha);
            return CheckCaptchaId(new CheckModels()
            {
                Action = Enum.Rucaptcha.Actions.GET,
                Id = response.Request,
                Sleep = sleep,
            });
        }

        /// <summary>
        /// Решить капчу ReCaptcha V3
        /// </summary>
        /// <returns></returns>
        public ResponseModels ReCaptchaV3(ReCaptchaV3Models recaptcha)
        {
            return _query.ReCaptchaV3(recaptcha);
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
        public ResponseModels ReCaptchaV3(string googlekey, string pageurl, string version = "v3", Method method  = Method.userrecaptcha, string action = null,
            double? min_score = null, int? header_acao = null, string pingback = null, string proxy = null, ProxyType? proxy_type = null, int sleep = 2000)
        {
            ReCaptchaV3Models recaptcha = new ReCaptchaV3Models()
            {
                GoogleKey = googlekey,
                PageUrl = pageurl,
                Version = version,
                Method = method,
                Action = action,
                MinScore = min_score,
                HeaderAcao = header_acao,
                Pingback = pingback,
                Proxy = proxy,
                Proxytype = proxy_type,
            };
            var response = _query.ReCaptchaV3(recaptcha);
            return CheckCaptchaId(new CheckModels()
            {
                Action = Enum.Rucaptcha.Actions.GET,
                Id = response.Request,
                Sleep = 2000,
            });
        }

    }
}
