using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Test3.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoItemsDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TodoItemsDbContext>>()))
            {
                // Look for any movies.
                if (context.TodoItems.Any())
                {
                    return;   // DB table has been seeded
                }

                context.TodoItems.AddRange(
                    new TodoItem
                    {
                        Title = "Item 1",
                        Description = "Description 1",
                        DateAdded = DateTime.Now,
                        Deadline = DateTimeOffset.Now,
                        Importance = Importance.Low,
                        State = State.InProgress,
                        DateClosed = DateTime.Now
                    },

                new TodoItem
                {
                    Title = "Item 2",
                    Description = "Description 2",
                    DateAdded = DateTime.Now,
                    Deadline = DateTimeOffset.Now,
                    Importance = Importance.Low,
                    State = State.InProgress,
                    DateClosed = DateTime.Now
                }
                );
                context.SaveChanges();
            }
        }
    }
}