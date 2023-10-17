namespace AspNetCore_API_Jwt_Bearer.DTOs
{
    public class EmployeeDto   //DTO --> Data Transfer Obje
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BeginDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
