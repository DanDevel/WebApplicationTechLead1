using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApplicationTechLead1.Domain.Repositories;
using WebApplicationTechLead1.Infrastructure;
using WebApplicationTechLead1.Services.Handlers;
using WebApplicationTechLead1.Services;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ClienteService>();

var mongoDBConnectionString = builder.Configuration.GetConnectionString("MongoDBConnection");
var mongoDBDatabaseName = builder.Configuration.GetConnectionString("MongoDBName");
builder.Services.AddSingleton(_ => new MongoDBContext(mongoDBConnectionString, mongoDBDatabaseName));
builder.Services.AddScoped<TesteQueryHandler>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cadastro de Clientes", Version = "v1" });
});

var app = builder.Build();

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:3000", "http://192.168.0.14:3000")
           .AllowAnyHeader()
           .AllowAnyMethod();
});


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cadastro de Clientes V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
