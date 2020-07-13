using Captcha_Service.Models.AntiCaptcha.Request.Addition;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Request
{
    public class SendFunds : Setting
    {
        [JsonProperty( "accountLogin")]
        public string AccountLogin { get; set; }
        [JsonProperty( "accountEmail")]
        public string AccountEmail { get; set; }
        [JsonProperty( "amount")]
        public double Amount { get; set; }

        public SendFunds(double amount)
        {
            this.Amount = amount;
        }
    }
}
