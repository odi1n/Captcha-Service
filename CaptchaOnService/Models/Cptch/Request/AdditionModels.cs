using Captcha_Service.Addition;
using Captcha_Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Cptch.Request
{
    public class AdditionModels 
    {
        /// <summary>
        /// Действие которое нужно получить
        /// </summary>
        public Actions Action { get; set; } 

        /// <summary>
        /// Дополнительные методы
        /// </summary>
        /// <param name="action">Действие которое нужно получить</param>
        /// <param name="ids">Id ваших капч, через запятую</param>
        /// <param name="id">Id капчи</param>
        public AdditionModels(Actions action)
        {
            this.Action = action;
        }
        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["action"] = this.Action,
            };

            return DictionaryConvert.Deserialization(Data);
        }
    }
}
