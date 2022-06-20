using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Repository;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _repository;

        public ToDoController(IToDoRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _repository.GetList();
            return list.Any() ? Ok(list) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post(ToDo toDo)
        {
            _repository.Add(toDo);
            return await _repository.SaveChangesAsync() ? Ok("Added") : BadRequest("Error");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ToDo toDo)
        {
            var db = await _repository.GetById(id);

            if(db == null) return NotFound("Not found");

            db.Title = toDo.Title ?? db.Title;
            db.Desc = toDo.Desc ?? db.Desc;
            db.PlannedDate = toDo.PlannedDate != new DateTime() ? toDo.PlannedDate : db.PlannedDate;

            _repository.Update(db);
            return await _repository.SaveChangesAsync() ? Ok("Updated") : BadRequest("Error");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var db = await _repository.GetById(id);

            if (db == null) return NotFound("Not found");

            _repository.Delete(db);
            return await _repository.SaveChangesAsync() ? Ok("Deleted") : BadRequest("Error");
        }

    }
}
