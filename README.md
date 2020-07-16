# Captcha Service
![GitHub release (latest by date)](https://img.shields.io/github/v/release/odi1n/Captcha-Service)
![Visual Studio Marketplace Version](https://img.shields.io/visual-studio-marketplace/v/1.0.5.0)

Библиотека объединяющая в себе все сервисы для работы с капчей.

|  Капча - Сервис | RuCaptcha | 2Captcha | AntiCaptcha| Cptch|CaptchaGuru | Solvecaptcha| Azcaptcha | X-captcha   | 
| ---             | :---:     | :---:    | :---:      |:---: |:---:       |:---:        |:---:      |:---:        | 
| Image Captcha   |      +    |   +      | +          |     +|      +     |       *     |    *      |             | 
| Text Captcha    |      +    |   +      |            |      |            |       *     |    *      |             |
| ReCaptchaV2     |      +    |   +      |+           |     +|      +     |       *     |    *      |       *     |
| ReCaptchaV3     |      +    |   +      |+           |     +|      +     |             |    *      |             | 
| RecaptchaV2Old  |      +    |   +      |            |      |            |       *     |           |             |
| ClickCaptcha    |      +    |   +      |            |      |            |       *     |           |             |
| RotateCaptcha   |      *    |   *      |            |      |            |       *     |           |             | 
| KeyCaptcha      |      +    |   +      |            |      |            |       *     |           |             |
| GeeTest         |      +    |   +      | +          |      |            |             |           |             |
| hCaptcha        |      +    |   +      | +          |      |      +     |             |           |             |
| Capy Puzzle     |      *    |   *      |            |      |            |             |           |             |
| FunCaptcha      |      +    |   +      | +          |      |            |        *    |           |             |
|  SquareNetText  |           |          | +          |      |            |             |           |             |
| RecaptchaV1     |           |          | +          |      |            |        *    |     *     |             |
| Report          |      +    |    +     | +          |      |            |             |           |             |
| Balance         |      +    |    +     | +          |     +|      +     |        *    |     *     |     *       |
| Другие методы   |      +    |    +     | +          |      |            |        *    |     *     |     *       | 

#### Информация
`+` - Имеется в библиотеке

`*` - В планах добавить
    
#### Используется:
- Newtonsoft.Json
    
## В планах:
  1. Отключения исключения при ошибки решения капчи. Возвращение в переменной
  2. Добавить async
  3. Добавить ссылку на .dll
  4. Сделать метод в который указываем только сервис и идет решение(скорее всего все кроме anticaptcha)
  5. По возможности избавиться от Newtonsoft.Json, взять его методы или сделать свои. Хотелось бы видеть без каких либо библиотек проект
