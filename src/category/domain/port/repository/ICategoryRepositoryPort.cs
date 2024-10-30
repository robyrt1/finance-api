using finance.api.src.category.domain.entity;

namespace finance.api.src.category.domain.port.repository
{
    public interface ICategoryRepositoryPort
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(string id);
    }
}
