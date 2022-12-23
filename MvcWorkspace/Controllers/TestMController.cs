using Microsoft.AspNetCore.Mvc;
using MvcWorkspace.Models;

namespace MvcWorkspace.Controllers
{
    public class TestMController : Controller
    {
        IWebHostEnvironment _env;

        public TestMController(IWebHostEnvironment env)
        {
            _env = env;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert (TestM testM, IFormFile file)
        {

            if (ModelState.IsValid)
            {
                //global user id GUID
                string filename=Guid.NewGuid().ToString();
                var uploads = Path.Combine(_env.WebRootPath, @"images/test");  //@işareti olduğu gibi oku anlamına geliyor yoksa / işareti ortalığı karıştırıyor...
                var extension =Path.GetExtension(filename);
                if (testM.ImgUrl!=null)
                {
                    var oldImagePath = Path.Combine(_env.WebRootPath, testM.ImgUrl);
                    if (System.IO.File.Exists(oldImagePath)) //isim karmaşası olmasın diye namespace de eklendi...
                    {

                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
