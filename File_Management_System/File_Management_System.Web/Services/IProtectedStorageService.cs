using System.Threading.Tasks;

public interface IProtectedStorageService
{
    Task SetAsync<T>(string key, T value);
    Task<T?> GetAsync<T>(string key);
    Task RemoveAsync(string key);
}