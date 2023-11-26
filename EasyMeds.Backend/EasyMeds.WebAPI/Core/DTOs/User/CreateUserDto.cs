using EasyMeds.WebAPI.Core.Constants;

namespace EasyMeds.WebAPI.Core.DTOs.User;

public record CreateUserDto(string FullName, string Password, string Email);