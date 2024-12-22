using Microsoft.AspNetCore.SignalR;
using ObserverDesignPattern.Services;
using ObserverDesignPattern.Services.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1) Add SignalR services
builder.Services.AddSignalR();

// 2) Register MetricsProvider as Singleton
builder.Services.AddSingleton<MetricsProvider>();

// 3) Register an observer that depends on IHubContext<MetricsHub>
//    We'll inject the observer in a hosted service so that it stays alive 
//    and subscribes to the MetricsProvider once on startup.
builder.Services.AddSingleton<MetricsHubObserver>();

// 4) A background service to wire them up
builder.Services.AddHostedService<MetricsSubscriptionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapHub<MetricsHub>("/metricsHub");

app.Run();
