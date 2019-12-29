using Captcha_Service.Enum.Rucaptcha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Request.Rucaptcha
{
    public class GetBalnceModels 
    {
        /// <summary>
        /// Действие которое нужно получить
        /// </summary>
        public Actions Action { get; set; } = Enum.Rucaptcha.Actions.GETBALANCE;
        /// <summary>
        /// ID ваших капч, разделенные запятыми.
        /// </summary>
        public string Ids { get; set; } = null;
        /// <summary>
        /// ID вашей капчи.
        /// </summary>
        public string Id { get; set; } = null;
    }
}
