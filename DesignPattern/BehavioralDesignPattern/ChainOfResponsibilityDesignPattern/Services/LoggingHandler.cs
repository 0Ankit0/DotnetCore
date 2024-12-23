using ChainOfResponsibilityDesignPattern.Classes;

namespace ChainOfResponsibilityDesignPattern.Services
{
    public class LoggingHandler : RequestHandlerBase
    {
        public override async Task HandleAsync(HttpContext context)
        {
            // Just log some details
            Console.WriteLine($"[{DateTime.Now}] Request: {context.Request.Method} {context.Request.Path}");

            // Pass the request along
            await base.HandleAsync(context);
        }
    }

}
