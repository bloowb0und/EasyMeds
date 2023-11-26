using EasyMeds.WebAPI.Core.Constants;

namespace EasyMeds.WebAPI.Core.DTOs.User;

public record UpdateUserDto(string Email, string Fullname, string Password);