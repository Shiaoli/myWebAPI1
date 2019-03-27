using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myWebAPI1.Models;

namespace myWebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ToDoContext _context;
        
        public TodoController(ToDoContext context)
        {
            _context = context;

            if(_context.ToDoItems.Count() == 0)
            {
                _context.ToDoItems.Add(new ToDoItem { Name = "item1" });
                _context.SaveChanges();
            }
        }

        // GET: api/ToDo
        [HttpGet]
        public async Task<ActionResult<ToDoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.ToDoItems.FindAsync(id);
            if(todoItem == null)
            {
                return NotFound();
            }
            return todoItem;
        }
    }
}