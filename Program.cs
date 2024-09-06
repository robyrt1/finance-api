using finance.api.src.shared.infratruction.middleware;
using finance.src.user.infra.module.user;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
    options.Filters.Add<ConflictExceptionFilter>();
    options.Filters.Add<NotFoundExceptionFilter>();
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.IncludeFields = true;
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* CONTAINER */

builder.Services.AddUserServices();
builder.Services.AddCommonServices(builder.Configuration);

/*Version*/
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});


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
