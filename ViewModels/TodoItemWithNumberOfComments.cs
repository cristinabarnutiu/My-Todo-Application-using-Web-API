using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Test3.Models;

namespace Test3.ViewModels
{
    public class TodoItemWithNumberOfComments
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
        //public List<Comment> Comments { get; set; }
        public long NumberOfComments { get; set; }

        public static TodoItemWithNumberOfComments FromTodoItem(TodoItem todoitem)
        {
            return new TodoItemWithNumberOfComments
            {
                Id = todoitem.Id,
                Title = todoitem.Title,
                Description = todoitem.Description,
                DateAdded = todoitem.DateAdded,
                Deadline = todoitem.Deadline,
                Importance = todoitem.Importance,
                State = todoitem.State,
                DateClosed = todoitem.DateClosed,
                NumberOfComments = todoitem.Comments.Count
            };
        }
    }
}
