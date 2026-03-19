using Microsoft.EntityFrameworkCore;
using SistemaRecursoshumanos.Application.Contracts.Persistence;
using SistemaRecursoshumanos.Application.Contracts.UseCases;
using SistemaRecursoshumanos.Application.Services;

// 👇 IMPORTANTE: agregar estos using

using SistemaRecursosHumanos.Infrastructure.Data;
using SistemaRecursosHumanos.Infrastructure;   

var builder = WebApplication.CreateBuilder(args);

// 🔹 DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// 🔹 Repositorios (Infrastructure)
builder.Services.AddScoped<IEmpleadoRepositorio, EmpleadoRepositorio>();

// 🔹 UseCases (Application)
builder.Services.AddScoped<IGestionEmpleadosUseCase, GestionEmpleadosUseCase>();

// 🔹 Controllers
builder.Services.AddControllers();

// 🔹 Swagger / OpenAPI
builder.Services.AddOpenApi();

var app = builder.Build();

// 🔹 Pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();