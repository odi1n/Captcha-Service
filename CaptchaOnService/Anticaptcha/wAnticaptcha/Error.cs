using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha_Service.Anticaptcha.wAnticaptcha
{
    partial class Error
    {
        public static string ERROR_KEY_DOES_NOT_EXIST = $@"Авторизационный ключ не существует в системе или имеет неверный формат (длина не равняется 32 байтам)";
        public static string ERROR_NO_SLOT_AVAILABLE = $@"Нет свободных работников в данный момент, попробуйте позже либо повысьте свою максимальную ставку здесь";
        public static string ERROR_ZERO_CAPTCHA_FILESIZE = $@"Размер капчи которую вы загружаете менее 100 байт";
        public static string ERROR_TOO_BIG_CAPTCHA_FILESIZE = $@"Размер капчи которую вы загружаете более 500,000 байт";
        public static string ERROR_ZERO_BALANCE = $@"Баланс учетной записи ниже нуля или равен нулю";
        public static string ERROR_IP_NOT_ALLOWED = $@"Запрос с этого IP адреса с текущим ключом отклонен. Управление доступом по IP находится здесь";
        public static string ERROR_CAPTCHA_UNSOLVABLE = $@"5 разных работников не смогли разгадать капчу, задание остановлено";
        public static string ERROR_BAD_DUPLICATES = $@"Не хватило заданного количества дублей капчи для функции 100% распознавания.";
        public static string ERROR_NO_SUCH_METHOD = $@"Запрос в API выполнен на несуществующий метод";
        public static string ERROR_IMAGE_TYPE_NOT_SUPPORTED = $@"Формат капчи не распознан по EXIF заголовку либо не поддерживается. Допустимые форматы: JPG, GIF, PNG";
        public static string ERROR_NO_SUCH_CAPCHA_ID = $@"Капча с таким ID не была найдена в системе. Убедитесь что вы запрашиваете состояние капчи в течение 300 секунд после загрузки.";
        public static string ERROR_EMPTY_COMMENT = $@"Отсутствует комментарий в параметрах рекапчи версии API 1";
        public static string ERROR_IP_BLOCKED = $@"Доступ к API с этого IP запрещен из-за большого количества ошибок. Узнать причину можно здесь.";
        public static string ERROR_TASK_ABSENT = $@"Отсутствует задача в методе createTask.";
        public static string ERROR_TASK_NOT_SUPPORTED = $@"Тип задачи не поддерживается или указан не верно.";
        public static string ERROR_INCORRECT_SESSION_DATA = $@"Неполные или некорректные данные об эмулируемом пользователе. Все требуемые поля не должны быть пустыми.";
        public static string ERROR_PROXY_CONNECT_REFUSED = $@"Не удалось подключиться к прокси-серверу - отказ в подключении";
        public static string ERROR_PROXY_CONNECT_TIMEOUT = $@"Таймаут подключения к прокси-серверу";
        public static string ERROR_PROXY_READ_TIMEOUT = $@"Таймаут операции чтения прокси-сервера.";
        public static string ERROR_PROXY_BANNED = $@"Прокси забанен на целевом сервисе капчи";
        public static string ERROR_PROXY_TRANSPARENT = $@"Ошибка проверки прокси. Прокси должен быть не прозрачным, скрывать адрес конечного пользователя. 
В противном случае Google будет фильтровать запросы с IP нашего сервера. ";
        public static string ERROR_RECAPTCHA_TIMEOUT = $@"Таймаут загрузки скрипта рекапчи, проблема либо в медленном прокси, либо в медленном сервере Google";
        public static string ERROR_RECAPTCHA_INVALID_SITEKEY = $@"Ошибка получаемая от сервера рекапчи. Неверный/невалидный sitekey.";
        public static string ERROR_RECAPTCHA_INVALID_DOMAIN = $@"Ошибка получаемая от сервера рекапчи. Домен не соответствует sitekey.";
        public static string ERROR_RECAPTCHA_OLD_BROWSER = $@"Для задачи используется User-Agent неподдерживаемого рекапчей браузера.";
        public static string ERROR_TOKEN_EXPIRED = $@"Провайдер капчи сообщил что дополнительный изменяющийся токен устарел. Попробуйте создать задачу еще раз с новым токеном.";
        public static string ERROR_PROXY_HAS_NO_IMAGE_SUPPORT = $@"Прокси не поддерживает передачу изображений с серверов Google";
        public static string ERROR_PROXY_INCOMPATIBLE_HTTP_VERSION = $@"Прокси не поддерживает длинные (длиной 2000 байт) GET запросы и не поддерживает SSL подключения";
        public static string ERROR_FACTORY_SERVER_API_CONNECTION_FAILED = $@"Не смогли подключиться к API сервера фабрики в течени 5 секунд.";
        public static string ERROR_FACTORY_SERVER_BAD_JSON = $@"Неправильный JSON ответ фабрики, что-то сломалось.";
        public static string ERROR_FACTORY_SERVER_ERRORID_MISSING = $@"API фабрики не вернул обязательное поле errorId";
        public static string ERROR_FACTORY_SERVER_ERRORID_NOT_ZERO = $@"Ожидали errorId = 0 в ответе API фабрики, получили другое значение.";
        public static string ERROR_FACTORY_MISSING_PROPERTY = $@"Значения некоторых требуемых полей в запросе к фабрике отсутствуют. Клиент должен прислать все требуемы поля.";
        public static string ERROR_FACTORY_PROPERTY_INCORRECT_FORMAT = $@"Тип значения не соответствует ожидаемому в структуре задачи фабрики. Клиент должен прислать значение с требуемым типом.";
        public static string ERROR_FACTORY_ACCESS_DENIED = $@"Доступ к управлению фабрикой принадлежит другой учетной записи. Проверьте свой ключ доступа.";
        public static string ERROR_FACTORY_SERVER_OPERATION_FAILED = $@"Общий код ошибки сервера фабрики.";
        public static string ERROR_FACTORY_PLATFORM_OPERATION_FAILED = $@"Общий код ошибки платформы.";
        public static string ERROR_FACTORY_PROTOCOL_BROKEN = $@"Ошибка в протоколе во время выполнения задачи фабрики.";
        public static string ERROR_FACTORY_TASK_NOT_FOUND = $@"Задача не найдена или недоступна для этой операции.";
        public static string ERROR_FACTORY_IS_SANDBOXED = $@"Фабрика находится в режиме песочницы, создание задач доступно только для владельца фабрики. Переведите фабрику в боевой режим, чтобы сделать ее доступной для всех клиентов.";
        public static string ERROR_PROXY_NOT_AUTHORISED = $@"Заданы неверные логин и пароль для прокси";
        public static string ERROR_FUNCAPTCHA_NOT_ALLOWED = $@"Заказчик не включил тип задач Funcaptcha Proxyless в панели клиентов - Настройки API.
Все заказчики должны прочитать условия, пройти мини тест и подписать/принять форму до того как смогут использовать данный тип задач.";
        public static string ERROR_INVISIBLE_RECAPTCHA = $@"Обнаружена попытка решить невидимую рекапчу в обычном режиме. В случае возникновения этой ошибки вам ничего не нужно предпринимать, наша система через некоторое время начнет решать задачи с этим ключом в невидимом режиме. Просто шлите еще задачи с тем же ключом и доменом.";
        public static string ERROR_FAILED_LOADING_WIDGET = $@"Не удалось загрузить виджет капчи в браузере работника. Попробуйте прислать новую задачу.";
    }
}
