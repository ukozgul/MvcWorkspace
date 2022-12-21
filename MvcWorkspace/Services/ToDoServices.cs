using Microsoft.EntityFrameworkCore;
using MvcWorkspace.Data;
using MvcWorkspace.Models;
using MvcWorkspace.Services.Interfaces;

namespace MvcWorkspace.Services
{
    public class ToDoServices : IToDoServices
    {
        private readonly AppDbContext _db;

        public ToDoServices(AppDbContext db)
        {
            _db = db;
        }

        public void Add(ToDoModel toDoModel)
        {
            _db.Add(toDoModel);
            _db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var toDoModel=_db.ToDoModels.Find(id);
            if (toDoModel == null || id==0) 
            {
                return false;
            }
            _db.ToDoModels.Remove(toDoModel);
            _db.SaveChanges();
            return true;
        }

        public IEnumerable<ToDoModel> GetAll()
        {
            return _db.ToDoModels;  
        }

        public IEnumerable<ToDoModel> GetJustTrue()
        {
            return _db.ToDoModels.Include(u => u.IsItOver == true);
        }

        public void Update(ToDoModel toDoModel)
        {
             _db.Update(toDoModel);
            _db.SaveChanges();
        }
    }
}
