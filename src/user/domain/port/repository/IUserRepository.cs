

public interface IUserRepository
{
    Task<IEnumerable<UserEntity>> GetAllAsync();
    Task<UserEntity> GetByIdAsync(string id);
    Task<UserEntity> GetByEmailAsync(string email);
    Task<UserEntity> CreateAsync(IInputCreateUser user);
    Task UpdateAsync(string id, UserEntity user);
    Task DeleteAsync(string id);
}
