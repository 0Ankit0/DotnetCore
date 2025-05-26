using Microsoft.AspNetCore.Components.Forms;
using System.Net;
using System.Net.Http.Json;

namespace File_Management_System.Web;

public class FileApiClient(HttpClient httpClient)
{
    public bool IsUnauthorized { get; private set; }

    public async Task<string[]> ListFilesAsync(CancellationToken cancellationToken = default)
    {
        IsUnauthorized = false;
        try
        {
            var response = await httpClient.GetAsync("/api/files", cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                IsUnauthorized = true;
                // Return empty array; UI can check IsUnauthorized to show login message
                return Array.Empty<string>();
            }
            response.EnsureSuccessStatusCode();
            var files = await response.Content.ReadFromJsonAsync<string[]>(cancellationToken: cancellationToken);
            return files ?? Array.Empty<string>();
        }
        catch (HttpRequestException)
        {
            // Optionally log or handle other errors
            return Array.Empty<string>();
        }
    }

    public async Task<bool> DeleteFileAsync(string fileName, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.DeleteAsync($"/api/delete/{Uri.EscapeDataString(fileName)}", cancellationToken);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UploadFileAsync(IBrowserFile file, CancellationToken cancellationToken = default)
    {
        var content = new MultipartFormDataContent();
        var streamContent = new StreamContent(file.OpenReadStream(long.MaxValue));
        streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
        content.Add(streamContent, "file", file.Name);

        var response = await httpClient.PostAsync("/api/upload", content, cancellationToken);
        return response.IsSuccessStatusCode;
    }
}
