using Captcha_Service.Enum.Rucaptcha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Rucaptcha
{
    public class GetBalnceModels
    {
        /// <summary>
        /// Ваш ключ
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// getbalance — получить ваш баланс
        /// get — получить ответы на множество капч с помощью одного запроса.Требует указания параметра ids.
        /// get2 — получить стоимость решения отправленной капчи и ответ на нее.Требует указания ID капчи в параметре id.
        /// </summary>
        public GetBalnceEnum Action { get; set; }
        /// <summary>
        /// ID ваших капч, разделенные запятыми.
        /// </summary>
        public string Ids { get; set; }
        /// <summary>
        /// ID вашей капчи.
        /// </summary>
        public string Id { get; set; }
    }
}
