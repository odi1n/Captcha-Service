namespace Captcha_Service.Anticaptcha.wAnticaptcha
{
    public class JsonSer
    {
        /* Работа с json
         Очень интересно
         https://www.c-sharpcorner.com/article/json-serialization-and-deserialization-in-c-sharp/
         Дополнитель
         https://toster.ru/q/404938
         https://bunkerbook.ru/csharp-lessons/serializatsiya-i-deserializatsiya-dannyh-v-c/
         https://yandex.ua/search/?text=%D1%81%D0%B5%D1%80%D0%B8%D0%B0%D0%BB%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F%20json%20c%23&rdrnd=224419&lr=24876&redircnt=1549665534.1
         */

        #region Информационный функционал
        /// <summary>
        /// Узнать баланс пользователя
        /// </summary>
        public class balance
        {
            /// <summary>
            /// Ключ пользователя
            /// </summary>
            public string clientKey { get; set; }
        }

        /// <summary>
        /// Получить информацию о загрузке очереди
        /// </summary>
        public class getQueueStats
        {
            /// <summary>
            /// Номер очереди. Существуют следующие очереди
            /// </summary>
            public int queueId { get; set; }
        }

        /// <summary>
        /// Получить результат задачи
        /// </summary>
        public class getTaskResult
        {
            /// <summary>
            /// Ключ пользователя
            /// </summary>
            public string clientKey { get; set; }
            /// <summary>
            /// Идентификатор задания полученный в методе createTask
            /// </summary>
            public int taskId { get; set; }
            
        }
        #endregion

        #region Дополнительные данные
        /// <summary>
        /// Класс с основными данными
        /// </summary>
        public class MainInfo
        {
            /// <summary>
            /// Ключ пользователя
            /// </summary>
            public string clientKey { get; set; }
            /// <summary>
            /// Id приложения
            /// </summary>
            public string softId { get; set; }
        }

        /// <summary>
        /// Подключить класс где используется прокси
        /// </summary>
        public class Proxy
        {
            /// <summary>
            /// * http - обычный http/https прокси. 
            /// socks4 - socks4 прокси. 
            /// socks5 - socks5 прокси
            /// </summary>
            public string proxyType { get; set; }
            /// <summary>
            /// * IP адрес прокси ipv4/ipv6. Не допускается:
            /// использование имен хостов. 
            /// использование прозрачных прокси(там где можно видеть IP клиента). 
            /// использование прокси на локальных машинах. 
            /// </summary>
            public string proxyAddress { get; set; }
            /// <summary>
            /// * Порт прокси
            /// </summary>
            public int proxyPort { get; set; }
            /// <summary>
            /// Логин от прокси-сервера
            /// </summary>
            public string proxyLogin { get; set; }
            /// <summary>
            /// Пароль от прокси-сервера
            /// </summary>
            public string proxyPassword { get; set; }
            /// <summary>
            /// * User-Agent браузера, используемый в эмуляции. Необходимо использовать подпись современного браузера, 
            /// иначе Google будет возвращать ошибку, требуя обновить браузер.
            /// </summary>
            public string userAgent { get; set; }
            /// <summary>
            /// Дополнительные cookies которые мы должны использовать во время взаимодействия с целевой страницей.
            /// Формат: cookiename1=cookievalue1; cookiename2=cookievalue2
            /// </summary>
            public string cookies { get; set; }
        }
        #endregion

        #region ImageToTextTask : решение обычной капчи с текстом

        /// <summary>
        /// Решение обычной капчи с текстом
        /// </summary>
        public class ImageToTextTask: MainInfo
        {
            /// <summary>
            /// Параметры передаваемые пользователем
            /// </summary>
            public Task task { get; set; }
            /// <summary>
            /// Класс с параметрами
            /// </summary>
            public class Task
            {
                #region Главные данные
                /// <summary>
                /// * Определяет тип объекта задачи
                /// </summary>
                public string type { get; set; }
                /// <summary>
                /// * Путь к капче которую будем разгадывать
                /// </summary>
                public string body { get; set; }
                #endregion

                #region Второстепенные данные
                /// <summary>
                /// false - нет требований. 
                /// true - работник должен ввести текст с одним или несколькими пробелами
                /// </summary>
                public bool phrase { get; set; }
                /// <summary>
                /// false - нет требований. 
                /// true - работник увидит специальный сигнал что ответ необходимо вводить с учетом регистра
                /// </summary>
                public bool _case { get; set; }
                /// <summary>
                /// 0 - нет требований. 
                /// 1 - можно вводить только цифры. 
                /// 2 - вводить можно любые символы кроме цифр. 
                /// </summary>
                public int numeric { get; set; }
                /// <summary>
                /// false - нет требований. 
                /// true - работник увидит специальный сигнал что на капче изображено математическое выражение и необходимо ввести на него ответ
                /// </summary>
                public bool math { get; set; }
                /// <summary>
                /// 0 - нет требований. 
                /// >1 - определяет минимальную длину ответа
                /// </summary>
                public int minLength { get; set; }
                /// <summary>
                /// 0 - нет требований.     
                /// >1 - определяет максимальную длину ответа 
                /// </summary>
                public int maxLength { get; set; }
                /// <summary>
                /// Дополнительный комментарий к капче на английском языке, напр. "enter letters in red color".
                /// Результат не гарантирован.
                /// </summary>
                public string comment { get; set; }
                #endregion
            }
        }

        #endregion

        #region NoCaptchaTask - Решение капчи от гугл
        /// <summary>
        /// Решение капчи Google
        /// </summary>
        public class NoCaptchaTask : MainInfo
        {
            /// <summary>
            /// Параметры передаваемые пользователем
            /// </summary>
            public Task task { get; set; }
            /// <summary>
            /// Класс с параметрами
            /// </summary>
            public class Task : Proxy
            {
                #region Главные данные
                /// <summary>
                /// * Определяет тип объекта задачи
                /// </summary>
                public string type { get; set; }
                /// <summary>
                /// * Адрес страницы на которой решается капча
                /// </summary>
                public string websiteURL { get; set; }
                /// <summary>
                /// * Ключ-индентификатор рекапчи на целевой странице.
                /// </summary>
                public string websiteKey { get; set; }
                #endregion
                
                #region Второстепенные данные
                /// <summary>
                /// Секретный токен для предыдущей версии рекапчи.
                /// </summary>
                public string websiteSToken { get; set; }
                /// <summary>
                /// Указать что рекапча невидимая. Флаг отобразит соответствующий виджет рекапчи у наших работников.
                /// В большинстве случаев флаг указывать не нужно, т.к.невидимая рекапча распознается автоматически, но на это требуется несколько десятков задач для обучения системы.
                /// </summary>
                public bool isInvisible { get; set; }
                #endregion
            }
        }

        /// <summary>
        /// Решение капчи Google без прокси
        /// </summary>
        public class NoCaptchaTaskProxyless : MainInfo
        {
            /// <summary>
            /// Параметры передаваемые пользователем
            /// </summary>
            public Task task { get; set; }
            /// <summary>
            /// Класс с параметрами
            /// </summary>
            public class Task 
            {
                #region Главные данные
                /// <summary>
                /// * Определяет тип объекта задачи
                /// </summary>
                public string type { get; set; }
                /// <summary>
                /// * Адрес страницы на которой решается капча
                /// </summary>
                public string websiteURL { get; set; }
                /// <summary>
                /// * Ключ-индентификатор рекапчи на целевой странице.
                /// </summary>
                public string websiteKey { get; set; }
                #endregion

                #region Второстепенные данные
                /// <summary>
                /// Секретный токен для предыдущей версии рекапчи.
                /// </summary>
                public string websiteSToken { get; set; }
                /// <summary>
                /// Указать что рекапча невидимая. Флаг отобразит соответствующий виджет рекапчи у наших работников.
                /// В большинстве случаев флаг указывать не нужно, т.к.невидимая рекапча распознается автоматически, но на это требуется несколько десятков задач для обучения системы.
                /// </summary>
                public bool isInvisible { get; set; }
                #endregion
            }
        }
        #endregion

        #region FunCaptchaTask - крутящаяся капча funcaptcha.com
        /// <summary>
        /// Крутящаяся капча funcaptcha.com
        /// </summary>
        public class FunCaptchaTask : MainInfo
        {
            /// <summary>
            /// Параметры передаваемые пользователем
            /// </summary>
            public Task task { get; set; }
            /// <summary>
            /// Класс с параметрами
            /// </summary>
            public class Task : Proxy
            {
                #region Главные данные
                /// <summary>
                /// * Определяет тип объекта задачи
                /// </summary>
                public string type { get; set; }
                /// <summary>
                /// * Адрес страницы на которой решается капча
                /// </summary>
                public string websiteURL { get; set; }
                /// <summary>
                /// * Ключ-индентификатор рекапчи на целевой странице.
                /// </summary>
                public string websitePublicKey { get; set; }
                #endregion

                #region Второстепенные данные
                /// <summary>
                /// Специальный субдомен funcaptcha.com, с которого должен загружаться JS виджет капчи.
                /// Большинство инсталляций фанкапчи работают с общих доменов, поэтому этот параметр нужен только в определенных редких случаях.
                /// </summary>
                public string funcaptchaApiJSSubdomain { get; set; }
                #endregion
            }
        }

        /// <summary>
        /// Крутящаяся капча funcaptcha.com без капчи
        /// </summary>
        public class FunCaptchaTaskProxyless : MainInfo
        {
            /// <summary>
            /// Параметры передаваемые пользователем
            /// </summary>
            public Task task { get; set; }
            /// <summary>
            /// Класс с параметрами
            /// </summary>
            public class Task 
            {
                #region Главные данные
                /// <summary>
                /// * Определяет тип объекта задачи
                /// </summary>
                public string type { get; set; }
                /// <summary>
                /// * Адрес страницы на которой решается капча
                /// </summary>
                public string websiteURL { get; set; }
                /// <summary>
                /// * Ключ-индентификатор рекапчи на целевой странице.
                /// </summary>
                public string websitePublicKey { get; set; }
                #endregion

                #region Второстепенные данные
                /// <summary>
                /// Специальный субдомен funcaptcha.com, с которого должен загружаться JS виджет капчи.
                /// Большинство инсталляций фанкапчи работают с общих доменов, поэтому этот параметр нужен только в определенных редких случаях.
                /// </summary>
                public string funcaptchaApiJSSubdomain { get; set; }
                #endregion
            }
        }

        #endregion

        #region SquareNetTextTask : выбрать нужный объект
        /// <summary>
        /// SquareNetTextTask : выбрать нужный объект на картинке с сеткой изображений
        /// </summary>
        public class SquareNetTextTask : MainInfo
        {
            /// <summary>
            /// Параметры передаваемые пользователем
            /// </summary>
            public Task task { get; set; }
            /// <summary>
            /// Класс с параметрами
            /// </summary>
            public class Task
            {
                /// <summary>
                /// * Определяет тип объекта задачи
                /// </summary>
                public string type { get; set; }
                /// <summary>
                /// * Путь к картинке которую загружаем на решения
                /// </summary>
                public string body { get; set; }
                /// <summary>
                /// * Имя объекта. Пример: banana
                /// </summary>
                public string objectName { get; set; }
                /// <summary>
                /// * Кол-во строк. Min 2, max 5
                /// </summary>
                public int rowsCount { get; set; }
                /// <summary>
                /// * Кол-во колонок. Min 2, max 5
                /// </summary>
                public int columnsCount { get; set; }
            }
        }
        #endregion

        #region GeeTestTask - капча от geetest.com
        /// <summary>
        /// GeeTestTask - капча от geetest.com
        /// </summary>
        public class GeeTestTask : MainInfo
        {
            /// <summary>
            /// Параметры передаваемые пользователем
            /// </summary>
            public Task task { get; set; }
            /// <summary>
            /// Класс с параметрами
            /// </summary>
            public class Task: Proxy
            {
                /// <summary>
                /// * Определяет тип задачи.
                /// </summary>
                public string type { get; set; }
                /// <summary>
                /// * Адрес страницы на которой решается капча
                /// </summary>
                public string websiteURL { get; set; }
                /// <summary>
                /// * Ключ-индентификатор капчи на целевой странице. 
                /// </summary>
                public string gt { get; set; }
                /// <summary>
                /// * Переменный токен который необходимо обновлять каждый раз перед созданием задачи.
                /// </summary>
                public string challenge { get; set; }
                /// <summary>
                /// Опциональный поддомен API. Может понадобиться для некоторых инсталляций.
                /// </summary>
                public string geetestApiServerSubdomain { get; set; }
            }
        }

        /// <summary>
        /// GeeTestTaskProxyless - капча от geetest.com без прокси
        /// </summary>
        public class GeeTestTaskProxyless : MainInfo
        {
            /// <summary>
            /// Параметры передаваемые пользователем
            /// </summary>
            public Task task { get; set; }
            /// <summary>
            /// Класс с параметрами
            /// </summary>
            public class Task 
            {
                /// <summary>
                /// * Определяет тип объекта задачи
                /// </summary>
                public string type { get; set; }
                /// <summary>
                /// * Адрес страницы на которой решается капча
                /// </summary>
                public string websiteURL { get; set; }
                /// <summary>
                /// * Ключ-индентификатор капчи на целевой странице. 
                /// </summary>
                public string gt { get; set; }
                /// <summary>
                /// * Переменный токен который необходимо обновлять каждый раз перед созданием задачи.
                /// </summary>
                public string challenge { get; set; }
                /// <summary>
                /// Опциональный поддомен API. Может понадобиться для некоторых инсталляций.
                /// </summary>
                public string geetestApiServerSubdomain { get; set; }
            }
        }
        #endregion

        #region RecaptchaV1Task : старая версия рекапчи, решение через прокси
        /// <summary>
        /// RecaptchaV1Task : старая версия рекапчи, решение через прокси
        /// </summary>
        public class RecaptchaV1Task : MainInfo
        {
            /// <summary>
            /// Параметры передаваемые пользователем
            /// </summary>
            public Task task { get; set; }
            /// <summary>
            /// Класс с параметрами
            /// </summary>
            public class Task:Proxy
            {
                /// <summary>
                /// * Определяет тип задачи.
                /// </summary>
                public string type { get; set; }
                /// <summary>
                /// * Адрес страницы на которой решается капча
                /// </summary>
                public string websiteURL { get; set; }
                /// <summary>
                /// * Ключ-индентификатор рекапчи на целевой странице.
                /// </summary>
                public string websiteKey { get; set; }
            }
        }

        /// <summary>
        /// RecaptchaV1TaskProxyless : решение старой рекапчи без прокси
        /// </summary>
        public class RecaptchaV1TaskProxyless : MainInfo
        {
            /// <summary>
            /// Параметры передаваемые пользователем
            /// </summary>
            public Task task { get; set; }
            /// <summary>
            /// Класс с параметрами
            /// </summary>
            public class Task 
            {
                /// <summary>
                /// * Определяет тип объекта задачи
                /// </summary>
                public string type { get; set; }
                /// <summary>
                /// * Адрес страницы на которой решается капча
                /// </summary>
                public string websiteURL { get; set; }
                /// <summary>
                /// * Ключ-индентификатор рекапчи на целевой странице.
                /// </summary>
                public string websiteKey { get; set; }
            }
        }
        #endregion
    }
}
