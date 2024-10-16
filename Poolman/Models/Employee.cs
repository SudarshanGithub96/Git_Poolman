namespace Poolman.Models
{
    public class Employee
    {
        public int EmployeeLog_Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; } 
        public string? Username { get; set; } 
        public string? Password{ get; set; } 
        public string? ConfirmPassword{ get; set; } 
        public int  Age{ get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public int Zipcode { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
