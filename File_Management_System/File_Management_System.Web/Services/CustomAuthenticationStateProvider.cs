using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace File_Management_System.Web.Components;

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

        var jwt = await _protectedStorageService.GetAsync<string>("jwt");
        if (!string.IsNullOrEmpty(jwt))
        {
            // In a real app, parse JWT and extract claims. Here, just create a dummy identity.
            identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "User")
            }, "jwtAuthType");
        }
        else
        {
            identity = new ClaimsIdentity();
        }

        var user = new ClaimsPrincipal(identity);
        return new AuthenticationState(user);
    }

    public void NotifyAuthenticationStateChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}