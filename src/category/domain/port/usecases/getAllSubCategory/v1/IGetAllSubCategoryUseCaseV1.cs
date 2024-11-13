using finance.api.src.category.domain.objectValues;

namespace finance.api.src.category.domain.port.usecases.getAllSubCategory.v1
{
    public interface IGetAllSubCategoryUseCaseV1
    {
        Task<List<SubCategory>> execute();

    }
}
