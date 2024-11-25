using finance.api.src.category.domain.entity;
using finance.api.src.category.domain.port.repository;
using finance.api.src.category.domain.port.usecases.updateCategory.v1;
using finance.api.src.category.domain.port.usecases.updateCategory.v1.type;

namespace finance.api.src.category.application.usecases.v1
{
    public class UpdateCategoryUseCaseV1 : IUpdateCategoryUseCasePort
    {
        public ICategoryRepositoryPort _categoryRepository;

        public UpdateCategoryUseCaseV1(ICategoryRepositoryPort categoryRepositoryPort)
        {
            _categoryRepository = categoryRepositoryPort;
        }

        public async Task<Category> execute(IUpdateCategoryInput input)
        {
            try
            {
                var existingCategory = await _categoryRepository.GetByIdAsync(input.Id);
                if (existingCategory is null)
                {
                    throw new KeyNotFoundException("Category not found.");
                }

                existingCategory.Descript = input.Descript;
                existingCategory.Type = input.Type; 

                var updatedCategory = await _categoryRepository.UpdateCategoryAsync(input.Id, existingCategory);

                return updatedCategory;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while updating the category.", ex);
            }
        }
    }
}
