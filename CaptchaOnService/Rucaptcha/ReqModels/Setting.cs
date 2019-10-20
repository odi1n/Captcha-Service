using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Rucaptcha.ReqModels
{
    public class Setting
    {
        public int Sleep { get; set; }
        public bool Json { get; set; } = false;
    }
}
