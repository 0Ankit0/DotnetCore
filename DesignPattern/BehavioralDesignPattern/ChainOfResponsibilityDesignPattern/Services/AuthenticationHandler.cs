using ChainOfResponsibilityDesignPattern.Classes;

namespace ChainOfResponsibilityDesignPattern.Services
{
    public class AuthenticationHandler : RequestHandlerBase
    {
        public override async Task HandleAsync(HttpContext context)
        {
            // For demonstration, let's assume a simplified authentication check
            bool isAuthenticated = context.User?.Identity?.IsAuthenticated ?? false;

            if (!isAuthenticated)
            {
                // If not authenticated, return a 401 Unauthorized
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync($"Unauthorized. The users authenticated value is {isAuthenticated}");
            }
            else
            {
                // If authenticated, pass along to the next handler
                await base.HandleAsync(context);
            }
        }
    }

}
