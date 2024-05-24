using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIExample2.IServices;
using WebAPIExample2.Models;

namespace WebAPIExample2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUser(int userId)
        {
            return Ok(await _userService.GetUser(userId));
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User userModel)
        {
            await _userService.AddUser(userModel);
            return Ok("git");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(User userModel)
        {
            await _userService.UpdateUser(userModel);
            return Ok();
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            await _userService.DeleteUser(userId);
            return Ok();
        }
    }
}
