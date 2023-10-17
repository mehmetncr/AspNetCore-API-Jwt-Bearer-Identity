namespace AspNetCore_Mvc_Jwt_Bearer.Models
{
    public class TokenViewModel
    {
        public string AccessToken { get; set; } // Erişim tokeni
        public string TokenType { get; set; }   // Token türü (örneğin, "Bearer")
        public int ExpiresIn { get; set; }      // Tokenin geçerlilik süresi (saniye cinsinden)
                                                // Diğer ilgili bilgileri ekleyebilirsiniz
    }
}
