using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Enum
{
    public enum Actions
    {
        /// <summary>
        /// getbalance — получить ваш баланс
        /// </summary>
        getbalance,
        /// <summary>
        /// get — получить ответы на множество капч с помощью одного запроса.Требует указания параметра ids.
        /// </summary>
        get,
        /// <summary>
        /// get2 — получить стоимость решения отправленной капчи и ответ на нее.Требует указания ID капчи в параметре id.
        /// </summary>
        get2,
        /// <summary>
        /// сообщить о верном ответе
        /// </summary>
        reportgood,
        /// <summary>
        /// сообщить о неверном ответе
        /// </summary>
        reportbad,
    }
}
