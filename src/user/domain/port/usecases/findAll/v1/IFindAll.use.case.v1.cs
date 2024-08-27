
namespace finance.src.user.domain.port.usecases.findAll.v1
{
    public interface IFindAll
    {
        Task<List<UserEntity>> execute();
    }
}
