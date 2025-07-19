using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuTodo.Data;
using MeuTodo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace MeuTodo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var todos = await _context.Todos.AsNoTracking().ToListAsync();

            return Ok(todos);
        }

        [HttpGet("{id:int:min(1)}", Name = "get_by_id")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var todo = await _context.Todos.AsNoTracking().FirstOrDefaultAsync();

            return todo is null ? NotFound("Nenhum registro encontrado") : Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Todo todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("get_by_id", new { id = todo.Id }, todo);
        }
    }
}
