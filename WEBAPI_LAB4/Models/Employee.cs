using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI_LAB4.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public DateOnly? HireDate { get; set; }
        public int? Salary { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }
        public string? Photo {  get; set; }  

    }
}
