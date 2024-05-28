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
        [HttpGet]
        [Route("User")]

        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User userModel)
        {
            if (await _userService.AddUser(userModel))
            {
                return Ok(userModel);
            }
            return NoContent();

        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(User userModel)
        {
            var existingUser = await _userService.GetUser(userModel.UserId);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _userService.UpdateUser(userModel);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            var existingUser = await _userService.GetUser(userId);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _userService.DeleteUser(userId);
            return NoContent();
        }
    }
}
