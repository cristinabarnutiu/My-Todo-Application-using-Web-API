using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Test3.Models;

//lab 3 requirements: add 3 validaitons
namespace Test3.ModelValidator
{
	public class CommentValidator : AbstractValidator<Comment>
	{
		// read more: https://www.carlrippon.com/fluentvalidation-in-an-asp-net-core-web-api/
		public CommentValidator(TodoItemsDbContext context)
		{
			//RuleFor(x => x.MarketPrice).InclusiveBetween(5, context.Flowers.Select(f => f.MarketPrice).Max());
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.Text).NotEmpty().WithMessage("Text cannot be empty");
			//RuleFor(x => x.Title).NotEqual(context.TodoItems.Select(t => t.Title).All());
			//RuleFor(x => x.Description).Length(0, 50).WithMessage("Description cannot be longer than 50 characters.");
		}
	}
}
