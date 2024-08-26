using Finance.src.shared.application.port.database;

namespace Finance.src.shared.infratruction.services.database
{
    public class MongoSettings: IMongoSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

}
