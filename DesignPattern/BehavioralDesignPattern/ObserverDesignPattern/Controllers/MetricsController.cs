using Microsoft.AspNetCore.Mvc;

namespace ObserverDesignPattern.Controllers
{
    public class MetricsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
