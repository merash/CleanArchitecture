using FluentValidation;

namespace CleanArchitecture.Application.UseCases.Products.Queries.GetByProductIdQuery
{
    public class GetByProductIdValidator : AbstractValidator<GetByProductIdQuery>
    {
        public GetByProductIdValidator()
        {
            RuleFor(x => x.ProductId).NotNull().GreaterThan(0);
        }
    }
}
