using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service
{
    partial class Converts
    {
        internal static string ImageToBase64(byte[] bytePhoto)
        {
            return Convert.ToBase64String(bytePhoto);
        }

        internal static byte[] FileStreamToByte(FileStream fstream)
        {
            // чтение из файла
            using (fstream)
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                //string textFromFile = System.Text.Encoding.Default.GetString(array);
                return array;
            }
        }

        internal static byte[] MemoryStreamToByte(MemoryStream instream)
        {
            if (instream is MemoryStream)
                return (instream).ToArray();

            using (var memoryStream = new MemoryStream())
            {
                instream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        internal static byte[] StreamToByte(Stream instream)
        {
            if (instream is MemoryStream)
                return ((MemoryStream)instream).ToArray();

            using (var memoryStream = new MemoryStream())
            {
                instream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        internal static String UriToByte(Uri uri)
        {
            StringBuilder _sb = new StringBuilder();
            Byte[] _byte = GetImageToLink(uri.AbsoluteUri);
            _sb.Append(Convert.ToBase64String(_byte, 0, _byte.Length));
            return _sb.ToString();
        }

        internal static byte[] GetImageToLink(string url)
        {
            Stream stream = null;
            byte[] buf;

            try
            {
                WebProxy myProxy = new WebProxy();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                stream = response.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    int len = (int)(response.ContentLength);
                    buf = br.ReadBytes(len);
                    br.Close();
                }

                stream.Close();
                response.Close();
            }
            catch
            {
                buf = null;
            }

            return (buf);
        }

        internal static string StringToDictionary(Dictionary<string, object> dict)
        {
            string str = string.Empty;

            foreach (KeyValuePair<string, object> entry in dict)
            {
                if (entry.Value != null)
                {
                    if (str.Length > 0) str += "&";
                    if (entry.Value.ToString().Length == 0) continue;

                    var key = entry.Key != null ? entry.Key.ToString() : null;
                    var value = entry.Value != null ? entry.Value.ToString() : null;

                    int? bools = null;
                    try { if ((bool)entry.Value) bools = Convert.ToBoolean(entry.Value).GetHashCode(); value = null; } catch { }

                    str += key + "=" + value + bools;
                }
            }
            return str;
        }

        /// <summary>
        /// Сериализирует данные с класса в строку типа string 
        /// </summary>
        /// <param name="Serial">Что нужно привести в нормальный вид</param>
        /// <returns></returns>
        internal static string JsonSerializer(object Serial)
        {
            var Settings = new Newtonsoft.Json.JsonSerializerSettings();
            Settings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Populate;
            return JsonConvert.SerializeObject(Serial, Settings);
        }

        /// <summary>
        /// Десериализирует данные с json в строку
        /// </summary>
        /// <returns></returns>
        internal static T JsonDeserializ<T>(string Deserial)
        {
            return JsonConvert.DeserializeObject<T>(Deserial);
        }
    }
}
