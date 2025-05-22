using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using File_Management_System.ApiService.Data;

namespace File_Management_System.ApiService.Config;

public static class IdentityConfig
{
    public static void AddIdentityAndDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection") ?? "Host=localhost;Database=FileManagementSystem;Username=postgres;Password=yourpassword"));
        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    }
}
