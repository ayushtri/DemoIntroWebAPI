using DemoIntroWebAPIApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoIntroWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromForm] User user)
        {
            if (user.ProfilePic != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }
                var filePath = Path.Combine(uploadsFolderPath, user.ProfilePic.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await user.ProfilePic.CopyToAsync(stream);
                }

                var response = new
                {
                    Success = true,
                    Message = $"User {user.UserName} created with {user.Email}!",
                    ProfilePic = user.ProfilePic.FileName,
                    Code = StatusCodes.Status200OK
                };

                return Ok(response);
            }

            return BadRequest(ModelState);
        }
    }
}
