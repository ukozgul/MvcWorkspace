using MvcWorkspace.Models;

namespace MvcWorkspace.Services
{
    public interface IToDoService
    {
        IEnumerable<ToDoModel> GetToDoModels();
        
        IEnumerable<ToDoModel> GetAll();

        bool Add (ToDoModel toDoModel);

        bool Update (ToDoModel toDoModel);

        bool Delete (int id);

        bool Finisher(int id);

    }
}
