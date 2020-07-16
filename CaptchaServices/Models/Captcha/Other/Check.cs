using Captcha_Service.Additions;
using Captcha_Service.Enums;
using Captcha_Service.Models.Captcha.Addition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Captcha.Other
{
    public class Check : Setting
    {
        /// <summary>
        /// Указан по умолчанию
        /// get — получить ответ на капчу
        /// </summary>
        public Actions Action { get; private set; } = Actions.Get;
        /// <summary>
        /// ID капчи, полученный от in.php.
        /// </summary>
        public string Id { get; set; }
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
        public Check(string id, int sleep = 2000, bool headerAcao = false)
        {
            this.Id = id;
            this.Sleep = sleep;
            this.HeaderAcao = headerAcao;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["key"] = Key,

                ["action"] = this.Action.ToName(),
                ["id"] = this.Id,
                ["header_acao"] = this.HeaderAcao,

                ["json"] = Json.GetHashCode(),
            };
            return Converts.StringToDictionary(Data);
        }
    }
}
