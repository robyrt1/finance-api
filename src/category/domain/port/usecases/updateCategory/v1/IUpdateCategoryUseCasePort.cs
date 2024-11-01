using finance.api.src.category.domain.entity;
using finance.api.src.category.domain.port.usecases.updateCategory.v1.type;

namespace finance.api.src.category.domain.port.usecases.updateCategory.v1
{
    public interface IUpdateCategoryUseCasePort
    {
        Task<Category> execute(IUpdateCategoryInput input);
    }
}
