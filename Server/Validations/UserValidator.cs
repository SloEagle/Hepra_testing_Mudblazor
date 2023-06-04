using FluentValidation;

namespace Hepra_testing_Mudblazor.Server.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty();
        }
    }
}
