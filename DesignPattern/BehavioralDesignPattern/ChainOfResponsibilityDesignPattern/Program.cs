using Microsoft.AspNetCore.Authentication.Cookies;
using ChainOfResponsibilityDesignPattern.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/auth/signin"; // Redirect to SignIn if not authenticated
        options.AccessDeniedPath = "/auth/accessdenied"; // Redirect if access is denied
    });

// Configure Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

// Build the chain of handlers
var authHandler = new AuthenticationHandler();
var roleHandler = new RoleValidationHandler();
var logHandler = new LoggingHandler();

authHandler.SetNext(roleHandler).SetNext(logHandler);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable Authentication and Authorization middlewares
app.UseAuthentication();
app.UseAuthorization();

// Apply Chain of Responsibility only to /auth paths
app.UseWhen(context => context.Request.Path.StartsWithSegments("/auth"), subApp =>
{
    subApp.Use(async (context, next) =>
    {
        await authHandler.HandleAsync(context);

        if (!context.Response.HasStarted)
        {
            await next();
        }
    });
});

// Map controller routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
