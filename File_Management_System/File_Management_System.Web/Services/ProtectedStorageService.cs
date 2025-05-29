using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Threading.Tasks;

public class ProtectedStorageService : IProtectedStorageService
{
    private readonly ProtectedLocalStorage _protectedLocalStorage;

    public ProtectedStorageService(ProtectedLocalStorage protectedLocalStorage)
    {
        _protectedLocalStorage = protectedLocalStorage;
    }

    public async Task SetAsync<T>(string key, T value)
    {
        await _protectedLocalStorage.SetAsync(key, value);
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var result = await _protectedLocalStorage.GetAsync<T>(key);
        return result.Success ? result.Value : default;
    }

    public async Task RemoveAsync(string key)
    {
        await _protectedLocalStorage.DeleteAsync(key);
    }
}