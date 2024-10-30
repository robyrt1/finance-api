using finance.api.src.category.application.usecases.v1.dtos;
using FluentValidation;

namespace finance.api.src.category.domain.validator
{
    public class ValidateCreateCategory: AbstractValidator<CreateCategoryDto>
    {
        public ValidateCreateCategory() 
        {
            RuleFor(category => category.Descript).NotEmpty().NotNull().WithMessage("Descript is not null");
        }
    }
}
