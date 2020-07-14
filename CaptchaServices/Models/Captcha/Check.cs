using Captcha_Service.Additions;
using Captcha_Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Captcha
{
    public class Check
    {
        /// <summary>
        /// Указан по умолчанию
        /// get — получить ответ на капчу
        /// </summary>
        public string Action { get; private set; } = Actions.Get;
        /// <summary>
        /// ID капчи, полученный от in.php.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 0 — выключен
        /// 1 — включен
        /// Если включен, то in.php добавит заголовок Access-Control-Allow-Origin:* в ответ.
        /// Используется для кроссдоменных AJAX-запросов из веб-приложений.
        /// </summary>
        public int HeaderAcao { get; set; }
        /// <summary>
        /// Время задержки.
        /// По умолчанию 2000мс
        /// </summary>
        public int Sleep { get; set; } = 2000;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="action"></param>
        /// <param name="sleep"></param>
        /// <param name="headerAcao"></param>
        public Check(string id, int sleep = 2000, int headerAcao = 0)
        {
            this.Id = id;
            this.Sleep = sleep;
            this.HeaderAcao = headerAcao;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["action"] = this.Action,
                ["id"] = this.Id,
                ["header_acao"] = this.HeaderAcao,
            };
            return Converts.StringToDictionary(Data);
        }
    }
}
