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
    public class Addition : Setting
    {
        /// <summary>
        /// Действие которое нужно получить
        /// </summary>
        internal string Action { get; private set; } 
        /// <summary>
        /// ID ваших капч, разделенные запятыми.
        /// </summary>
        public List<string> Ids { get; set; } 
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
        public Addition(Actions action, List<string> ids = null, string id = null)
        {
            this.Action = action.ToName();
            this.Ids = ids;
            this.Id = id;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["key"] = Key,

                ["action"] = this.Action,
                ["id"] = this.Id,
                ["ids"] = Ids == null ? null: string.Join(", ", this.Ids),

                ["json"] = Json.GetHashCode(),
            };

            return Converts.StringToDictionary(Data);
        }
    }
}
