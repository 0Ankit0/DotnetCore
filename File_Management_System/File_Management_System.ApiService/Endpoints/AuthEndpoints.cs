using Microsoft.AspNetCore.Identity;
using File_Management_System.ApiService.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace File_Management_System.ApiService.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/api/account/register", async (UserManager<IdentityUser> userManager, RegisterRequest req) =>
        {
            var user = new IdentityUser { UserName = req.UserName, Email = req.Email };
            var result = await userManager.CreateAsync(user, req.Password);
            if (!result.Succeeded)
                return Results.BadRequest(result.Errors);
            return Results.Ok();
        });

        app.MapPost("/api/account/login", async (UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration config, LoginRequest req) =>
        {
            var user = await userManager.FindByNameAsync(req.UserName);
            if (user == null)
                return Results.Unauthorized();
            var result = await signInManager.CheckPasswordSignInAsync(user, req.Password, false);
            if (!result.Succeeded)
                return Results.Unauthorized();

            // Create JWT
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName ?? ""),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"] ?? "your_secret_key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddDays(7);
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"] ?? "yourIssuer",
                audience: config["Jwt:Audience"] ?? "yourAudience",
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Results.Ok(new { token = tokenString });
        });
    }
}
