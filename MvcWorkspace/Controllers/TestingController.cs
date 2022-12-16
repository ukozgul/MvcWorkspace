using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MvcWorkspace.Controllers
{
    public class TestingController : Controller
    {
        public IActionResult Index()
        {
            //ViewData["Message"] = "Controller' dan ..";
            ////Dynamic Property
            //ViewBag.Deneme = "Controllerdan BAG";

            IEnumerable<SelectListItem> opsiyonlar = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text="Opsiyon 1",
                    Value="1"
                },
                 new SelectListItem
                {
                    Text="Opsiyon 2",
                    Value="2"
                },
                  new SelectListItem
                {
                    Text="Opsiyon 3",
                    Value="3"
                }
            };

            ViewBag.Dropdown = opsiyonlar;
            ViewData["Opsiyonlar"] = opsiyonlar;
            
            
            return View();

        }
    }
}
