using FluentValidation;
using SalesPlatform_Application.Dtos.Auth;

namespace SalesPlatform_Application.Validation
{
    public class RegisterUserValidator : AbstractValidator<RegisterDto>
    {
        public RegisterUserValidator()
        {
            RuleFor(register => register.Email)
                .EmailAddress()
                .WithMessage("'Email' field is not a valid e-mail address");

            RuleFor(register => register.FirstName)
                .NotEmpty()
                .WithMessage("'First name' must be filled")
                .MaximumLength(250)
                .WithMessage("'First name' must be no longer than 250 characters");

            RuleFor(register => register.LastName)
                .NotEmpty()
                .WithMessage("'Last name' must be filled")
                .MaximumLength(250)
                .WithMessage("'Last name' must be no longer than 250 characters");

            RuleFor(register => register.City)
                .NotEmpty()
                .WithMessage("'City' must be filled")
                .MinimumLength(50)
                .WithMessage("'City' must be at least 50 characters long");

            RuleFor(register => register.PhoneNumber)
                .NotEmpty()
                .WithMessage("'Phone number' must be filled")
                .MinimumLength(20)
                .WithMessage("'City' must be at least 20 characters long");

            RuleFor(register => register.Password)
                .NotEmpty()
                .WithMessage("'Password' must be filled")
                .MinimumLength(6)
                .WithMessage("'Password' must be at least 6 characters long");
        }
    }
}
