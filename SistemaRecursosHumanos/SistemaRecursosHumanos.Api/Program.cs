using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
// 👇 ESTE using es importante para Swagger
//using Microsoft.OpenApi.Models;
using SistemaRecursoshumanos.Application.Contracts.Persistence;
using SistemaRecursoshumanos.Application.Contracts.UseCases;
using SistemaRecursoshumanos.Application.Services;
using SistemaRecursosHumanos.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔹 DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// 🔹 Repositorios
builder.Services.AddScoped<IEmpleadoRepositorio, EmpleadoRepositorio>();

// 🔹 UseCases
builder.Services.AddScoped<IGestionEmpleadosUseCase, GestionEmpleadosUseCase>();

// 🔹 Controllers
builder.Services.AddControllers();

// 🔹 Swagger (REEMPLAZA OpenApi)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// 🔹 Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();