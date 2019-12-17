using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Rucaptcha
{
    public class SettingModels
    {
        /// <summary>
        /// Задержка в мс.
        /// </summary>
        public int Sleep { get; set; } = 500;
        /// <summary>
        /// По умолчанию отключен.
        /// 0 — сервер отправит ответ в виде простого текста
        /// 1 — сервер отправит ответ в формате JSON
        /// </summary>
        public bool Json { get; set; } = false;
    }
}
