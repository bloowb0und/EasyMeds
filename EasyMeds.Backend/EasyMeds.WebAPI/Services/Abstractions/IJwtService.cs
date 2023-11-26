using EasyMeds.WebAPI.Core.Constants;

namespace EasyMeds.WebAPI.Services.Abstractions;

public interface IJwtService
{
    public IConfiguration Configuration { get; set; }
    public string GenerateToken(int userId, Role role);
}