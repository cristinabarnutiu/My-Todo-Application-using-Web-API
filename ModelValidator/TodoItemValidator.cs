using FluentValidation;
using Test3.Models;

namespace Test3.ModelValidator
{
	public class TodoItemValidator : AbstractValidator<TodoItem>
	{
		public TodoItemValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty");
			RuleFor(x => x.Description).Length(0,10);
		}
	}
}
