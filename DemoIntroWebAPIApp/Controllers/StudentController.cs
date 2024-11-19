using DemoIntroWebAPIApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoIntroWebAPIApp.Controllers
{
    //[Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [Route("Student/List")]
        [HttpGet]
        public string GetList()
        {
            return "Hi from Get list";
        }
        [Route("Student/All")]
        [HttpGet]
        public string GetStudent()
        {
            return "Hi from Student Controller";
        }
        [Route("Student/id/{id}/city/{city}")]
        [HttpGet]
        public string GetStudentById(int id, string city)
        {
            return $"Hi from Get student by id: {id} and city: {city}";
        }
        [Route("Student/Get")]
        [HttpGet]
        public string SearchStudent([FromQuery] Student s)
        {
            return $"Data: {s.StudentId}, {s.StudentName}, {s.Address}, {s.Email}";
        }
    }
}
