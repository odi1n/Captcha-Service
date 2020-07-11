using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Captcha_Service.Addition
{
    public class JsonConverts
    {
        /// <summary>
        /// Сериализирует данные с объекта в строку
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="Data">Данные</param>
        /// <returns></returns>
        public static string Serializer<T>(object Data)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
            MemoryStream msObj = new MemoryStream();
            js.WriteObject(msObj, Data);
            msObj.Position = 0;
            StreamReader sr = new StreamReader(msObj);

            string json = sr.ReadToEnd();

            sr.Close();
            msObj.Close();
            return json;
        }

        /// <summary>
        /// Десериализирует данные с json в строку
        /// </summary>
        /// <returns></returns>
        public static T Deserializ<T>(string json)
        {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));
                var des = (T)deserializer.ReadObject(ms);
                return des;
            }
        }
    }
}
