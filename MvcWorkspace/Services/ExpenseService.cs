using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcWorkspace.Data;
using MvcWorkspace.Models;

namespace MvcWorkspace.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly AppDbContext _db;

        public ExpenseService(AppDbContext db) => _db = db;

        public void Add(Expense expense)
        {
            _db.Add(expense);
            _db.SaveChanges();
        }

        public IEnumerable<SelectListItem> CategorySelectListItems()
        {
            return _db.ExpenseCategories.Select(i =>
                                      new SelectListItem
                                      {
                                          Text = i.CategoryName,
                                          Value = i.Id.ToString()
                                      });
        }

        public bool Delete(int id)
        {
            var expense = _db.Expenses.Find(id);
            if (expense == null || id == 0)
            {
                return false;
            }

            _db.Expenses.Remove(expense);
            _db.SaveChanges();
            return true;
        }

        public Expense GetExpense(int id) => _db.Expenses.Find(id);

        public IEnumerable<Expense> GetExpenses() => _db.Expenses.Include(u => u.ExpenseCategory);

        public IEnumerable<Expense> GetExpensesByCategory(int catId)
        {
             return _db.Expenses.Where(x => x.ExpenseCategoryId == catId);
        }

        public IEnumerable<Expense> GetExpensesWithCategory()
        {
            return _db.Expenses.Include(u => u.ExpenseCategory);
        }

        public void Update(Expense expense)
        {
            _db.Update(expense);
            _db.SaveChanges();
        }

        public string GetCategoryName(int id)
        {
            return _db.ExpenseCategories.Find(id).CategoryName;
        }
    }
}
