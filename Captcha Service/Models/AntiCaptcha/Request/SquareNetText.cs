using Captcha_Service.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Models.AntiCaptcha.Request
{
    public class SquareNetText
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("objectName")]
        public string ObjectName { get; set; }

        [JsonProperty("rowsCount")]
        public long RowsCount { get; set; }

        [JsonProperty("columnsCount")]
        public long ColumnsCount { get; set; }

        public SquareNetText(string body, string objectName, int rowsCount, int columnsCount)
        {
            this.Type = Method.SquareNetTextTask;
            this.Body = body;
            this.ObjectName = objectName;
            this.RowsCount = rowsCount;
            this.ColumnsCount = columnsCount;
        }
    }
}
