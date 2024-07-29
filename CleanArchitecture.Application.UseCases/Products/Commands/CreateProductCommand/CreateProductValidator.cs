using FluentValidation;

namespace CleanArchitecture.Application.UseCases.Products.Commands.CreateProductCommand
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Status).NotNull().InclusiveBetween(0, 1);
            RuleFor(x => x.Stock).NotNull().GreaterThan(0);
            RuleFor(x => x.Description).NotEmpty().NotNull();
            RuleFor(x => x.Price).NotNull().GreaterThan(0);
        }
    }
}
