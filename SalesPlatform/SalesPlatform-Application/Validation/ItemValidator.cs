using FluentValidation;
using SalesPlatform_Application.Dtos.Item;

namespace SalesPlatform_Application.Validation
{
    public class ItemValidator : AbstractValidator<ItemDto>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("'Name' must be filled")
                .MaximumLength(50)
                .WithMessage("'Name' must be no longer than 40 characters");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("'Description' must be filled")
                .MaximumLength(1000)
                .WithMessage("'Description' must be no longer than 1000 characters");

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("'City' must be filled")
                .MaximumLength(50)
                .WithMessage("'City' must be no longer than 50 characters");
        }
    }
}
