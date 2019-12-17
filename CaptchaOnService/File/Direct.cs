using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.File
{
    partial class Direct
    {
        /// <summary>
        /// Создать папку если ее нет
        /// </summary>
        /// <param name="DirectName"></param>
        public void Create(string DirectName)
        {
            if ( !Directory.Exists(DirectName) )
                Directory.CreateDirectory(DirectName);
        }
    }
}
