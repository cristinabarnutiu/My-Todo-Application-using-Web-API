using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test3.Models;

namespace Test3.ViewModels
{
    public class TodoItemDetails
    { 
    public long Id { get; set; }
    //[MinLength(2, ErrorMessage = "Title should have at least 2 characters")]
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset DateAdded { get; set; }
    public DateTimeOffset Deadline { get; set; }
    public Importance Importance { get; set; }
    public State State { get; set; }
    public DateTimeOffset DateClosed { get; set; }
    public List<CommentForTodoItemDetails> Comments { get; set; }
        //public long NumberOfComments { get; set; }

        public static TodoItemDetails FromTodoItem(TodoItem todoItem)
    {
            return new TodoItemDetails
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                DateAdded = todoItem.DateAdded,
                Deadline = todoItem.Deadline,
                Importance = todoItem.Importance,
                State = todoItem.State,
                DateClosed = todoItem.DateClosed,
                Comments = todoItem.Comments.Select(c => CommentForTodoItemDetails.FromComment(c)).ToList()
            };

        //    Comments = todoItem.Comments.Select(c => new Comment()
        //    {
        //       Text = c.Text,
        //        Id = c.Id
        //   })
        }
    }
}

