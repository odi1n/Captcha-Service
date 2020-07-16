﻿using Captcha_Service;
using Captcha_Service.Enums;
using Captcha_Service.Models.Captcha.Other;
using Captcha_Service.Models.Captcha.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = OpenFile();
            RuCaptcha rc = new RuCaptcha(key[0]);
            //var test = rc.Regular(new Regular(new Decode("3.png")), 4000);

            //CaptchaGuru cg = new CaptchaGuru(key[2]);
            //var test = cg.GetBalance();

            CptchNet cptch = new CptchNet(key[1]);
            var test = cptch.Regular(new Regular(new Decode("captcha.jpg")), 3000);
            Console.WriteLine(test.Request);

            var test2 = cptch.Regular(new Regular(new Decode("3.png")), 3000);
            Console.WriteLine(test2.Request);

            //AntiCaptcha ac = new AntiCaptcha(key[3]);
            //var image = ac.GetBalance();
            //var balance = ac.GetQueueStats(new GetQueueStats(Captcha_Service.Enums.QueueId.RecaptchaV3s03));

            Console.ReadKey();
        }

        private static string[] OpenFile()
        {
            var info = File.ReadAllLines("Keys.txt");
            return info;
        }
    }

}
