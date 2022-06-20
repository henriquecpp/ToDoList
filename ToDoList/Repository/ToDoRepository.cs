using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly DataContext _context;

        public ToDoRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(ToDo toDo)
        {
            _context.Add(toDo);
        }

        public void Delete(ToDo toDo)
        {
            _context.Remove(toDo);
        }

        public async Task<IEnumerable<ToDo>> GetList()
        {
            return await _context.ToDo.ToListAsync();
        }

        public async Task<ToDo> GetById(int id)
        {
            return await _context.ToDo.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(ToDo toDo)
        {
            _context.Update(toDo);
        }

        
    }
}
