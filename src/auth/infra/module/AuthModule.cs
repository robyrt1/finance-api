using finance.api.src.auth.application.usecases.v1;
using finance.api.src.auth.application.usecases.v1.dtos;
using finance.api.src.auth.domain.port.usecases.login.v1;
using finance.api.src.auth.domain.validator;
using finance.api.src.shared.application.port.services;
using finance.api.src.shared.infratruction.services.jwt;
using finance.src.user.infra.repository;
using FluentValidation;

namespace finance.api.src.auth.infra.module
{
    public static class AuthModule
    {
        public static void AddAuthServices(this IServiceCollection services)
        {
            services.AddTransient<ILoginUsecaseV1Port, LoginUsecaseV1>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IValidator<LoginInputDto>, LoginInputDtoValidator>();
        }
    }
}
