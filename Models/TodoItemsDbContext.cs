using Microsoft.EntityFrameworkCore;

namespace Test3.Models
{
    public class TodoItemsDbContext : DbContext
    {
        public TodoItemsDbContext(DbContextOptions<TodoItemsDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}