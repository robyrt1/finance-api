using finance.api.src.category.domain.objectValues;
using finance.api.src.category.domain.port.repository;
using finance.api.src.category.domain.port.usecases.getAllSubCategory.v1;
using finance.api.src.shared.infratruction.exceptions.http;

namespace finance.api.src.category.application.usecases.v1
{
    public class GetAllSubCategoryUseCaseV1 : IGetAllSubCategoryUseCaseV1
    {
        ISubCategoryRepositoryPort _subCategoryRepository;
        public GetAllSubCategoryUseCaseV1(ISubCategoryRepositoryPort subCategoryRepository) 
        { 
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<List<SubCategory>> execute()
        {
            var SubCategories = await _subCategoryRepository.GetAllAsync();

            if (SubCategories is null || !SubCategories.Any())
            {
                throw new NotFoundException("Not found SubCategories.");
            }

            return (List<SubCategory>)SubCategories;
        }
    }
}
