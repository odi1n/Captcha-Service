﻿using Captcha_Service.Addition;
using Captcha_Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Captcha_Service.Models
{
    partial class CheckModels
    {
        /// <summary>
        /// Указан по умолчанию
        /// get — получить ответ на капчу
        /// </summary>
        public Actions Action { get; set; } = Actions.get;
        /// <summary>
        /// ID капчи, полученный от in.php.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 0 — выключен
        /// 1 — включен
        /// Если включен, то in.php добавит заголовок Access-Control-Allow-Origin:* в ответ.
        /// Используется для кроссдоменных AJAX-запросов из веб-приложений.
        /// </summary>
        public int HeaderAcao { get; set; }
        /// <summary>
        /// Время задержки.
        /// По умолчанию 2000мс
        /// </summary>
        public int Sleep { get; set; } = 2000;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="action"></param>
        /// <param name="sleep"></param>
        /// <param name="headerAcao"></param>
        public CheckModels(string id, Actions action = Actions.get, int sleep = 2000, int headerAcao = 0)
        {
            this.Id = id;
            this.Action = action;
            this.Sleep = sleep;
            this.HeaderAcao = headerAcao;
        }

        public override string ToString()
        {
            var Data = new Dictionary<string, object>()
            {
                ["action"] = this.Action,
                ["id"] = this.Id,
                ["header_acao"] = this.HeaderAcao,
            };
            return DictionaryConvert.Deserialization(Data);
        }
    }
}