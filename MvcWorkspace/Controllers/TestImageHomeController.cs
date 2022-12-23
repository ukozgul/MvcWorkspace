using Microsoft.AspNetCore.Mvc;

namespace MvcWorkspace.Controllers
{
    public class TestImageHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
