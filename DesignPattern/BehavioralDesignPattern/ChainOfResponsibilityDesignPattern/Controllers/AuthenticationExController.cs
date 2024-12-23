using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChainOfResponsibilityDesignPattern.Controllers
{
    public class AuthenticationExController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(string username, string password)
        {
            // For demonstration, we'll use hardcoded credentials.
            // In a real application, validate against a user store.
            if (username == "admin" && password == "password") // Replace with real validation
            {
                // Create the user's claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    // Configure authentication properties as needed
                    IsPersistent = true, // Persist across sessions
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
                };

                // Sign in the user
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index");
            }

            // If credentials are invalid
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            // Sign out the user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        // GET: /auth/accessdenied
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return Forbid("Access Denied.");
        }

    }
}
