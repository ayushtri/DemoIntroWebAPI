﻿using DemoIntroWebAPIApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoIntroWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
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