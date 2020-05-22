using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Test3.Models;

namespace Test3.ModelValidator
{
	public class TodoItemValidator : AbstractValidator<TodoItem>
	{
        // read more: https://www.carlrippon.com/fluentvalidation-in-an-asp-net-core-web-api/
        public TodoItemValidator(TodoItemsDbContext context)
		{
			//RuleFor(x => x.MarketPrice).InclusiveBetween(5, context.Flowers.Select(f => f.MarketPrice).Max());
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty");
			//RuleFor(x => x.Title).NotEqual(context.TodoItems.Select(t => t.Title).All());
			RuleFor(x => x.Description).Length(0,10);
		}
	}
}
