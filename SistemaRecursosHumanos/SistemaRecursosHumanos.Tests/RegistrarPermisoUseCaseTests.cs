using SistemaRecursosHumanos.Application.UseCases;
using SistemaRecursosHumanos.Core.Persistence;
using SistemaRecursosHumanos.Domain.Entities;
using Xunit;

namespace SistemaRecursosHumanos.Tests
{
    public class RegistrarPermisoUseCaseTests
    {
        [Fact]
        public void DebeRegistrarPermisoCorrectamente()
        {
            var repo = new PermisoRepositorio();
            var useCase = new RegistrarPermisoUseCase(repo);

            var permiso = new Permiso { Nombre = "GenerarReportes" };
            useCase.Ejecutar(permiso);

            Assert.Single(repo.ObtenerTodos());
            Assert.Equal("GenerarReportes", repo.ObtenerTodos().First().Nombre);
        }

        [Fact]
        public void DebeFallarSiNombreEsVacio()
        {
            var repo = new PermisoRepositorio();
            var useCase = new RegistrarPermisoUseCase(repo);

            var permiso = new Permiso { Nombre = "" };

            Assert.Throws<Exception>(() => useCase.Ejecutar(permiso));
        }
    }
}
