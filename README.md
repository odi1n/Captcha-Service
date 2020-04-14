# Captcha Service
Библиотека которая объединяет в себе сервисы для работы с капчей.

На данные момент имеется 2 сервиса:
1. Rucaptcha:
  - [x] Обычные капчи
  - [x] Текстовые капчи
  - [x] ReCaptcha V2
  - [x] ReCaptcha V3
  - [x] Дополнительные методы
  - [x] Отчет об ответах - Report
  - [x] ReCaptcha V2 (устаревший метод) - RecaptchaV2Old
  - [x] ClickCaptcha
  - RotateCaptcha
  - [x] FunCaptcha с токеном
  - [x] KeyCaptcha
  - [x] GeeTest
  - [x] hCaptcha
2. AntiCaptcha:
  - [x] createTask 
  - [x] getTaskResult
  - [x] getBalance
  - getQueueStats
  - reportIncorrectImageCaptcha 
  - reportIncorrectRecaptcha
  - getSpendingStats 
  - getAppStats 
  - sendFunds
  - test
  - [x] ImageToTextTask
  - [x] NoCaptchaTask
  - [x] NoCaptchaTaskProxyless
  - RecaptchaV3TaskProxyless
  - [x] FunCaptchaTask
  - [x] FunCaptchaTaskProxyless 
  - [x] SquareNetTextTask
  - [x] GeeTestTask 
  - [x] GeeTestTaskProxyless 
  - HCaptchaTask
  - HCaptchaTaskProxyless 
  - CustomCaptchaTask
  - [x] RecaptchaV1Task 
  - [x] RecaptchaV1TaskProxyless
3. Cptch.net
  - [x] getBalance
  - [x] ReCaptcha V2
  - [x] Решение картинки
4. Captcha.guru
  - [x] getBalance
  - [x] ReCaptcha V2
  - [x] Решение картинки
  
# В планах добавить:
  - Новые сервисы:
    - 2Captcha
    - solvecaptcha.com
    - azcaptcha.com
    - x-captcha.ru
    - DeCaptcher
    - DeathByCaptcha
    - XEvil
  - Изменить:
    - anti-captcha
  - Отключения исключения при ошибки решения капчи. Возвращение в переменной
  - Добавить async
  - Вынести все в интерфейсы
  - Добавить ссылку на .dll
  
так же можете предлагать свои идеи.
