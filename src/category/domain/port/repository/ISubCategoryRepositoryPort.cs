using finance.api.src.category.domain.objectValues;

namespace finance.api.src.category.domain.port.repository
{
    public interface ISubCategoryRepositoryPort
    {                   
        Task<List<SubCategory>> GetAllAsync();
        Task<List<SubCategory>> GetByIDCategoryAsync(string id);
        Task<SubCategory> GetByIdAsync(string id);
        Task<SubCategory> Create(SubCategory subCategory);
        Task<SubCategory> UpdateCategoryAsync(string id, SubCategory updatedCategory);
        Task<SubCategory> FindByDescriptionAndCategoryIdAsync(string description, string categoryId);
    }
}
