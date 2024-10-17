using KhoThoExe.Data;
using KhoThoExe.DTOs;
using KhoThoExe.Interfaces;
using KhoThoExe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KhoThoExe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserDto userDto)
        {
            await _userService.CreateUserAsync(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = userDto.UserID }, userDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserDto userDto)
        {
            if (id != userDto.UserID) return BadRequest();
            await _userService.UpdateUserAsync(id, userDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
