
# AspNetCore API Jwt Bearer Identity
TR->

Jwt Bearer kullanarak projenin token bazlı güvenliğinin nasıl sağlanacağını gösteren bu projede;

Projenin temeli, kullanıcıların sisteme üye olmaları ve bu üyeliklerin Identity kullanarak denetim altına alınması üzerine kurulmuştur. Üye olan kullanıcılar sisteme giriş yaparak, başarılı bir oturum açma işlemi sonucunda sayfalara ulaşmak için bir token alırlar. Bu tokenlar, oturum süresince session içinde saklanır ve her request işlemi sırasında, kullanıcının request header bölümüne eklenerek API'ya gönderilir.
API tarafında, gelen requestin token kontrolü yapılır ve eğer eşleşme başarılı ise ilgili işlemler gerçekleştirilir ve bir response oluşturulur. Bu sayede, sadece doğrulanan kullanıcılar ve geçerli token'lara sahip olanlar sistemdeki sayfalara erişebilir.
Proje, WT Bearer kullanarak token yönetimi sayesinde güvenlik açısından sağlam bir yapı sunar.


EN->

In this project, which shows how to ensure the token-based security of the project using Jwt Bearer;

The foundation of the project relies on users becoming system members and managing these memberships using Identity. Once users who are members log into the system, they receive a token upon successful login to access the pages. These tokens are stored in the session throughout its duration and are sent to the API by adding them to the user's request header section during each request operation.
On the API side, incoming requests undergo token checks, and if the match is successful, relevant operations are executed, generating a response. This ensures that only verified users with valid tokens can access the pages in the system. The project provides a robust security structure through token management using WT Bearer.


## Kullanılan Teknolojiler / Used technologies

- Asp .NET Core C#

- Kastrel, IIS Express

- MS-SQL Server

- Entity Fremawork Core

- Identity Authorization

- Json Web Token Bearer Authorization

- Generic Repository

- Unit Of Work

- LINQ


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



  
