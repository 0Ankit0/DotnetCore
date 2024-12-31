using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StateDesignPattern.Models;

namespace StateDesignPattern.Services
{
	public class SongService
	{
		private readonly HttpClient _httpClient;

		public SongService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<TrackModel>> GetTracksAsync()
		{
			var response = await _httpClient.GetAsync("https://api.deezer.com/chart");
			if (!response.IsSuccessStatusCode)
			{
				throw new HttpRequestException("Failed to fetch tracks.");
			}

			var content = await response.Content.ReadAsStringAsync();

			// Parse the JSON response
			var jsonDoc = JsonDocument.Parse(content);
			var rootElement = jsonDoc.RootElement;

			if (!rootElement.TryGetProperty("tracks", out var tracksElement) ||
				!tracksElement.TryGetProperty("data", out var tracksDataElement) ||
				tracksDataElement.ValueKind != JsonValueKind.Array)
			{
				throw new JsonException("Invalid or missing 'tracks' data in the API response.");
			}

			var tracks = new List<TrackModel>();

			foreach (var trackJson in tracksDataElement.EnumerateArray())
			{
				try
				{
					var track = new TrackModel
					{
						Id = GetInt(trackJson, "id"),
						Title = GetString(trackJson, "title"),
						Duration = GetInt(trackJson, "duration"),
						Link = GetString(trackJson, "link"),
						Preview = GetString(trackJson, "preview", true),
						Md5Image = GetString(trackJson, "md5_image", true),
						ExplicitLyrics = GetBool(trackJson, "explicit_lyrics", true),
						Artist = GetArtist(trackJson),
						Album = GetAlbum(trackJson)
					};

					tracks.Add(track);
				}
				catch (Exception ex)
				{
					// Log and skip problematic tracks
					Console.WriteLine($"Error processing track: {ex.Message}");
				}
			}

			return tracks;
		}

		private static ArtistModel GetArtist(JsonElement trackJson)
		{
			if (trackJson.TryGetProperty("artist", out var artistJson))
			{
				return new ArtistModel
				{
					Id = GetInt(artistJson, "id"),
					Name = GetString(artistJson, "name"),
					Link = GetString(artistJson, "link", true),
					PictureSmall = GetString(artistJson, "picture_small", true),
					PictureMedium = GetString(artistJson, "picture_medium", true),
					PictureBig = GetString(artistJson, "picture_big", true),
					PictureXl = GetString(artistJson, "picture_xl", true)
				};
			}

			// Return a default artist if none exists
			return new ArtistModel
			{
				Name = "Unknown Artist",
				Link = "#",
				PictureSmall = "/path/to/default-artist-image.jpg"
			};
		}

		private static AlbumModel GetAlbum(JsonElement trackJson)
		{
			if (trackJson.TryGetProperty("album", out var albumJson))
			{
				return new AlbumModel
				{
					Id = GetInt(albumJson, "id"),
					Title = GetString(albumJson, "title"),
					CoverSmall = GetString(albumJson, "cover_small", true),
					CoverMedium = GetString(albumJson, "cover_medium", true),
					CoverBig = GetString(albumJson, "cover_big", true),
					CoverXl = GetString(albumJson, "cover_xl", true)
				};
			}

			// Return a default album if none exists
			return new AlbumModel
			{
				Title = "Unknown Album",
				CoverSmall = "/path/to/default-album-cover.jpg"
			};
		}

		// Helper methods to safely extract values
		private static int GetInt(JsonElement json, string propertyName, bool optional = false)
		{
			if (json.TryGetProperty(propertyName, out var element) && element.ValueKind == JsonValueKind.Number)
			{
				return element.GetInt32();
			}
			if (optional) return 0; // Return default for optional values
			throw new JsonException($"Property '{propertyName}' is missing or not an integer.");
		}

		private static string GetString(JsonElement json, string propertyName, bool optional = false)
		{
			if (json.TryGetProperty(propertyName, out var element) && element.ValueKind == JsonValueKind.String)
			{
				return element.GetString();
			}
			if (optional) return string.Empty; // Return default for optional values
			throw new JsonException($"Property '{propertyName}' is missing or not a string.");
		}

		private static bool GetBool(JsonElement json, string propertyName, bool optional = false)
		{
			if (json.TryGetProperty(propertyName, out var element) && element.ValueKind == JsonValueKind.True || element.ValueKind == JsonValueKind.False)
			{
				return element.GetBoolean();
			}
			if (optional) return false; // Return default for optional values
			throw new JsonException($"Property '{propertyName}' is missing or not a boolean.");
		}
	}
}
