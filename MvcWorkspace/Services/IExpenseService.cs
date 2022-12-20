using Microsoft.AspNetCore.Mvc.Rendering;
using MvcWorkspace.Models;

namespace MvcWorkspace.Services
{
    public interface IExpenseService
    {
        //Liste Expense
        IEnumerable<Expense> GetExpenses();

        //Kategori Adıyla Expense'ler
        IEnumerable<Expense> GetExpensesWithCategory();

        //Tek bir Expense
        Expense GetExpense(int id);

        //Ekle Expense
        void Add(Expense expense);

        //Güncelle Expense
        void Update(Expense expense);

        //Sil Expense
        bool Delete(int id);

        //Bir Kategorideki Expense'ler
        IEnumerable<Expense> GetExpensesByCategory(int catId);

        //Kategori Listesi SelectListItem olarak
        IEnumerable<SelectListItem> CategorySelectListItems();

        //Kategori Adı Getir
        string GetCategoryName(int id);

    }
}
