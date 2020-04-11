using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Captcha_Service.Addition
{
    public class JsonConvert
    {
        /// <summary>
        /// Сериализирует данные с класса в строку типа string 
        /// </summary>
        /// <param name="Serial">Что нужно привести в нормальный вид</param>
        /// <returns></returns>
        public static string Serializer(object Serial)
        {
            var js = new JavaScriptSerializer();
            return js.Serialize(Serial);
        }

        /// <summary>
        /// Десериализирует данные с json в строку
        /// </summary>
        /// <returns></returns>
        public static T Deserializ<T>(string Deserial)
        {
            JavaScriptSerializer json = new JavaScriptSerializer();

            var jsonObject = json.Deserialize<T>(Deserial);

            return jsonObject;
        }
    }
}
