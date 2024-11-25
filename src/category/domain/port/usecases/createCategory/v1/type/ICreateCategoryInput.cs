namespace finance.api.src.category.domain.port.usecases.createCategory.v1.type
{
    public interface ICreateCategoryInput
    {
        public string Descript {  get; set; }
        public string Type { get; set; }
        public string Id_User { get; set; }
    }
}
