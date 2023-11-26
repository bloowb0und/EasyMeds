using EasyMeds.WebAPI.Core.DTOs.User;
using EasyMeds.WebAPI.Core.Entities;

namespace EasyMeds.WebAPI.Services.Abstractions;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User?> GetUserAsync(int id);
    Task CreateUserAsync(CreateUserDto user);
    Task UpdateUserAsync(int id, UpdateUserDto user);
    Task DeleteUserAsync(int id);
    Task<User?> LogInAsync(string email, string password);
    Task<bool> SignUpAsync(SignUpDto signUpDto);
}