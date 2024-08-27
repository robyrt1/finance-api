
using Finance.src.shared.application.port.database;
using Microsoft.SharePoint.Client;
using MongoDB.Bson;
using MongoDB.Driver;

namespace finance.src.user.infra.repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserEntity> _users;

        public UserRepository(IMongoClient mongoClient, IMongoSettings settings)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<UserEntity>("Users");
        }

        public async Task<UserEntity> CreateAsync(IInputCreateUser input)
        {
            var newUser = new UserEntity
            {
                Id = Guid.NewGuid().ToString(),
                UserName = input.UserName,
                Email = input.Email,
                Password = input.Password,
            };

            await _users.InsertOneAsync(newUser);

            return newUser;
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserEntity>> GetAllAsync() =>
             await _users.Find(user => true).ToListAsync();

        public async  Task<UserEntity> GetByIdAsync(string id)
        => await _users.Find(user => user.Id == id).FirstOrDefaultAsync();

        public async Task<UserEntity> GetByEmailAsync(string email) { 
            return await _users.Find(user => user.Email == email).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string id, UserEntity userIn)
        => await _users.ReplaceOneAsync(user => user.Id == id, userIn);
    }
}
