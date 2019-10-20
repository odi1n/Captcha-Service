using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Captcha_Service.Rucaptcha
{
    /// <summary>
    /// Класс для работы с сервисом Rucaptcha.com
    /// </summary>
    public class Rucaptcha
    {
        private wRucaptcha.Query Query = new wRucaptcha.Query();

        /// <summary>
        /// Ключ от сервиса
        /// </summary>
        public static string Key { get; set; }

        #region Информационные
        /// <summary>
        /// Получить информацию об ошибке
        /// </summary>
        /// <param name="Error">Ошика которая возникла</param>
        /// <returns></returns>
        public static string ErrorInfomation(string Error)
        {
            string reply = "";
            switch (Error)
            {
                case "ERROR_WRONG_USER_KEY": reply = wRucaptcha.ErrorIn.ERROR_WRONG_USER_KEY; break;
                case "ERROR_KEY_DOES_NOT_EXIST": reply = wRucaptcha.ErrorIn.ERROR_KEY_DOES_NOT_EXIST; break;
                case "ERROR_ZERO_BALANCE": reply = wRucaptcha.ErrorIn.ERROR_ZERO_BALANCE; break;
                case "ERROR_PAGEURL": reply = wRucaptcha.ErrorIn.ERROR_PAGEURL; break;
                case "ERROR_NO_SLOT_AVAILABLE": reply = wRucaptcha.ErrorIn.ERROR_NO_SLOT_AVAILABLE; break;
                case "ERROR_ZERO_CAPTCHA_FILESIZE": reply = wRucaptcha.ErrorIn.ERROR_ZERO_CAPTCHA_FILESIZE; break;
                case "ERROR_TOO_BIG_CAPTCHA_FILESIZE": reply = wRucaptcha.ErrorIn.ERROR_TOO_BIG_CAPTCHA_FILESIZE; break;
                case "ERROR_WRONG_FILE_EXTENSION": reply = wRucaptcha.ErrorIn.ERROR_WRONG_FILE_EXTENSION; break;
                case "ERROR_IMAGE_TYPE_NOT_SUPPORTED": reply = wRucaptcha.ErrorIn.ERROR_IMAGE_TYPE_NOT_SUPPORTED; break;
                case "ERROR_UPLOAD": reply = wRucaptcha.ErrorIn.ERROR_UPLOAD; break;
                case "ERROR_IP_NOT_ALLOWED": reply = wRucaptcha.ErrorIn.ERROR_IP_NOT_ALLOWED; break;
                case "IP_BANNED": reply = wRucaptcha.ErrorIn.IP_BANNED; break;
                case "ERROR_BAD_TOKEN_OR_PAGEURL": reply = wRucaptcha.ErrorIn.ERROR_BAD_TOKEN_OR_PAGEURL; break;
                case "ERROR_GOOGLEKEY": reply = wRucaptcha.ErrorIn.ERROR_GOOGLEKEY; break;
                case "ERROR_CAPTCHAIMAGE_BLOCKED": reply = wRucaptcha.ErrorIn.ERROR_CAPTCHAIMAGE_BLOCKED; break;
                case "MAX_USER_TURN": reply = wRucaptcha.ErrorIn.MAX_USER_TURN; break;
                case "ERROR": reply = wRucaptcha.ErrorIn.ERROR; break;

                case "CAPCHA_NOT_READY": reply = wRucaptcha.ErrorRes.CAPCHA_NOT_READY; break;
                case "ERROR_CAPTCHA_UNSOLVABLE": reply = wRucaptcha.ErrorRes.ERROR_CAPTCHA_UNSOLVABLE; break;
                case "ERROR_WRONG_ID_FORMAT": reply = wRucaptcha.ErrorRes.ERROR_WRONG_ID_FORMAT; break;
                case "ERROR_WRONG_CAPTCHA_ID": reply = wRucaptcha.ErrorRes.ERROR_WRONG_CAPTCHA_ID; break;
                case "ERROR_BAD_DUPLICATES": reply = wRucaptcha.ErrorRes.ERROR_BAD_DUPLICATES; break;
                case "REPORT_NOT_RECORDED": reply = wRucaptcha.ErrorRes.REPORT_NOT_RECORDED; break;
                case "ERROR_IP_ADDRES": reply = wRucaptcha.ErrorRes.ERROR_IP_ADDRES; break;
            }
            return reply;
        }

        /// <summary>
        /// Узнать баланс пользователя
        /// </summary>
        /// <param name="json">Получать ли данные в json. false - получить обычно, true - получить в json</param>
        /// <returns></returns>
        public static string GetBalance(bool json = false)
        {
            WebRequest requet =  wRucaptcha.Query.GetBalanceByte(Key, json);
            return wRucaptcha.Additional.ByteToString(requet);
        }

        /// <summary>
        /// Узнать баланс пользователя
        /// </summary>
        /// <param name="json">Ключ, баланс которого требуется узнать</param>
        /// <param name="json">Получать ли данные в json. false - получить обычно, true - получить в json</param>
        /// <returns></returns>
        public static string GetBalance(string key,bool json = false)
        {
            WebRequest requet = wRucaptcha.Query.GetBalanceByte(key, json);
            return wRucaptcha.Additional.ByteToString(requet);
        }
        #endregion

        #region Решение капчи

        #region Решить обычную капчу
        /// <summary>
        /// Решить обычную капчу(картинка)
        /// </summary>
        /// <param name="ImapePath">Путь к капче которую будем решать</param>
        /// <returns></returns>
        public string Regular(string ImapePath)
        {
            string DowloadImage = Query.RegularUpload(Key, ImapePath);
            if (DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11)
            {
                return Query.Check(Key, DowloadImage,1000);
            }
            return DowloadImage;
        }

        /// <summary>
        /// Решить обычную капчу(картинка)
        /// </summary>
        /// <param name="ImapePath">Путь к капче которую будем решать</param>
        /// <param name="json">Получать ли данные в json. false - получить обычно, true - получить в json</param>
        /// <returns></returns>
        public string Regular(string ImapePath, bool json = false)
        {
            string DowloadImage = Query.RegularUpload(Key, ImapePath);
            if (DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11)
            {
                return Query.Check(Key,DowloadImage,1000,json);
            }
            return DowloadImage;
        }

        /// <summary>
        /// Решить обычную капчу(картинка)
        /// </summary>
        /// <param name="ImapePath">Путь к капче которую будем решать</param>
        /// <param name="sleep">Задержка для обновления данных о решении. Пример 1000мс - 1с</param>
        /// <param name="json">Получать ли данные в json. false - получить обычно, true - получить в json</param>
        /// <returns></returns>
        public string Regular(string ImapePath, int sleep, bool json = false)
        {
            string DowloadImage = Query.RegularUpload(Key, ImapePath);
            if (DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11)
            {
                return Query.Check(Key, DowloadImage, sleep, json);
            }
            return DowloadImage;
        }
        #endregion

        #region Решить текст капчу
        /// <summary>
        /// Решить текст капчу
        /// </summary>
        /// <param name="TextCaptcha">Текст самой капчи</param>
        /// <returns></returns>
        public string Text(string TextCaptcha)
        {
            string DowloadImage = Query.TextUpload(Key, TextCaptcha);
            if (DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11)
            {
                return Query.Check(Key, DowloadImage,1000);
            }
            return DowloadImage;
        }

        /// <summary>
        /// Решить текст капчу
        /// </summary>
        /// <param name="TextCaptcha">Текст самой капчи</param>
        /// <param name="json">Получать ли данные в json. false - получить обычно, true - получить в json</param>
        /// <returns></returns>
        public string Text(string TextCaptcha, bool json = false)
        {
            string DowloadImage = Query.TextUpload(Key, TextCaptcha);
            if (DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11)
            {
                return Query.Check(Key, DowloadImage,1000,json);
            }
            return DowloadImage;
        }

        /// <summary>
        /// Решить текст капчу
        /// </summary>
        /// <param name="TextCaptcha">Текст самой капчи</param>
        /// <param name="sleep">Задержка для обновления данных о решении. Пример 1000мс - 1с</param>
        /// <param name="json">Получать ли данные в json. false - получить обычно, true - получить в json</param>
        /// <returns></returns>
        public string Text(string TextCaptcha, int sleep, bool json = false)
        {
            string DowloadImage = Query.TextUpload(Key, TextCaptcha);
            if (DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11)
            {
                return Query.Check(Key, DowloadImage, sleep, json);
            }
            return DowloadImage;
        }
        #endregion

        #region ReCaptcha_V2
        /// <summary>
        /// Решить капчу ReCaptcha V2
        /// </summary>
        /// <param name="pageurl">Полный URL страницы, на которой вы решаете ReCaptcha V2</param>
        /// <param name="googlekey">Значение параметра k или data-sitekey, которое вы нашли в коде страницы</param>
        /// <returns></returns>
        public string ReCaptcha_V2(string pageurl, string googlekey)
        {
            string DowloadImage = Query.ReCaptcha_V2_Upload(Key, googlekey, pageurl);
            if (DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11)
            {
                return Query.Check(Key, DowloadImage,3000);
            }
            return DowloadImage;
        }

        /// <summary>
        /// Решить капчу ReCaptcha V2
        /// </summary>
        /// <param name="pageurl">Полный URL страницы, на которой вы решаете ReCaptcha V2</param>
        /// <param name="googlekey">Значение параметра k или data-sitekey, которое вы нашли в коде страницы</param>
        /// <param name="json">Получать ли данные в json. false - получить обычно, true - получить в json</param>
        /// <returns></returns>
        public string ReCaptcha_V2(string pageurl, string googlekey, bool json = false)
        {
            string DowloadImage = Query.ReCaptcha_V2_Upload(Key, googlekey, pageurl);
            if (DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11)
            {
                return Query.Check(Key, DowloadImage, 3000, json);
            }
            return DowloadImage;
        }

        /// <summary>
        /// Решить капчу ReCaptcha V2
        /// </summary>
        /// <param name="pageurl">Полный URL страницы, на которой вы решаете ReCaptcha V2</param>
        /// <param name="googlekey">Значение параметра k или data-sitekey, которое вы нашли в коде страницы</param>
        /// <param name="sleep">Задержка для обновления данных о решении. Пример 1000мс - 1с</param>
        /// <param name="json">Получать ли данные в json. false - получить обычно, true - получить в json</param>
        /// <returns></returns>
        public string ReCaptcha_V2(string pageurl, string googlekey, int sleep, bool json = false)
        {
            string DowloadImage = Query.ReCaptcha_V2_Upload(Key, googlekey, pageurl);
            if (DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11)
            {
                return Query.Check(Key, DowloadImage, sleep, json);
            }
            return DowloadImage;
        }
        #endregion

        #region ReCaptcha_V3
        /// <summary>
        /// Решить капчу ReCaptcha V3
        /// </summary>
        /// <param name="pageurl">Полный URL страницы, на которой вы решаете ReCaptcha V3</param>
        /// <param name="googlekey">Значение параметра k или data-sitekey, которое вы нашли в коде страницы</param>
        /// <returns></returns>
        public string ReCaptcha_V3(string pageurl, string googlekey, string action = "verify")
        {
            string DowloadImage = Query.ReCaptcha_V3_Upload(Key, googlekey, pageurl, action);
            if (DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11)
            {
                return Query.Check(Key, DowloadImage,3000);
            }
            return DowloadImage;
        }

        /// <summary>
        /// Решить капчу ReCaptcha V3
        /// </summary>
        /// <param name="pageurl">Полный URL страницы, на которой вы решаете ReCaptcha V3</param>
        /// <param name="googlekey">Значение параметра k или data-sitekey, которое вы нашли в коде страницы</param>
        /// <param name="json">Получать ли данные в json. false - получить обычно, true - получить в json</param>
        /// <returns></returns>
        public string ReCaptcha_V3(string pageurl, string googlekey, bool json = false, string action = "verify")
        {
            string DowloadImage = Query.ReCaptcha_V3_Upload(Key, googlekey, pageurl, action);
            if (DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11)
            {
                return Query.Check(Key, DowloadImage, 3000, json);
            }
            return DowloadImage;
        }

        /// <summary>
        /// Решить капчу ReCaptcha V3
        /// </summary>
        /// <param name="pageurl">Полный URL страницы, на которой вы решаете ReCaptcha V3</param>
        /// <param name="googlekey">Значение параметра k или data-sitekey, которое вы нашли в коде страницы</param>
        /// <param name="sleep">Задержка для обновления данных о решении. Пример 1000мс - 1с</param>
        /// <param name="json">Получать ли данные в json. false - получить обычно, true - получить в json</param>
        /// <returns></returns>
        public string ReCaptcha_V3(string pageurl, string googlekey, int sleep, bool json = false, string action = "verify")
        {
            string DowloadImage = Query.ReCaptcha_V3_Upload(Key, googlekey, pageurl, action);
            if (DowloadImage.Length == 9 || DowloadImage.Length == 10 || DowloadImage.Length == 11)
            {
                return Query.Check(Key, DowloadImage, sleep, json);
            }
            return DowloadImage;
        }
        #endregion

        #endregion
    }
}
