using MvcWorkspace.Data;
using MvcWorkspace.Models;

namespace MvcWorkspace.Services
{
    public class ToDoService : IToDoService
    {
        private readonly AppDbContext _db;

        public ToDoService(AppDbContext db)
        {
            _db = db;
        }

        public bool Add(ToDoModel toDoModel)
        {
            try
            {
                _db.Add(toDoModel);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var toDoModel = _db.ToDoModels.Find(id);
                _db.ToDoModels.Remove(toDoModel);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Finisher(int id)
        {
            var toDoModel = _db.ToDoModels.Find(id);
            toDoModel.IsItOver = true;
            _db.SaveChanges();
            return true;
        }

        public IEnumerable<ToDoModel> GetAll()
        {
            return _db.ToDoModels;

        }

        public IEnumerable<ToDoModel> GetToDoModels()
        {

            //IEnumerable<ToDoModel> toDoModels = _db.ToDoModels.Where()
            throw new NotImplementedException();
        }

        public bool Update(ToDoModel toDoModel)
        {
            try
            {
                _db.Update(toDoModel);
                _db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}
