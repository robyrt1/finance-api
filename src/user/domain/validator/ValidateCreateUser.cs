using finance.api.src.user.application.usecases.v1.dtos;
using FluentValidation;

namespace finance.api.src.user.domain.validator
{
    public class ValidateCreateUser: AbstractValidator<CreateUserDto>
    {
        public ValidateCreateUser() { 
            RuleFor(user=>user.UserName).NotEmpty().NotNull();
            RuleFor(user => user.Email).NotEmpty().NotNull().MaximumLength(50).EmailAddress();
            RuleFor(person => person.Password).NotEmpty().NotNull().MaximumLength(20).Matches("^(?=.*\\d).*$").WithMessage("Password must contain numeric value");

        }
    }
}
