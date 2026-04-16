using SistemaRecursosHumanos.Application.UseCases;
using SistemaRecursosHumanos.Core.Persistence;
using SistemaRecursosHumanos.Domain.Entities;
using Xunit;

namespace SistemaRecursosHumanos.Tests
{
    public class RegistrarRolUseCaseTests
    {
        [Fact]
        public void DebeRegistrarRolCorrectamente()
        {
            var repo = new RolRepositorio();
            var useCase = new RegistrarRolUseCase(repo);

            var rol = new Rol { Nombre = "Admin" };
            useCase.Ejecutar(rol);

            Assert.Single(repo.ObtenerTodos());
            Assert.Equal("Admin", repo.ObtenerTodos().First().Nombre);
        }

        [Fact]
        public void DebeFallarSiNombreEsVacio()
        {
            var repo = new RolRepositorio();
            var useCase = new RegistrarRolUseCase(repo);

            var rol = new Rol { Nombre = "" };

            Assert.Throws<Exception>(() => useCase.Ejecutar(rol));
        }
    }
}
