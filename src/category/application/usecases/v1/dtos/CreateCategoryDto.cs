using finance.api.src.category.domain.port.usecases.createCategory.v1.type;

namespace finance.api.src.category.application.usecases.v1.dtos
{
    public class CreateCategoryDto : ICreateCategoryInput
    {
        public string Descript {  get; set; }
        public string Type { get; set; }
        public string Id_User { get; set; }
    }
}
