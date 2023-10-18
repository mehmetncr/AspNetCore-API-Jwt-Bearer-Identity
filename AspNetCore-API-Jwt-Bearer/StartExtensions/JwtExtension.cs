using AspNetCore_API_Jwt_Bearer.Context;
using AspNetCore_API_Jwt_Bearer.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AspNetCore_API_Jwt_Bearer.StartExtensions
{
    public static class JwtExtension
    {                                           //program.cs için            appsettings.json için
        public static void AddJwtSettings(this IServiceCollection service, IConfiguration configuration)
        {


            var jwtDefaults = configuration.GetSection("JwtDefaults");  //appsetting deki jwt verilerini almak için
            var secretKey = jwtDefaults["secretKey"]; //içinden secretKey i almak için
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
              
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,   //token üret
                    ValidateAudience = true,  //token denetle
                    ValidateLifetime = true,   //token ömür kontrolleri
                    ValidateIssuerSigningKey = true, //bizim verdiğimiz secret keyi kullan

                    ValidIssuer = jwtDefaults["ValidIssur"], //appsetting deki değeri alır
                    ValidAudience = jwtDefaults["ValidAudience"], //appsettingden değeri alır
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), //bizim verdiğimiz keyi encode eder
                    ClockSkew = TimeSpan.Zero //isteyen cihazla aradaki saat farkını sıfırlar
                };
            });


            service.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;  //karakter istemesin
                options.Password.RequiredLength = 3;  //uzunluğu en az 3 karakter olsun
                options.Password.RequireUppercase = false; //büyük harf istemesin
                options.Password.RequireLowercase = false;  //Küçük harf istemesin
                options.Password.RequireDigit = false; //sayı istemesin
                                                       //options.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvyzqw0123456789";  sadece bunlar kabul edilsin
                                                       //  options.User.RequireUniqueEmail = false; //e mail eşsisiz olmalı
                options.Lockout.MaxFailedAccessAttempts = 3;  //3 yanlış denemeden sonra girişi altaki süre kadar durdur
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);  // üstteki sayı kadaryanlış girişten sonra 1 dk girişi engeller

            }).AddEntityFrameworkStores<BearerDbContext>();

            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Identity"; // Kimlik doğrulama şeması
                options.DefaultChallengeScheme = "Identity"; // Kimlik doğrulama başarısız olduğunda kullanılacak şema
            });



            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            });




            //service.ConfigureApplicationCookie(op =>
            //{
            //    op.LoginPath = new PathString("/Account/Login");   //giriş için sayfaya yönlendir				
            //    op.ExpireTimeSpan = TimeSpan.FromMinutes(10); //cookie ömrü dk
            //                                                  //op.AccessDeniedPath = new PathString("yetisi yok sayfası"); // yetkisi olmayinca yönlendirme
            //    op.SlidingExpiration = true; //üsstteki 10 dk dolmadan tekar login olursa tekrar süreyi başa alır
            //    op.Cookie = new CookieBuilder()
            //    {
            //        Name = "IdentityAppCookie", //cookie adı
            //        HttpOnly = true,  //sadece tarayıcıdan girilsin programlar yakalayamayacak

            //    };

            //});

        }
    }
}
