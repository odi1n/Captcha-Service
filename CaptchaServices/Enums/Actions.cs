using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Enums
{
    public class Actions
    {
        /// <summary>
        /// getbalance — получить ваш баланс
        /// </summary>
        public const string GetBalance = "getbalance";
        /// <summary>
        /// get — получить ответы на множество капч с помощью одного запроса.Требует указания параметра ids.
        /// </summary>
        public const string Get = "get";
        /// <summary>
        /// get2 — получить стоимость решения отправленной капчи и ответ на нее.Требует указания ID капчи в параметре id.
        /// </summary>
        public const string Get2 = "get2";
        /// <summary>
        /// сообщить о верном ответе
        /// </summary>
        public const string ReportGood = "reportgood";
        /// <summary>
        /// сообщить о неверном ответе
        /// </summary>
        public const string ReportBad = "reportbad";
    }
}
