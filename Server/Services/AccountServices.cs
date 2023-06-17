using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Proj_APBD.Server.Contexts;
using Proj_APBD.Server.Interfaces;
using Proj_APBD.Server.Models;

namespace Proj_APBD.Server.Services;

public class AccountServices : IAccountServices
{
    private readonly Context _context;
    private readonly IConfiguration _config;

    public AccountServices(IConfiguration config, Context context)
    {
        _context = context;
        _config = config;
    }
    
    public async Task<int> Register(string username, string password)
    {
        if (await UserExistsAsync(username)) return 409;
        var passwordHasher = new PasswordHasher<User>();
        var hashedPassword = passwordHasher.HashPassword(new User(), password);
        _context.Users.Add(new User()
        {
            Id = Guid.NewGuid(),
            Username = username,
            Password = hashedPassword
        });
        await _context.SaveChangesAsync();
        return 200;
    }
    
    public async Task<(int, string, string)> Login(string username, string password)
    {
        var users = await _context.Users.ToListAsync();
        var user = users.Find(u => string.Equals(u.Username, username, StringComparison.CurrentCultureIgnoreCase));
        
        if (user is null) return (401, "Invalid Username", "");
        
        var passwordHasher = new PasswordHasher<User>();
        var isVerified = passwordHasher.VerifyHashedPassword(new User(), user.Password, password) == PasswordVerificationResult.Success;

        if (!isVerified) return (401, "Invalid Password", "");

        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = new List<Claim>()
        {
            new ("UserId", user.Id.ToString()),
            new ("Username", user.Username),
            new ("Role", "user")
        };
        
        var tokenDescription = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Issuer = _config["JWT:Issuer"],
            Audience = _config["JWT:Audience"],
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]!)),
                SecurityAlgorithms.HmacSha256
            )
            
        };
        var token = tokenHandler.CreateToken(tokenDescription);
        var strToken = tokenHandler.WriteToken(token);

        var refTokenDescription = new SecurityTokenDescriptor
        {
            Issuer = _config["JWT:RefIssuer"],
            Audience = _config["JWT:RefAudience"],
            Expires = DateTime.UtcNow.AddDays(3),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:RefKey"]!)),
                SecurityAlgorithms.HmacSha256
            )
        };
        var refToken = tokenHandler.CreateToken(refTokenDescription);
        var strRefToken = tokenHandler.WriteToken(refToken);
        
        return (200, strToken, strRefToken);
    }
    
    public (int, string) RefreshToken(string dto)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenHandler.ValidateToken(dto, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _config["JWT:RefIssuer"],
                ValidAudience = _config["JWT:RefAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:RefKey"]!))
            }, out var validatedToken);
            return (200, true + " " +  validatedToken);
        }
        catch
        {
            return (401, "Refresh token has exprired");
        }
    }

    public async Task<bool> UserExistsAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => string.Equals(u.Username, username, StringComparison.CurrentCultureIgnoreCase)) is not null;
    }
}