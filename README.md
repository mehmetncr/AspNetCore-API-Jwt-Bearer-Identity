
# AspNetCore API Jwt Bearer Identity

Jwt Bearer kullanarak projenin token bazlı güvenliğinin nasıl sağlanacağını gösteren bu projede;

Öncelikle kişinin sisteme üye olması gerekmektedir. Identity kullanarak üyelik denetimleri yapılmaktadır.
Üye olan kulanıcılar sisteme login olabilirler ve login işlemi başarılı olursa sayfalara ulaşmak için token sahibi olurlar.
Üretilen tokenlar session'da saklanarak kişinin her rquest işleminde requestinin header bölmüne eklenerek API'ya gönderilir.
API'da gelen requestin token kontrolu yapılır ve eşleşme başarılı ise response oluşturulur.


## API Kullanımı

#### Kayıt ol

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

#### Giriş Yap

```http
  POST /api/Auth/Login
```

| Parametre | Tip     | 
| :-------- | :------- |
|UserName| `string` | 
|Password| `string` |

#### Öğeleri getir

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

#### Öğeyi getir

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



  
