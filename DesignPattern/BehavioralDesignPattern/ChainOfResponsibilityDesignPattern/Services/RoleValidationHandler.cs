using ChainOfResponsibilityDesignPattern.Classes;

namespace ChainOfResponsibilityDesignPattern.Services
{
    public class RoleValidationHandler : RequestHandlerBase
    {
        public override async Task HandleAsync(HttpContext context)
        {
            // Check if user has "Admin" role, for instance
            bool isAdmin = context.User?.IsInRole("Admin") ?? false;

            if (!isAdmin)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Forbidden: Admin role required");
            }
            else
            {
                // Pass the request further down the chain
                await base.HandleAsync(context);
            }
        }
    }

}
