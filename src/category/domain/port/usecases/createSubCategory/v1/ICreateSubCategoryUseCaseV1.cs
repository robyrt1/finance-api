using finance.api.src.category.domain.entity;
using finance.api.src.category.domain.objectValues;
using finance.api.src.category.domain.port.usecases.createSubCategory.v1.types;

namespace finance.api.src.category.domain.port.usecases.createSubCategory.v1
{
    public interface ICreateSubCategoryUseCaseV1
    {
        Task<SubCategory> execute(ICreateSubCategoruInput input);
    }
}
