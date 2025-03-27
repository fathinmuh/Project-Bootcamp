using FluentValidation;
namespace AspNetCoreTodo.Models
{
    public class TodoItemValidator : AbstractValidator<TodoItem>
    {
        public TodoItemValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Can not be empty.")
                .MinimumLength(5).WithMessage("5 character minimum.");
        }
    }
}

