using System;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace File_Management_System.Web.Services;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IProtectedStorageService _protectedStorageService;

    public CustomAuthenticationStateProvider(IProtectedStorageService protectedStorageService)
    {
        _protectedStorageService = protectedStorageService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
       

        ClaimsIdentity identity;
        try
        {
            var jwt = await _protectedStorageService.GetAsync<string>("jwt");
            if (!string.IsNullOrEmpty(jwt))
            {
                // Parse JWT and extract claims
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, "User"));
                claims.Add(new Claim("jwt", jwt)); // Store the JWT as a claim
                identity = new ClaimsIdentity(claims, "jwtAuthType");
            }
            else
            {
                identity = new ClaimsIdentity();
            }

            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }catch(Exception ex){
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        }
    }

    public void NotifyAuthenticationStateChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public void NotifyUserAuthentication(string jwt)
    {
        // Optionally, you could parse the JWT and extract claims here
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public void NotifyUserLogout()
    {
        // Notify all consumers that the user is now logged out (identity will be empty)
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}