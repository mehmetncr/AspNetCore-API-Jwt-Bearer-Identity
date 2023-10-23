# AspNetCore-API-Jwt-Bearer-Identity

Jwt Bearer kullanarak projernin token bazlı güvenliğinin nasıl sağlanacağını gösteren bu projede;
Öncelikle kişinin sisteme üye olması gerekmektedir. Identity kullanarak üyelik denetimleri yapılmaktadır.
Üye olan kulanıcılar sisteme login olabilirler ve login işlemi başarılı olursa sayfalra ulaşmak için token sahibi olurlar.
Üretilen tokenlar session'da saklanarak kişinin her rquest işleminde requestinin header bölmüne eklenerek API'ya gönderilir.
API'da gelen requestin token kontrolu yapılır ve eşleşme başarılı ise response oluşturulur.
