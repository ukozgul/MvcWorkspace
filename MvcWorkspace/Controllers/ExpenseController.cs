using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcWorkspace.Data;
using MvcWorkspace.Models;
using MvcWorkspace.Models.ViewModels;

namespace MvcWorkspace.Controllers

{
    public class ExpenseController : Controller
    {
        private readonly AppDbContext _db;

        public ExpenseController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //IEnumerable<Expense> expenses = _db.Expenses;

            //foreach (var exp in expenses)
            //{
            //    exp.ExpenseCategory=_db.ExpenseCategories.FirstOrDefault(e => e.Id == exp.ExpenseCategoryId);
            //}


            //EAGER LOADİNG (bu tekniğin adı: aç gözlülük)
            IEnumerable<Expense> expenses = _db.Expenses.Include(u=> u.ExpenseCategory);


            return View(expenses);  //veri tabanından aldığını View de göster
        }


        //GET - AddOrUpdate
        public IActionResult AddOrUpdate(int id)
        {
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                CategoryDropDown = _db.ExpenseCategories.Select(i =>
                                    new SelectListItem
                                    {
                                        Text = i.CategoryName,
                                        Value = i.Id.ToString()
                                    })
            };

            //IEnumerable<SelectListItem> CategoryDropDown = _db.ExpenseCategories.Select(i =>
            //new SelectListItem
            //{
            //    Text = i.CategoryName,
            //    Value = i.Id.ToString()
            //}); //her bir i için yeni bir selectlistitem oluştur. Text ve valuyi ona göre ata  value string olmalı...

            ////ViewBag.CategoryDropDown = CategoryDropDown;
            

            if (id == 0)
            {
                //Add
                return View(expenseVM);
            }
            else
            {
                //Update
                expenseVM.Expense = _db.Expenses.Find(id);
                return View(expenseVM);
            }
        }

        //POST - AddOrUpdate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(Expense expense)
        {
            if (ModelState.IsValid)  //Server side validation
            {
                if (expense.Id == 0)
                {
                    _db.Add(expense);
                }
                else
                {
                    _db.Update(expense);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        public IActionResult Delete(int id)
        {
            var expense = _db.Expenses.Find(id);

            if (expense == null || id == 0)
            {
                return NotFound();
            }

            _db.Expenses.Remove(expense);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //GET
        public IActionResult ExpensesByCategory(int id)
        {
            IEnumerable<Expense> expenseByCatList = _db.Expenses.Where(x => x.ExpenseCategoryId == id);

            int totalAmount = 0;
            foreach (var e in expenseByCatList)
            {
                totalAmount += e.Amount;
            }
            ViewBag.totalAmount = totalAmount;
            return View(expenseByCatList);
        }


    }
}
