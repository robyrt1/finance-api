using finance.api.src.category.application.usecases.v1.dtos;
using FluentValidation;

namespace finance.api.src.category.domain.validator
{
    public class ValidateUpdateCategory : AbstractValidator<UpdateCategoryDto>
    {
        public ValidateUpdateCategory() 
        {
            RuleFor(category => category.Id).NotEmpty().NotNull().WithMessage("Id is not null");
            RuleFor(category => category.Descript).NotEmpty().NotNull().WithMessage("Descript is not null");
            RuleFor(category => category.Type)
                .NotEmpty()
                .NotNull()
                .Must(type => type == "RECEITA" || type == "DESPESA" || type == "INVESTIMENTO")
                .WithMessage("Errro: Type is not null and ONLY RECEITA,DESPESA INVESTIMENTO");
        }
    }
}
