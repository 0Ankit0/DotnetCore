using Scalar.AspNetCore;
using File_Management_System.ApiService.Models;
using File_Management_System.ApiService.Config;
using File_Management_System.ApiService.Endpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null; // Use PascalCase (default for C# models)
});


// Use extension methods for config
builder.Services.AddIdentityAndDb(builder.Configuration);
builder.Services.AddJwtAuth(builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddTransient<IEmailSender<IdentityUser>, NoOpEmailSender>();

var app = builder.Build();

app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapGet("/", () => Results.Redirect("/scalar")).ExcludeFromDescription();
    app.MapScalarApiReference();
}

string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
}).WithName("GetWeatherForecast");

var uploadDir = Path.Combine(app.Environment.ContentRootPath, "Uploads");
Directory.CreateDirectory(uploadDir);

// Use extension methods for endpoints
app.MapFileEndpoints(uploadDir);
//app.MapAuthEndpoints();
app.MapIdentityApiEndpoint<IdentityUser>();

app.MapDefaultEndpoints();

app.Run();
