using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Enums
{
    [Flags]
    public enum Actions
    {
        /// <summary>
        /// getbalance — получить ваш баланс
        /// </summary>
        [Description("getbalance")]
        GetBalance,

        /// <summary>
        /// get — получить ответы на множество капч с помощью одного запроса.Требует указания параметра ids.
        /// </summary>
        [Description("get")]
        Get,

        /// <summary>
        /// get2 — получить стоимость решения отправленной капчи и ответ на нее.Требует указания ID капчи в параметре id.
        /// </summary>
        [Description("get2")]
        Get2,

        /// <summary>
        /// сообщить о верном ответе
        /// </summary>
        [Description("reportgood")]
        ReportGood,

        /// <summary>
        /// сообщить о неверном ответе
        /// </summary>
        [Description("reportbad")]
        ReportBad,
    }
}
