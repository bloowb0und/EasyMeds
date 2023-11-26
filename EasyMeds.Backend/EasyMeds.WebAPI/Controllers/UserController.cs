using EasyMeds.WebAPI.Core.Attributes;
using EasyMeds.WebAPI.Core.Constants;
using EasyMeds.WebAPI.Core.DTOs.User;
using EasyMeds.WebAPI.Core.Entities;
using EasyMeds.WebAPI.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyMeds.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService, IJwtService jwtService) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await userService.GetUsersAsync();
        return Ok(users);
    }
    
    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await userService.GetUserAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserDto user)
    {
        try
        {
            await userService.CreateUserAsync(user);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
    
    [HttpPut("{id:int}")]
    [Authorize]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto user)
    {

        try
        {
            await userService.UpdateUserAsync(id, user);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> DeleteUser(int id)
    {
        try
        {
            await userService.DeleteUserAsync(id);
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<string>> Login([FromBody] LoginDto loginDto)
    {
        var user = await userService.LogInAsync(loginDto.Email, loginDto.Password);

        if (user == null)
        {
            return Unauthorized("Invalid username or password");
        }
        
        var token = jwtService.GenerateToken(user.Id, Role.UserRole);
        return Ok(token);
    }
    
    [HttpPost("signup")]
    public async Task<ActionResult> SignUp([FromBody] SignUpDto signUpDto)
    {
        try
        {
            var result = await userService.SignUpAsync(signUpDto);

            if (result)
            {
                return Ok("User registration successful");
            }

            return BadRequest("User with the same email already exists");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
}