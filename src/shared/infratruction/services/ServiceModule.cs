using Finance.src.shared.application.port.database;
using Finance.src.shared.infratruction.services.database;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

public static class ServiceModule
{
    public static void AddCommonServices(this IServiceCollection services, IConfiguration configuration)
    {
       services.AddScoped<IPasswordHasher, PasswordHasher>();

       services.Configure<MongoSettings>(
       configuration.GetSection(nameof(MongoSettings)));
       services.AddSingleton<IMongoSettings>(sp =>
           sp.GetRequiredService<IOptions<MongoSettings>>().Value);
       services.AddSingleton<IMongoClient, MongoClient>(sp =>
       {
           var settings = sp.GetRequiredService<IOptions<MongoSettings>>().Value;
           return new MongoClient(settings.ConnectionString);
       });
       services.AddScoped<IUnitOfWork, MongoUnitOfWork>();
    }
}
