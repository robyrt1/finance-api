using finance.api.src.category.domain.entity;
using finance.api.src.category.domain.objectValues;
using finance.api.src.category.domain.port.repository;
using Finance.src.shared.application.port.database;
using MongoDB.Driver;

namespace finance.api.src.category.infra.repository
{
    public class SubCategoryRepository : ISubCategoryRepositoryPort
    {

        private readonly IMongoCollection<SubCategory> _SubCategory;

        public SubCategoryRepository(IMongoClient mongoClient, IMongoSettings settings)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _SubCategory = database.GetCollection<SubCategory>("Category");
        }
        public async Task<List<SubCategory>> GetAllAsync() =>
            await _SubCategory.Find(subCategory => true).ToListAsync();

        public async Task<SubCategory> GetByIdAsync(string id) => 
            await _SubCategory.Find(subCategory =>subCategory.Id == id).FirstOrDefaultAsync();

        public async Task<List<SubCategory>> GetByIDCategoryAsync(string id) => 
            await _SubCategory.Find(subCategory => subCategory.Id_Category == id).ToListAsync();
    }
}
