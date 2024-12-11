using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WEBAPI_LAB4.DTOs
{
    public class AddEmployeeDTO
    {
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "invalid email")]
        public string Email { get; set; }
        public DateOnly HireDate { get; set; }
        [Range(1200, 20000, ErrorMessage = "Salary must between 1200 and 20000")]
        public int Salary { get; set; }
        [MinLength(10,ErrorMessage ="Username must be greater than 10 characters")]
        public string Username { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "password not matched")]
        public string ConfirmPassword { get; set; }
        public IFormFile Photo { get; set; }
    }
}
