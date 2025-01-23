using File_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace File_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> UploadFile(IFormFile file)
		{
			if (file == null || file.Length == 0)
			{
				ViewData["Message"] = "No file selected.";
				return View();
			}

			try
			{
				var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

				if (!Directory.Exists(uploadPath))
				{
					Directory.CreateDirectory(uploadPath);
				}

				var filePath = Path.Combine(uploadPath, Path.GetFileName(file.FileName));

				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}

				ViewData["Message"] = $"File {file.FileName} uploaded successfully!";
			}
			catch (Exception ex)
			{
				ViewData["Message"] = $"File upload failed: {ex.Message}";
			}

			return View("Index");
		}
		
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
