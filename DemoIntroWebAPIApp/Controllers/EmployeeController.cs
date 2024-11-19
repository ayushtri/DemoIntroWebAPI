using DemoIntroWebAPIApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoIntroWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employee = new List<Employee>
        {
            new Employee() { Id = 123, Name = "Ayush", Gender = "male", Department = "IT", Age = 22, City = "Bhopal" },
            new Employee() { Id = 124, Name = "Nandini", Gender = "female", Department = "CSE", Age = 22, City = "Arizona" },
            new Employee() { Id = 125, Name = "Satvik", Gender = "male", Department = "CSE", Age = 22, City = "Bhopal" },
            new Employee() { Id = 126, Name = "Mansi", Gender = "female", Department = "Idk", Age = 22, City = "Delhi" },
            new Employee() { Id = 127, Name = "Somesh", Gender = "male", Department = "Idk", Age = 22, City = "Bhopal" },
            new Employee() { Id = 128, Name = "Satvik", Gender = "male", Department = "CSE", Age = 22, City = "Bhopal" },
            new Employee() { Id = 129, Name = "Sarabpreet", Gender = "male", Department = "CSE", Age = 22, City = "Bhopal" },
            new Employee() { Id = 130, Name = "Tanya", Gender = "female", Department = "Idk", Age = 22, City = "Delhi" }
        };

        [HttpGet]
        public IActionResult GetEmployee([FromQuery(Name = "Dept")]string Department)
        {
            var employee = _employee.Where(emp => emp.Department.Equals(Department, StringComparison.OrdinalIgnoreCase)).ToList();
            if (employee.Count > 0) 
            { 
                return Ok(employee);
            }
            return NotFound($"No Employee found for Department: {Department}");
        }

        [Route("Emp/Filter")]
        [HttpGet]
        public IActionResult GetEmps([FromQuery] EmpSearch empSearch)
        {
            var empFilters = new List<Employee>();

            if (empSearch != null)
            {
                empFilters = _employee.Where(emp =>
                    emp.Department.Equals(empSearch.Department, StringComparison.OrdinalIgnoreCase) ||
                    emp.Gender.Equals(empSearch.Gender, StringComparison.OrdinalIgnoreCase)
                ).ToList();

                if (empFilters.Count > 0)
                {
                    return Ok(empFilters);
                }
                else
                {
                    return NotFound($"No Employee found for Department {empSearch?.Department} or Gender {empSearch?.Gender}");
                }
            }

            return BadRequest("Invalid Filter");
        }

        [Route("Name")]
        [HttpGet]
        public string GetName()
        {
            return "Return Name";
        }

        [Route("Details")]
        [HttpGet]
        public Employee GetDetails()
        {
            return new Employee()
            { Id = 123, Name = "Ayush", Gender = "male", Department = "IT", Age = 22, City = "Bhopal" };
        }
        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return new List<Employee>()
            {
                new Employee() { Id = 123, Name = "Ayush", Gender = "male", Department = "IT", Age = 22, City = "Bhopal" },
                new Employee() { Id = 124, Name = "Nandini", Gender = "female", Department = "CSE", Age = 22, City = "Arizona" },
                new Employee() { Id = 125, Name = "Satvik", Gender = "male", Department = "CSE", Age = 22, City = "Bhopal" }
            };
        }
        [Route("GetAllEmployees")]
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var AllEmployees = new List<Employee>()
                {
                    new Employee() { Id = 123, Name = "Ayush", Gender = "male", Department = "IT", Age = 22, City = "Bhopal" },
                    new Employee() { Id = 124, Name = "Nandini", Gender = "female", Department = "CSE", Age = 22, City = "Arizona" },
                    new Employee() { Id = 125, Name = "Satvik", Gender = "male", Department = "CSE", Age = 22, City = "Bhopal" }
                };

                if (AllEmployees.Any())
                {
                    return Ok(AllEmployees);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server Error: " + ex.Message);
            }
        }

    }
}
