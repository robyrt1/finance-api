using finance.api.src.category.domain.entity;
using finance.api.src.category.domain.port.repository;
using Finance.src.shared.application.port.database;
using MongoDB.Driver;

namespace finance.api.src.category.infra.repository
{
    public class CategoryRepository : ICategoryRepositoryPort
    {
        private readonly IMongoCollection<Category> _Category;

        public CategoryRepository(IMongoClient mongoClient, IMongoSettings settings) {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _Category = database.GetCollection<Category>("Category");
        }

        public async Task<List<Category>> GetAllAsync() => 
            await _Category.Find(category => true).ToListAsync();

        public async Task<Category> GetByIdAsync(string id) => 
            await _Category.Find(category => category.Id == id).FirstOrDefaultAsync();

        public async Task<Category> GetByDescriptAsync(string descript) =>
            await _Category.Find(category => category.Descript == descript).FirstOrDefaultAsync();

        public async Task<Category> CreateCategoryAsync(Category input) 
        {
            var newCategory = new Category(input);

            await _Category.InsertOneAsync(newCategory);

            return newCategory;
        }
    }
}
