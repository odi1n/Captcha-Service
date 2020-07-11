using Captcha_Service.Models.ACRequest.Addition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.ACRequest
{
    [DataContract]
    public class GetBalance : Setting
    {
        public GetBalance(string clientKey)
        {
            this.ClientKey = clientKey;
        }
    }
}
