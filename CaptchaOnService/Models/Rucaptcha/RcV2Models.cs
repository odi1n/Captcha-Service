﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Rucaptcha
{
    public class RcV2Models : SettingModels
    {
        public string PageUrl { get; set; }
        public string GoogleKey { get; set; }
    }
}