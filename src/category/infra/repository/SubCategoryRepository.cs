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
            _SubCategory = database.GetCollection<SubCategory>("SubCategory");
        }

        public async Task<SubCategory> Create(SubCategory subCategory)
        {
            var newCategory = new SubCategory(subCategory); 
            
            await _SubCategory.InsertOneAsync(newCategory);

            return newCategory;
        }

        public async Task<SubCategory> FindByDescriptionAndCategoryIdAsync(string description, string categoryId)
        {
            var filter = Builders<SubCategory>.Filter.And(
                             Builders<SubCategory>.Filter.Eq(subCategory => subCategory.Descript, description),
                             Builders<SubCategory>.Filter.Eq(subCategory => subCategory.Id_Category, categoryId)
                        );
            return await _SubCategory.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<SubCategory>> GetAllAsync() =>
            await _SubCategory.Find(subCategory => true).ToListAsync();

        public async Task<SubCategory> GetByIdAsync(string id) => 
            await _SubCategory.Find(subCategory =>subCategory.Id == id).FirstOrDefaultAsync();

        public async Task<List<SubCategory>> GetByIDCategoryAsync(string id) => 
            await _SubCategory.Find(subCategory => subCategory.Id_Category == id).ToListAsync();

        public async Task<SubCategory> UpdateCategoryAsync(string id, SubCategory updatedCategory)
        {
            var filter = Builders<SubCategory>.Filter.Eq(category => category.Id, id);
            var update = Builders<SubCategory>.Update
               .Set(category => category.Descript, updatedCategory.Descript);
            var options = new FindOneAndUpdateOptions<SubCategory>
            {
                ReturnDocument = ReturnDocument.After
            };

            return await _SubCategory.FindOneAndUpdateAsync(filter, update, options);
        }
    }
}
