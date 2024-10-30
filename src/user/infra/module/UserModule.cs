using finance.api.src.user.application.usecases.v1.dtos;
using finance.api.src.user.domain.validator;
using finance.src.user.application.usecases.v1;
using finance.src.user.domain.port.usecases.CreateUser.v1;
using finance.src.user.domain.port.usecases.findAll.v1;
using finance.src.user.infra.repository;
using FluentValidation;

namespace finance.api.src.user.infra.module
{
    public static class UserModule
    {
        public static void AddUserServices(this IServiceCollection services)
        {
            services.AddTransient<IFindAll, FindAllUseCase>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICreateUserPort, CreateUserUsecase>();
            services.AddTransient<IValidator<CreateUserDto>, ValidateCreateUser>();
        }
    }
}
