using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers;

[Route("jadwalguru")]
[ApiController]
public class TodoItemsJadwalGuru : ControllerBase
{
    private readonly TodoContext _context;

    public TodoItemsJadwalGuru(TodoContext context)
    {
        _context = context;
    }

    // GET: api/TodoItems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
    {
        return await _context.TodoItems
            .Select(x => ItemToDTO(x))
            .ToListAsync();
    }

    // GET: api/TodoItems/5
    // <snippet_GetByID>
    [HttpGet("{nip}")]
    public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long nip)
    {
        var todoItem = await _context.TodoItems.FindAsync(nip);

        if (todoItem == null)
        {
            return NotFound();
        }

        return ItemToDTO(todoItem);
    }
     [HttpGet("{id_mapel}")]
    public async Task<ActionResult<TodoItemDTO>> GetTodoItem1(long id_mapel)
    {
        var todoItem = await _context.TodoItems.FindAsync(id_mapel);

        if (todoItem == null)
        {
            return NotFound();
        }

        return ItemToDTO(todoItem);
    }
    // </snippet_GetByID>

    // PUT: api/TodoItems/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Update>
   
    // </snippet_Update>

    // POST: api/TodoItems
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Create>
    [HttpPost]
    public async Task<ActionResult<TodoItemDTO>> PostTodoItem(TodoItemDTO todoDTO)
    {
        var todoItem = new TodoItem
        {
            IsComplete = todoDTO.IsComplete,
            Name = todoDTO.Name
        };

        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetTodoItem),
            new { id = todoItem.Id },
            ItemToDTO(todoItem));
    }
    // </snippet_Create>

  
    private bool TodoItemExists(long id)
    {
        return _context.TodoItems.Any(e => e.Id == id);
    }

    private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
       new TodoItemDTO
       {
           Id = todoItem.Id,
           Name = todoItem.Name,
           IsComplete = todoItem.IsComplete
       };
}