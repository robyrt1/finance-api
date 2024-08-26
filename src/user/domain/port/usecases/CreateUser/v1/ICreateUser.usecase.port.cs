namespace finance.src.user.domain.port.usecases.CreateUser.v1
{
    public interface ICreateUserPort
    {
        Task<IEnumerable<UserEntity>> execute(IInputCreateUser input);
    }
}
