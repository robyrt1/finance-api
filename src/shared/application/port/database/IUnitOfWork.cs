namespace Finance.src.shared.application.port.database
{
    public interface IUnitOfWork: IDisposable
    {
        Task CommitAsync();
        Task RollbackAsync();
    }
}
