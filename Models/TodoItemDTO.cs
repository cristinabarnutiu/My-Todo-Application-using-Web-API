using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test3.Models
{
    public class TodoItemDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public DateTimeOffset Deadline { get; set; }
        public Importance Importance { get; set; }
        public State State { get; set; }
        public DateTimeOffset DateClosed { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public int NumberOfComments { get; set; }


        public static TodoItemDTO ShowTodoItemWithComments (TodoItem todoItem)
        {
            return new TodoItemDTO
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                Comments = todoItem.Comments.Select(c => new Comment()
                {
                    Text = c.Text,
                })

            };
        }

        //the method returns todo item and number of comments
        public static TodoItemDTO ShowTodoItemsAndNumberOfComments(TodoItem todoItem)
        {
            return new TodoItemDTO
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                NumberOfComments = todoItem.Comments.Count
            };
        }

        //the method returns todo item and comments
        public static TodoItemDTO ShowTodoDTOItemsAndComments(TodoItem todoItem)
        {
            return new TodoItemDTO
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                NumberOfComments = todoItem.Comments.Count,
                Comments = todoItem.Comments.Select(c => new Comment()
                {
                    Text = c.Text,
                    Id = c.Id
                })
            };
        }

        //the method return both number of comments and comments
        public static TodoItemDTO ShowTodoDTO (TodoItem todoItem)
        {
            return new TodoItemDTO
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                NumberOfComments = todoItem.Comments.Count,
                Comments = todoItem.Comments.Select(c => new Comment()
                {
                    Text = c.Text,
                    Id = c.Id
                })
            };
        }


    }
}
