using FluentValidation;

namespace CleanArchitecture.Application.Features.UserFeatures.Command.Create
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Username).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        }
    }
}
