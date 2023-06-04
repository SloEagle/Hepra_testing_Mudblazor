using FluentValidation;

namespace Hepra_testing_Mudblazor.Server.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("Please enter a name.");

            RuleFor(u => u.Surname)
                .NotEmpty()
                .WithMessage("Please enter a surname.");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Please enter an email.");

            RuleFor(u => u.PhoneNumber)
                .NotEmpty()
                .WithMessage("Please enter a phonenumber.");
        }
    }
}
