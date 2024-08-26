using Finance.src.shared.application.port.database;
using MongoDB.Driver;

namespace Finance.src.shared.infratruction.services.database
{
    public class MongoUnitOfWork: IUnitOfWork
    {
        private readonly IClientSessionHandle _session;

        public MongoUnitOfWork(IMongoClient mongoClient)
        {
            _session = mongoClient.StartSession();
            _session.StartTransaction();
        }

        public async Task CommitAsync()
        {
            await _session.CommitTransactionAsync();
        }

        public async Task RollbackAsync()
        {
            await _session.AbortTransactionAsync();
        }

        public void Dispose()
        {
            _session.Dispose();
        }
    }
}
