using System.Net;
using System.Text.Json;
using System.Web;

namespace File_Management_System.Web;

public class IdentityApiClient(HttpClient httpClient)
{
    public bool IsUnauthorized { get; private set; }

    // 1. POST /register
    public async Task<(bool Success, string? Error)> RegisterAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        var payload = new { Email = email, Password = password };
        var response = await httpClient.PostAsJsonAsync("/register", payload, cancellationToken);
        IsUnauthorized = response.StatusCode == HttpStatusCode.Unauthorized;
        if (response.IsSuccessStatusCode) return (true, null);

        var error = await response.Content.ReadAsStringAsync(cancellationToken);
        return (false, error);
    }

    // 2. POST /login
    public async Task<(bool Success, string? AccessToken, string? Error)> LoginAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        // The endpoint expects: LoginRequest (Email, Password, TwoFactorCode, TwoFactorRecoveryCode)
        var payload = new
        {
            Email = email,
            Password = password,
            TwoFactorCode = (string?)null,
            TwoFactorRecoveryCode = (string?)null
        };
        var response = await httpClient.PostAsJsonAsync("/login", payload, cancellationToken);
        IsUnauthorized = response.StatusCode == HttpStatusCode.Unauthorized;
        if (response.IsSuccessStatusCode)
        {
            // The endpoint returns Ok<AccessTokenResponse> with accessToken property
            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            try
            {
                using var doc = JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("AccessToken", out var tokenProp))
                    return (true, tokenProp.GetString(), null);
            }
            catch (JsonException) { }
            return (true, null, null);
        }
        var error = await response.Content.ReadAsStringAsync(cancellationToken);
        return (false, null, error);
    }

    // 3. POST /refresh
    public async Task<(bool Success, string? AccessToken, string? Error)> RefreshAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        var payload = new { RefreshToken = refreshToken };
        var response = await httpClient.PostAsJsonAsync("/refresh", payload, cancellationToken);
        IsUnauthorized = response.StatusCode == HttpStatusCode.Unauthorized;
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            try
            {
                using var doc = JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("accessToken", out var tokenProp))
                    return (true, tokenProp.GetString(), null);
            }
            catch (JsonException) { }
            return (true, null, null);
        }
        var error = await response.Content.ReadAsStringAsync(cancellationToken);
        return (false, null, error);
    }

    // 4. GET /confirmEmail
    public async Task<(bool Success, string? Message)> ConfirmEmailAsync(string userId, string code, string? changedEmail = null, CancellationToken cancellationToken = default)
    {
        var query = $"userId={HttpUtility.UrlEncode(userId)}&code={HttpUtility.UrlEncode(code)}";
        if (!string.IsNullOrEmpty(changedEmail))
            query += $"&changedEmail={HttpUtility.UrlEncode(changedEmail)}";
        var response = await httpClient.GetAsync($"/confirmEmail?{query}", cancellationToken);
        IsUnauthorized = response.StatusCode == HttpStatusCode.Unauthorized;
        var message = await response.Content.ReadAsStringAsync(cancellationToken);
        return (response.IsSuccessStatusCode, message);
    }

    // 5. POST /resendConfirmationEmail
    public async Task<bool> ResendConfirmationEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var payload = new { Email = email };
        var response = await httpClient.PostAsJsonAsync("/resendConfirmationEmail", payload, cancellationToken);
        IsUnauthorized = response.StatusCode == HttpStatusCode.Unauthorized;
        return response.IsSuccessStatusCode;
    }

    // 6. POST /forgotPassword
    public async Task<bool> ForgotPasswordAsync(string email, CancellationToken cancellationToken = default)
    {
        var payload = new { Email = email };
        var response = await httpClient.PostAsJsonAsync("/forgotPassword", payload, cancellationToken);
        IsUnauthorized = response.StatusCode == HttpStatusCode.Unauthorized;
        return response.IsSuccessStatusCode;
    }

    // 7. POST /resetPassword
    public async Task<bool> ResetPasswordAsync(string email, string resetCode, string newPassword, CancellationToken cancellationToken = default)
    {
        var payload = new { Email = email, ResetCode = resetCode, NewPassword = newPassword };
        var response = await httpClient.PostAsJsonAsync("/resetPassword", payload, cancellationToken);
        IsUnauthorized = response.StatusCode == HttpStatusCode.Unauthorized;
        return response.IsSuccessStatusCode;
    }

    // 8. POST /manage/2fa
    public async Task<(bool Success, string? Response)> TwoFactorAsync(object twoFactorRequest, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/manage/2fa", twoFactorRequest, cancellationToken);
        IsUnauthorized = response.StatusCode == HttpStatusCode.Unauthorized;
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        return (response.IsSuccessStatusCode, content);
    }

    // 9. GET /manage/info
    public async Task<(bool Success, string? Response)> GetInfoAsync(CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync("/manage/info", cancellationToken);
        IsUnauthorized = response.StatusCode == HttpStatusCode.Unauthorized;
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        return (response.IsSuccessStatusCode, content);
    }

    // 10. POST /manage/info
    public async Task<(bool Success, string? Response)> UpdateInfoAsync(object infoRequest, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/manage/info", infoRequest, cancellationToken);
        IsUnauthorized = response.StatusCode == HttpStatusCode.Unauthorized;
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        return (response.IsSuccessStatusCode, content);
    }
}