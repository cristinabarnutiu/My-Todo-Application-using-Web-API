using Microsoft.EntityFrameworkCore;
using System;
using Test3.Models;

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

        internal object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}