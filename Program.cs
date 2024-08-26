using finance.api.src.shared.infratruction.middleware;
using finance.src.user.infra.module.user;
using finance.src.user.infra.repository;
using Finance.src.shared.application.port.database;
using Finance.src.shared.infratruction.services.database;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
});

/*Router*/


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* CONTAINER */

builder.Services.AddUserServices();

//Mongo
builder.Services.Configure<MongoSettings>(
    builder.Configuration.GetSection(nameof(MongoSettings)));


builder.Services.AddSingleton<IMongoSettings>(sp =>
    sp.GetRequiredService<IOptions<MongoSettings>>().Value);

builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddScoped<IUnitOfWork, MongoUnitOfWork>();



//SERVER

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
