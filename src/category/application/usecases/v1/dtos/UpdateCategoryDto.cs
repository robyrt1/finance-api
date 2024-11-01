using finance.api.src.category.domain.port.usecases.updateCategory.v1.type;

namespace finance.api.src.category.application.usecases.v1.dtos
{
    public class UpdateCategoryDto : IUpdateCategoryInput
    {
        public string Id { get; set; }
        public string Descript { get; set; }
        public string Type { get; set; }
    }
}
