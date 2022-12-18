using Microsoft.AspNetCore.Mvc;
using MvcWorkspace.Data;

namespace MvcWorkspace.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        private readonly AppDbContext _db;

        public ExpenseCategoryController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
