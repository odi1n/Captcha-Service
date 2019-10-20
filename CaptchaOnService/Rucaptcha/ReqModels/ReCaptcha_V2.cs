using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Rucaptcha.ReqModels
{
    public class ReCaptcha_V2
    {
        public string Page_url { get; set; }
        public string Google_key { get; set; }
        public int Sleep { get; set; }
        public bool Json { get; set; } = false;
    }
}
