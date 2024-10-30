using finance.api.src.category.domain.entity;
using finance.api.src.category.domain.objectValues;

namespace finance.api.src.category.domain.port.repository
{
    public interface ISubCategoryRepositoryPort
    {
        Task<List<SubCategory>> GetAllAsync();
        Task<List<SubCategory>> GetByIDCategoryAsync(string id);
        Task<SubCategory> GetByIdAsync(string id);
    }
}
