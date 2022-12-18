using Microsoft.AspNetCore.Mvc;
using MvcWorkspace.Data;
using MvcWorkspace.Models;

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
            IEnumerable<ExpenseCategory> expenseCategories= _db.ExpenseCategories;
            return View(expenseCategories);
        }

        public IActionResult AddOrUpdate(int id)
        {
            if (id == 0)
            {
                //Add
                return View(new ExpenseCategory());
            }
            else
            {
                //Update
                var obj = _db.ExpenseCategories.Find(id);
                return View(obj);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(ExpenseCategory expensecategory)
        {
            if (ModelState.IsValid)
            {
                if (expensecategory.Id == 0)
                {
                    _db.Add(expensecategory);
                }
                else
                {
                    _db.Update(expensecategory);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expensecategory);
        }


        public IActionResult Delete(int id) 
        {
            var expenseCategory=_db.ExpenseCategories.Find(id);
            if (expenseCategory==null ||id==0)
            {
                return NotFound();
            }

            _db.ExpenseCategories.Remove(expenseCategory);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
