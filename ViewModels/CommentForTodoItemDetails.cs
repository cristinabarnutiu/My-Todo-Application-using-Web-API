using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test3.Models;

namespace Test3.ViewModels
{
    public class CommentForTodoItemDetails
    {
        //public string Id { get; set; }
        public string Text { get; set; }
        public bool Important { get; set; }

        public static CommentForTodoItemDetails FromComment(Comment comment)
        {
            return new CommentForTodoItemDetails
            {
                Text = comment.Text,
                Important = comment.Important
            };
        }
    }
}