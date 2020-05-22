using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test3.Models
{
    public enum Importance { Low, Medium, High }
    public enum State { Open, InProgress, Closed }
    public class TodoItem
    {
        public long Id { get; set; }
        [MinLength(2, ErrorMessage = "Title should have at least 2 characters")]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public DateTimeOffset Deadline { get; set; }
        public Importance Importance { get; set; }
        public State State { get; set; }
        public DateTimeOffset DateClosed { get; set; }
    }
}
