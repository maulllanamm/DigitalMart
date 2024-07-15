using FluentValidation;

namespace DigitalMart.Application.Features.UserFeatures.Command.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required")
                .GreaterThan(0).WithMessage("Must be greater than 0");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required");
        }
    }
}
