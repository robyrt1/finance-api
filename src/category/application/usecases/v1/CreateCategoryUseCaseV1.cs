using finance.api.src.category.domain.entity;
using finance.api.src.category.domain.port.repository;
using finance.api.src.category.domain.port.usecases.createCategory.v1;
using finance.api.src.category.domain.port.usecases.createCategory.v1.type;
using finance.src.shared.infratruction.exceptions.http;

namespace finance.api.src.category.application.usecases.v1
{
    public class CreateCategoryUseCaseV1 : ICreatecategoryUseCasePort
    {
        public ICategoryRepositoryPort _categoryRepository;

        public CreateCategoryUseCaseV1(ICategoryRepositoryPort categoryRepositoryPort)
        {
            _categoryRepository = categoryRepositoryPort;
        }


        public async Task<Category> execute(ICreateCategoryInput input)
        {
            try
            {
                var existingCategory = await _categoryRepository.GetByDescriptAsync(input.Descript);
                if (existingCategory is not null)
                {
                    throw new ConflictException("Category already exists!");
                }

                var category = new Category
                {
                    Descript = input.Descript,
                    Type = input.Type
                };

                return await _categoryRepository.CreateCategoryAsync(category);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
