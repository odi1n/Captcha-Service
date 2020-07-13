using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Captcha_Service.Additions
{
    public class JsonConverts
    {

        /// <summary>
        /// Сериализирует данные с класса в строку типа string 
        /// </summary>
        /// <param name="Serial">Что нужно привести в нормальный вид</param>
        /// <returns></returns>
        public static string Serializer(object Serial)
        {
            var Settings = new Newtonsoft.Json.JsonSerializerSettings();
            Settings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Populate;
            return JsonConvert.SerializeObject(Serial, Settings);
        }

        /// <summary>
        /// Десериализирует данные с json в строку
        /// </summary>
        /// <returns></returns>
        public static T Deserializ<T>(string Deserial)
        {
            return JsonConvert.DeserializeObject<T>(Deserial);
        }
    }
}
