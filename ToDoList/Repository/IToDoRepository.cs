using ToDoList.Models;

namespace ToDoList.Repository
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDo>> GetList();

        Task<ToDo> GetById(int id);
        
        void Add(ToDo toDo);

        void Update(ToDo toDo);

        void Delete(ToDo toDo);

        Task<bool> SaveChangesAsync();
    }
}
