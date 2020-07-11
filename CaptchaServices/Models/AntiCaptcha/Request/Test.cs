using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Request
{
    public class Test
    {
        [DataMember(Name="hello")]
        public string Hello {get;set;}
        [DataMember(Name="apiTest")]
        public string ApiTest { get;set; }

        public Test(string hello, string apiTest)
        {
            this.Hello = hello;
            this.ApiTest = apiTest;
        }
    }
}
