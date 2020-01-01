using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Enum.Rucaptcha
{
    public enum Actions
    {
        /// <summary>
        /// getbalance — получить ваш баланс
        /// </summary>
        GETBALANCE,
        /// <summary>
        /// get — получить ответы на множество капч с помощью одного запроса.Требует указания параметра ids.
        /// </summary>
        GET,
        /// <summary>
        /// get2 — получить стоимость решения отправленной капчи и ответ на нее.Требует указания ID капчи в параметре id.
        /// </summary>
        GET2,
        /// <summary>
        /// сообщить о верном ответе
        /// </summary>
        REPORTGOOD,
        /// <summary>
        /// сообщить о неверном ответе
        /// </summary>
        REPORTBAD,
    }
}
