using Moq;
using SistemaRecursoshumanos.Application.Contracts.Persistence;
using SistemaRecursoshumanos.Application.Contracts.Services;
using SistemaRecursoshumanos.Application.Models;
using SistemaRecursosHumanos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursosHumanos.Test.CORE.Application.Contracts.Services
{
    [TestClass]
    public class CargoUseCaseTest
    {
        private Mock<ICargo> _repoMock;
        private CargosService _service;

        [TestInitialize]
        public void Setup()
        {
            _repoMock = new Mock<ICargo>();
            _service = new CargosService(_repoMock.Object);
        }

        // =====================================
        // 🔹 TEST: CREAR CARGO
        // =====================================
        [TestMethod]
        public async Task CrearCargo_DeberiaCrearCorrectamente()
        {
            var model = new CargoModel
            {
                NombreCargo = "Contador",
                Descripcion = "Gestiona finanzas",
                Sueldo = 50000,
                IdDepartamento = Guid.NewGuid(),
                FechaRegistro = DateTime.Now,
                Estado = "Activo"
            };

            var entity = new Cargo(
                model.NombreCargo,
                model.Descripcion,
                model.Sueldo,
                model.IdDepartamento,
                model.FechaRegistro,
                model.Estado
            );

            _repoMock
                .Setup(r => r.AgregarAsync(It.IsAny<Cargo>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(entity);

            var result = await _service.CrearAsync(model);

            Assert.IsTrue(result.EsExitoso);
            Assert.IsNotNull(result.Datos);
            Assert.AreEqual("Contador", result.Datos.NombreCargo);
        }

        // =====================================
        // 🔹 TEST: ACTUALIZAR CARGO
        // =====================================
        [TestMethod]
        public async Task ActualizarCargo_DeberiaModificarDatos()
        {
            var id = Guid.NewGuid();

            var cargo = new Cargo(
                "Inicial",
                "Desc",
                30000,
                Guid.NewGuid(),
                DateTime.Now,
                "Activo"
            );

            cargo.IdCargo = id;

            _repoMock
                .Setup(r => r.ObtenerPorIdAsync(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(cargo);

            _repoMock
                .Setup(r => r.ActualizarAsync(It.IsAny<Cargo>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cargo);

            var model = new CargoModel
            {
                IdCargo = id,
                NombreCargo = "Actualizado",
                Descripcion = "Nueva desc",
                Sueldo = 60000,
                IdDepartamento = Guid.NewGuid(),
                FechaRegistro = DateTime.Now,
                Estado = "Activo"
            };

            var result = await _service.ActualizarAsync(model);

            Assert.IsTrue(result.EsExitoso);
        }

        // =====================================
        // 🔹 TEST: ELIMINAR CARGO
        // =====================================
        [TestMethod]
        public async Task EliminarCargo_DeberiaEliminarCorrectamente()
        {
            var id = Guid.NewGuid();

            var cargo = new Cargo(
                "Test",
                "Desc",
                30000,
                Guid.NewGuid(),
                DateTime.Now,
                "Activo"
            );

            _repoMock
                .Setup(r => r.ObtenerPorIdAsync(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(cargo);

            _repoMock
                .Setup(r => r.EliminarAsync(cargo, It.IsAny<CancellationToken>()))
                .ReturnsAsync(cargo);

            var result = await _service.EliminarAsync(id);

            Assert.IsTrue(result.EsExitoso);
            Assert.IsTrue(result.Datos);
        }

        // =====================================
        // 🔹 TEST: OBTENER TODOS
        // =====================================
        [TestMethod]
        public async Task ObtenerTodos_DeberiaRetornarLista()
        {
            var lista = new List<Cargo>
            {
                new Cargo(
                    "Admin",
                    "Gestion general",
                    70000,
                    Guid.NewGuid(),
                    DateTime.Now,
                    "Activo"
                )
            };

            _repoMock
                .Setup(r => r.ObtenerTodosAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(lista);

            var result = await _service.ObtenerTodosAsync();

            Assert.IsTrue(result.EsExitoso);
            Assert.IsTrue(result.Datos.Count > 0);
        }

        // =====================================
        // 🔹 TEST: OBTENER POR ID
        // =====================================
        [TestMethod]
        public async Task ObtenerPorId_DeberiaRetornarCargo()
        {
            var id = Guid.NewGuid();

            var cargo = new Cargo(
                "RRHH",
                "Recursos Humanos",
                40000,
                Guid.NewGuid(),
                DateTime.Now,
                "Activo"
            );

            cargo.IdCargo = id;

            _repoMock
                .Setup(r => r.ObtenerPorIdAsync(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(cargo);

            var result = await _service.ObtenerPorIdAsync(id);

            Assert.IsTrue(result.EsExitoso);
            Assert.IsNotNull(result.Datos);
            Assert.AreEqual("RRHH", result.Datos.NombreCargo);
        }

        // =====================================
        // 🔹 TEST: CARGO NO EXISTE
        // =====================================
        [TestMethod]
        public async Task ActualizarCargo_NoExiste_DeberiaFallar()
        {
            _repoMock
                .Setup(r => r.ObtenerPorIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Cargo)null);

            var model = new CargoModel
            {
                IdCargo = Guid.NewGuid(),
                NombreCargo = "Test",
                Descripcion = "Test",
                Sueldo = 10000,
                IdDepartamento = Guid.NewGuid(),
                FechaRegistro = DateTime.Now,
                Estado = "Activo"
            };

            var result = await _service.ActualizarAsync(model);

            Assert.IsFalse(result.EsExitoso);
        }
    }
}

