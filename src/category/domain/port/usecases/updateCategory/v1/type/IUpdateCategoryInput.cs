namespace finance.api.src.category.domain.port.usecases.updateCategory.v1.type
{
    public interface IUpdateCategoryInput
    {
        public string Id { get; set; }
        public string Descript { get; set; }
        public string Type { get; set; }
    }
}
