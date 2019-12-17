using Captcha_Service.Enum.Rucaptcha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Request.Rucaptcha
{
    public class GetBalnceModels : SettingModels
    {

        public ACTION Action { get; set; } = ACTION.GETBALANCE;
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
