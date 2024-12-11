using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_LAB4.DTOs;
using WEBAPI_LAB4.Models;

namespace WEBAPI_LAB4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        CompanyContext companyContext;
        public EmployeesController(CompanyContext companyContext)
        {
            this.companyContext = companyContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Employee> emps = companyContext.Employees.ToList();
            List<DisplayEmployeeDTO> empsDTO = new List<DisplayEmployeeDTO>();

            foreach(Employee emp in emps)
            {
                DisplayEmployeeDTO empDTO = new DisplayEmployeeDTO()
                {
                    Name = emp.Name,
                    Salary = (int)emp.Salary,
                    Email = emp.Email,
                    Username = emp.Username,
                    HireDate = (DateOnly)emp.HireDate
                };
                empsDTO.Add(empDTO);
            }

            if (empsDTO != null) return Ok(empsDTO);
            else return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            Employee emp = companyContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (emp != null)
            {
                DisplayEmployeeDTO empDTO = new DisplayEmployeeDTO()
                {
                    Name = emp.Name,
                    Salary = (int)emp.Salary,
                    Email = emp.Email,
                    Username = emp.Username,
                    HireDate = (DateOnly)emp.HireDate
                };
                return Ok(empDTO);
            }
            else return NotFound();
        }
        [HttpPost]
        public IActionResult Add(AddEmployeeDTO empDTO) 
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee()
                {
                    Name= empDTO.Name,
                    Salary = empDTO.Salary,
                    Email = empDTO.Email,
                    Username = empDTO.Username,
                    HireDate = empDTO.HireDate,
                    Password = empDTO.Password,
                    Photo = empDTO.Photo.FileName
                };
                companyContext.Employees.Add(emp);
                companyContext.SaveChanges();
                return Ok(companyContext.Employees.ToList());
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

    }
}
