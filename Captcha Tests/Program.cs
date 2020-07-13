﻿using Captcha_Service;
using Captcha_Service.Models.AntiCaptcha.Request;
using Captcha_Service.Models.AntiCaptcha.Request.Task;
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
            //Rucaptcha rc = new Rucaptcha(key[0]);
            //var ttt = rc.GetBalance();
            //var test = rc.Regular(new Regular(@"D:\MyProject\C#\1. Готовые\Captcha\CaptchaTest\CaptchaTest\bin\Debug\captcha.jpg"), 3000);

            //CaptchaGuru cg = new CaptchaGuru(key[2]);
            //var test = cg.GetBalance();

            //CptchNet cptch = new CptchNet(key[1]);
            //cptch.GetBalance();
            //var test = cptch.Regular(new RegularModels(@"D:\MyProject\C#\1. Готовые\Captcha\CaptchaTest\CaptchaTest\bin\Debug\captcha.jpg"), 3000);

            AntiCaptcha ac = new AntiCaptcha(key[3]);
            var image = ac.GetBalance();
            //var balance = ac.GetQueueStats(new GetQueueStats(Captcha_Service.Enums.QueueId.RecaptchaV3s03));

            Console.WriteLine(/*test.Request*/);
            Console.ReadKey();
        }

        private static string[] OpenFile()
        {
            var info = File.ReadAllLines("Keys.txt");
            return info;
        }
    }
}
