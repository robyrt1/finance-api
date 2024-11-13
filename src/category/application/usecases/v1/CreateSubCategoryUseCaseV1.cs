using finance.api.src.category.domain.objectValues;
using finance.api.src.category.domain.port.repository;
using finance.api.src.category.domain.port.usecases.createSubCategory.v1;
using finance.api.src.category.domain.port.usecases.createSubCategory.v1.types;
using finance.src.shared.infratruction.exceptions.http;
using System.Net;

namespace finance.api.src.category.application.usecases.v1
{
    public class CreateSubCategoryUseCaseV1 : ICreateSubCategoryUseCaseV1
    {
        public ISubCategoryRepositoryPort _repositoryPort;

        public CreateSubCategoryUseCaseV1(ISubCategoryRepositoryPort repositoryPort)
        {
            _repositoryPort = repositoryPort;
        }

        public async Task<SubCategory> execute(ICreateSubCategoruInput input)
        {
            var ExistSubCategory = await _repositoryPort.FindByDescriptionAndCategoryIdAsync(input.Descript, input.Id_Category);
            if (ExistSubCategory is not null)
            {
                throw new ConflictException("SubCategory exists");
            }
            var newSubcategory = new SubCategory()
            {
                Descript = input.Descript,
                Id_Category = input.Id_Category,
               
            };
            return await _repositoryPort.Create(newSubcategory);

        }
    }
}
