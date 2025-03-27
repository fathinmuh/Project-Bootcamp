using FluentValidation;
namespace AspNetCoreTodo.DTO
{
    public class TodoItemDTOValidator : AbstractValidator<TodoItemDTO>
    {
        public TodoItemDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Can not be empty.")
                .MinimumLength(5).WithMessage("5 character minimum.");
        }
    }
}

