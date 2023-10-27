
# AspNetCore API Jwt Bearer Identity
TR->

Jwt Bearer kullanarak projenin token bazlı güvenliğinin nasıl sağlanacağını gösteren bu projede;

Öncelikle kişinin sisteme üye olması gerekmektedir. Identity kullanarak üyelik denetimleri yapılmaktadır.
Üye olan kulanıcılar sisteme login olabilirler ve login işlemi başarılı olursa sayfalara ulaşmak için token sahibi olurlar.
Üretilen tokenlar session'da saklanarak kişinin her rquest işleminde requestinin header bölmüne eklenerek API'ya gönderilir.
API'da gelen requestin token kontrolu yapılır ve eşleşme başarılı ise response oluşturulur.

EN->

In this project, which shows how to ensure the token-based security of the project using Jwt Bearer;

Firstly, the person must be a member of the system. Membership checks are carried out using Identity. Users who are members can log in to the system and if the login process is successful, they get tokens to access the pages. The generated tokens are stored in the session and sent to the API by adding them to the header section of the request every time the person makes a request. In the API, the incoming request is token checked and if the match is successful, the response is generated.


## API Kullanımı /API Usage

#### Kayıt ol / Register

```http
  POST /api/Auth/Register
```

| Parametre | Tip     | 
| :-------- | :------- |
|    Id  | `int` |   
|UserName| `string` | 
|PhoneNumber| `string` |
|Email| `string` |
|Password| `string` |
|Email| `string` |

#### Giriş Yap / Login

```http
  POST /api/Auth/Login
```

| Parametre | Tip     | 
| :-------- | :------- |
|UserName| `string` | 
|Password| `string` |

#### Öğeleri getir / Bring items

```http
  GET /api/Emoplooyes
```

| Parametre | Tip     | 
| :-------- | :------- |
|    Id  | `int` |   
|FirstName| `string` | 
|      LastName | `string` |
|   BeginDate    | `DateTime` |
|Phone| `string` |
|Email| `string` |

#### Öğeyi getir / Bring item

```http
  GET /api/Emoplooyes/${id}
```

| Parametre | Tip     | 
| :-------- | :------- |
|    Id  | `int` |   
|FirstName| `string` | 
|      LastName | `string` |
|   BeginDate    | `DateTime` |
|Phone| `string` |
|Email| `string` |



  
