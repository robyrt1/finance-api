using finance.api.src.category.domain.port.usecases.createSubCategory.v1.types;

namespace finance.api.src.category.application.usecases.v1.dtos
{
    public class CreateSubCategoryDto : ICreateSubCategoruInput
    {
        public string Descript { get; set; }
        public string Id_Category { get; set; }
    }
}
