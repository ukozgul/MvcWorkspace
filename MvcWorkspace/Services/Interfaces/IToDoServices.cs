using MvcWorkspace.Models;

namespace MvcWorkspace.Services.Interfaces
{
    public interface IToDoServices
    {
        //CRUD İşlemleri
        
        //Create-Add
        void Add(ToDoModel toDoModel);
        
        //Listeleme-Read
        IEnumerable<ToDoModel> GetAll();
        
        //Güncelle-Update
        void Update(ToDoModel toDoModel);

        //Sil-Delete
        bool Delete(int id);

        //Sadece yapılmışları listele
        IEnumerable<ToDoModel> GetJustTrue();
    }
}
