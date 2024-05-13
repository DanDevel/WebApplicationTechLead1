using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using WebApplicationTechLead1.Infrastructure;
using WebApplicationTechLead1.Domain.Repositories;
using WebApplicationTechLead1.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração do serviço de DbContext para o banco de dados relacional
builder.Services.AddDbContext<AppDbContext>();

// Configuração dos serviços da aplicação
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ClienteService>();

builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cadastro de Clientes", Version = "v1" });
});

var app = builder.Build();

// Configuração do Swagger
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
