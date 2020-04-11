using Captcha_Service.Addition;
using Captcha_Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.Rucaptcha.Request
{
    public class AdditionModels 
    {
        /// <summary>
        /// Действие которое нужно получить
        /// </summary>
        public Actions Action { get; set; } 
        /// <summary>
        /// ID ваших капч, разделенные запятыми.
        /// </summary>
        public string Ids { get; set; } 
        /// <summary>
        /// ID вашей капчи.
        /// </summary>
        public string Id { get; set; } 

        /// <summary>
        /// Дополнительные методы
        /// </summary>
        /// <param name="action">Действие которое нужно получить</param>
        /// <param name="ids">Id ваших капч, через запятую</param>
        /// <param name="id">Id капчи</param>
        public AdditionModels(Actions action, string ids = null, string id = null)
        {
            this.Action = action;
            this.Ids = ids;
            this.Id = id;
        }
        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["action"] = this.Action,
                ["id"] = this.Id,
                ["ids"] = this.Ids,
            };

            return DictionaryConvert.Deserialization(Data);
        }
    }
}
