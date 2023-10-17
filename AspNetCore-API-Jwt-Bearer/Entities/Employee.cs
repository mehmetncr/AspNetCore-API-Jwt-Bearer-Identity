namespace AspNetCore_API_Jwt_Bearer.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BeginDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
