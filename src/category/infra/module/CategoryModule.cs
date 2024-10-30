using finance.api.src.category.application.usecases.v1;
using finance.api.src.category.domain.port.repository;
using finance.api.src.category.domain.port.usecases.getAllCategory;
using finance.api.src.category.infra.repository;

namespace finance.api.src.category.infra.module
{
    public static class CategoryModule
    {
        public static void AddCategoryServices(this IServiceCollection services)
        {
            services.AddTransient<IGetAllCategoryUseCasePort, FindAllCategoryUseCaseV1>();
            services.AddTransient<ICategoryRepositoryPort, CategoryRepository>();

        }
    }
}
