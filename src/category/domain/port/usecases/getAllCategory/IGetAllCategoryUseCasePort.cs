using finance.api.src.category.domain.entity;

namespace finance.api.src.category.domain.port.usecases.getAllCategory
{
    public interface IGetAllCategoryUseCasePort
    {
        Task<List<Category>> execute();
    }
}
