using finance.api.src.category.application.usecases.v1.dtos;
using FluentValidation;

namespace finance.api.src.category.domain.validator
{
    public class ValidateCreateSubCatetory : AbstractValidator<CreateSubCategoryDto>
    {
        public ValidateCreateSubCatetory() 
        {
            RuleFor(subCategory => subCategory.Id_Category).NotEmpty().NotNull().WithMessage("Id_Category is not null or empty");
            RuleFor(subCategory => subCategory.Descript).NotEmpty().NotNull().WithMessage("Descript is not null or empty");
        }
    }
}
