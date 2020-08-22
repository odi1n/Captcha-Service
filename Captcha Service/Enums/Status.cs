using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Enums
{
    public enum Status
    {
        /// <summary>
        /// Задача в процессе выполнения
        /// </summary>
        processing,
        /// <summary>
        /// Задача выполнена, решение находится в свойстве solution
        /// </summary>
        ready,
    }
}
