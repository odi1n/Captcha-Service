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
    public class ReportModels : Setting
    {
        /// <summary>
        /// Указан по умолчанию
        /// get — получить ответ на капчу
        /// </summary>
        public string Action { get; set; } 
        /// <summary>
        /// ID капчи, полученный от in.php.
        /// </summary>
        public string Id { get; set; }

        public ReportModels(string id, Actions action ) 
        {
            this.Id = id;
            this.Action = action.ToName();
        }

        public override string ToString()
        {
            var data = new Dictionary<string, object>()
            {
                ["key"] = Key,

                ["action"] = this.Action,
                ["id"] = this.Id,

                ["json"] = Json.GetHashCode(),
            };
            return Converts.StringToDictionary(data); 
        }
    }
}
