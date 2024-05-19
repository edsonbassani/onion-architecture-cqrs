using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.TaskManager.Application.DTOs;
using OnionArchitecture.TaskManager.Application.Interfaces;

namespace OnionArchitecture.TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDTO userDto)
        {
            await _userService.AddUserAsync(userDto);
            return CreatedAtAction(nameof(CreateUser), new { id = userDto.Id }, userDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserDTO user)
        {
            await _userService.UpdateUserAsync(user);
            return Ok(user);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok($"{{ \"User successfully deleted {id}\" }}");
        }
    }
}
