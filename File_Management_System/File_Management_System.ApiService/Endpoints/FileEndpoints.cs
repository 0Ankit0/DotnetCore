using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace File_Management_System.ApiService.Endpoints;

public static class FileEndpoints
{
    public static void MapFileEndpoints(this WebApplication app, string uploadDir)
    {
        // Helper to get user ID from claims
        string? GetUserId(HttpContext ctx) => ctx.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        app.MapPost("/api/upload", [Authorize] async (HttpContext ctx, HttpRequest request, CancellationToken cancellationToken) =>
        {
            var userId = GetUserId(ctx);
            if (string.IsNullOrEmpty(userId))
                return Results.Unauthorized();

            var userDir = Path.Combine(uploadDir, userId);
            Directory.CreateDirectory(userDir);

            string? fileName = null;
            Stream? fileStream = null;

            if (request.HasFormContentType)
            {
                var form = await request.ReadFormAsync(cancellationToken);
                var file = form.Files.FirstOrDefault();
                if (file is null)
                    return Results.BadRequest("No file uploaded.");
                fileName = file.FileName;
                fileStream = file.OpenReadStream();
            }
            else if (request.ContentType?.StartsWith("application/octet-stream") == true)
            {
                if (request.Headers.TryGetValue("Content-Disposition", out var cdHeader))
                {
                    var cd = cdHeader.ToString();
                    var fileNameMarker = "filename=";
                    var idx = cd.IndexOf(fileNameMarker, StringComparison.OrdinalIgnoreCase);
                    if (idx >= 0)
                    {
                        fileName = cd.Substring(idx + fileNameMarker.Length).Trim(' ', '"');
                    }
                }
                if (string.IsNullOrWhiteSpace(fileName))
                    fileName = Guid.NewGuid().ToString("N");
                fileStream = request.Body;
            }
            else
            {
                return Results.BadRequest("Unsupported content type.");
            }

            var filePath = Path.Combine(userDir, fileName);
            try
            {
                await using var outStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 81920, true);
                await fileStream.CopyToAsync(outStream, cancellationToken);
                return Results.Ok(new { file = fileName });
            }
            catch (OperationCanceledException)
            {
                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);
                return Results.StatusCode(499); // Client Closed Request
            }
        });

        app.MapGet("/api/files", [Authorize] (HttpContext ctx) =>
        {
            var userId = GetUserId(ctx);
            if (string.IsNullOrEmpty(userId))
                return Results.Unauthorized();
            var userDir = Path.Combine(uploadDir, userId);
            if (!Directory.Exists(userDir))
                return Results.Ok(Array.Empty<string>());
            var files = Directory.GetFiles(userDir).Select(Path.GetFileName).ToArray();
            return Results.Ok(files);
        });

        app.MapGet("/api/download/{fileName}", [Authorize] (HttpContext ctx, string fileName) =>
        {
            var userId = GetUserId(ctx);
            if (string.IsNullOrEmpty(userId))
                return Results.Unauthorized();
            var userDir = Path.Combine(uploadDir, userId);
            var filePath = Path.Combine(userDir, fileName);
            if (!System.IO.File.Exists(filePath))
                return Results.NotFound();
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 81920, true);
            var contentType = "application/octet-stream";
            return Results.Stream(stream, contentType, fileName, lastModified: System.IO.File.GetLastWriteTimeUtc(filePath), enableRangeProcessing: true);
        });

        app.MapDelete("/api/delete/{fileName}", [Authorize] (HttpContext ctx, string fileName) =>
        {
            var userId = GetUserId(ctx);
            if (string.IsNullOrEmpty(userId))
                return Results.Unauthorized();
            var userDir = Path.Combine(uploadDir, userId);
            var filePath = Path.Combine(userDir, fileName);
            if (!System.IO.File.Exists(filePath))
                return Results.NotFound();
            System.IO.File.Delete(filePath);
            return Results.Ok();
        });
    }
}
