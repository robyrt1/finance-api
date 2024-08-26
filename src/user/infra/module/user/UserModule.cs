using finance.src.user.application.usecases.v1;
using finance.src.user.domain.port.usecases.CreateUser.v1;
using finance.src.user.domain.port.usecases.findAll.v1;
using finance.src.user.infra.repository;

namespace finance.src.user.infra.module.user
{
    public static class UserModule
    {
        public static void AddUserServices(this IServiceCollection services)
        {
            services.AddScoped<IFindAll, FindAllUseCase>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICreateUserPort, CreateUserUsecase>();
        }
    }
}
