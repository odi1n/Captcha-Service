using Captcha_Service.Additions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models
{
    partial class SettingCap
    {
        /// <summary>
        /// Ключ от сервиса
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Вид данных
        /// </summary>
        public bool Json { get; set; } = true;
        /// <summary>
        /// Id софт
        /// </summary>
        public int? SoftId { get; set; }
        /// <summary>
        /// Задать данные
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="json">Включить json</param>
        /// <param name="softId">Id софта</param>
        public SettingCap(string key, bool json, int? softId = null)
        {
            this.Key = key;
            this.Json = json;
            this.SoftId = softId;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["key"] = Key,
                ["json"] = Json,
                ["soft_id"] = SoftId,
            };
            var data = Converts.StringToDictionary(Data) + "&";
            return data;
        }
    }
}
