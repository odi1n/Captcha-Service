using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Rucaptcha.ReqModels
{
    public class GetBalance
    {
        public string Key { get; set; }
        public bool Json {get;set;} = false;
    }
}
