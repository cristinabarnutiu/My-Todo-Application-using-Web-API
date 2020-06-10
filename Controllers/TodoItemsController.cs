using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Test3.Models;
using Test3.ViewModels;

namespace Test3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoItemsDbContext _context;

        public TodoItemsController(TodoItemsDbContext context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        /// <summary>
        /// Get a list of all todo items
        /// </summary>
        /// <param name="from">Filters todo items added from this datetime inclusive. Leave empty for no lower limit.</param>
        /// <param name="to">Filters todo items added to this datetime inclusive. Leave empty for no upper limit.</param>
        /// <returns>A list of tasks.</returns>
        
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemWithNumberOfComments>>> GetTodoItems(
            [FromQuery]DateTimeOffset? from = null, 
            [FromQuery]DateTimeOffset? to = null)
        {
            IQueryable <TodoItem> result = _context.TodoItems.Include(c => c.Comments);
            if (from != null)
            {
                result = result.Where(t => from <= t.DateAdded);
            }
            if (to != null) 
          {
                result = result.Where(t => to <= t.DateAdded);
            }

            //var resultList = await result
            //.OrderByDescending(to => to.DateAdded)
            //.ToListAsync();

            var resultList = await result
                .OrderByDescending(to => to.DateAdded)
                .Include(t => t.Comments)
                .Select(t => TodoItemWithNumberOfComments.FromTodoItem(t))
                .ToListAsync();
            return resultList;


        }



        // GET: api/TodoItems/5
        /// <summary>
        /// Get item details
        /// </summary>
        /// <param name="id">Get item details for a specific id</param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>  
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
        {
            var todoItem = _context.TodoItems
               .Include(c => c.Comments)
               .Select(c => TodoItemDTO.ShowTodoDTOItemsAndComments(c))
               .AsEnumerable()
               .FirstOrDefault(c => c.Id == id);

            if (todoItem == null)
            {
                return NotFound("This item does not exist!");
            }

            return Ok(todoItem);
        }

        // PUT: api/TodoItems/5
        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="id">Updates an item with a specific id</param>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            //Lab 2
            if (todoItem.State.Equals(State.Closed))
            {
                todoItem.DateClosed = DateTime.Now;
            }
            else
            {
                todoItem.DateClosed = default;
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound("This item does not exist!");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoItems
        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        }

        // DELETE: api/TodoItems/5
        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id">Deletes item with specific id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound("This item does not exist!");
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }

        private bool TodoItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
