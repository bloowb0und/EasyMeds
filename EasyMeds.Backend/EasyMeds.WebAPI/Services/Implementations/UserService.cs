using EasyMeds.WebAPI.Core.Contexts;
using EasyMeds.WebAPI.Core.DTOs.User;
using EasyMeds.WebAPI.Core.Entities;
using EasyMeds.WebAPI.Services.Abstractions;
using EasyMeds.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EasyMeds.WebAPI.Services.Implementations;

public class UserService(EasyMedsDbContext context) : IUserService
{
    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<User?> GetUserAsync(int id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task CreateUserAsync(CreateUserDto user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }
        
        var (hashedPassword, salt) = UserHelper.HashPassword(user.Password);
        
        context.Users.Add(new User
        {
            Email = user.Email,
            Password = hashedPassword,
            Salt = salt, 
            Fullname= user.FullName,
        });
        
        await context.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(int id, UpdateUserDto user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        var userDb = await context.FindAsync<User>(id);
        
        if (userDb == null)
        {
            throw new ArgumentNullException(nameof(user));
        }
        
        userDb.Email = user.Email;
        userDb.Fullname = user.Fullname;
        
        var (hashedPassword, salt) = UserHelper.HashPassword(user.Password);

        userDb.Password = hashedPassword;
        userDb.Salt = salt;
        
        context.Users.Update(userDb);
        
        await context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user != null)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }

    public async Task<User?> LogInAsync(string email, string password)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
        
        if (user != null && UserHelper.IsPasswordValid(password, user.Password, user.Salt))
        {
            return user;
        }

        return null;
    }

    public async Task<bool> SignUpAsync(SignUpDto signUpDto)
    {
        var existingUser = await context.Users.FirstOrDefaultAsync(u => u.Email == signUpDto.Email);

        if (existingUser != null)
        {
            return false;
        }
        
        var (hashedPassword, salt) = UserHelper.HashPassword(signUpDto.Password);
        
        var newUser = new User
        {
            Email = signUpDto.Email,
            Password = hashedPassword,
            Salt = salt,
            Fullname = signUpDto.Fullname,
        };

        context.Users.Add(newUser);
        await context.SaveChangesAsync();

        return true;
    }
}