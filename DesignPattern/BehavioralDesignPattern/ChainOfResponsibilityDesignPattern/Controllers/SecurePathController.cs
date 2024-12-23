using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChainOfResponsibilityDesignPattern.Controllers
{
    [Route("auth/[action]")]
    public class SecurePathController : Controller
    {
        [HttpGet]
        public IActionResult Secure()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                var userName = User.Identity.Name;
                var roles = string.Join(", ", User.Claims
                                    .Where(c => c.Type == ClaimTypes.Role)
                                    .Select(c => c.Value));

                return Ok(new
                {
                    Message = "Secure Endpoint Accessed",
                    User = userName,
                    Roles = roles
                });
            }
            else
            {
                return Unauthorized("User is not authenticated.");
            }
        }

    }
}
