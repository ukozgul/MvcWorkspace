using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcWorkspace.Data;
using MvcWorkspace.Models;
using MvcWorkspace.Models.ViewModels;
using MvcWorkspace.Services;

namespace MvcWorkspace.Controllers

{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _service;

        public ExpenseController(IExpenseService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {

            IEnumerable<Expense> expenses = _service.GetExpenses();
            return View(expenses);
        }


        public IActionResult AddOrUpdate(int id)
        {
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                CategoryDropDown = _service.CategorySelectListItems()
            };

            if (id == 0)
            {
                //Add
                return View(expenseVM);
            }
            else
            {
                //Update
                expenseVM.Expense = _service.GetExpense(id);
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
                    _service.Add(expense);
                }
                else
                {
                    _service.Update(expense);
                }
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        public IActionResult Delete(int id)
        {
            if (_service.Delete(id))
            {
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        //GET
        public IActionResult ExpensesByCategory(int id)
        {
            IEnumerable<Expense> expenseByCatList = _service.GetExpensesByCategory(id);
            ViewBag.catName = _service.GetCategoryName(id);
            ViewBag.totalAmount = GetTotal(expenseByCatList);
            return View(expenseByCatList);
        }

        private int GetTotal(IEnumerable<Expense> list)
        {
            int totalAmount = 0;
            foreach (var e in list)
            {
                totalAmount += e.Amount;
            }
            return totalAmount;
        }


    }
}
