using finance.api.src.shared.infratruction.middleware;
using finance.src.user.infra.module.user;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.IncludeFields = true;
});
//.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* CONTAINER */

builder.Services.AddUserServices();
builder.Services.AddCommonServices(builder.Configuration);



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
