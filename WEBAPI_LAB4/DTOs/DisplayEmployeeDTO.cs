using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI_LAB4.DTOs
{
    public class DisplayEmployeeDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateOnly HireDate { get; set; }
        public int Salary { get; set; }
        public string Username { get; set; }
    }
}
