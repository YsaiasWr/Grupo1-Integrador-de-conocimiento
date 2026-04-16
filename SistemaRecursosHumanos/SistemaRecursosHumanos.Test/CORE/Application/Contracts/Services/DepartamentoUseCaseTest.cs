using Moq;
using SistemaRecursoshumanos.Application.Contracts.Persistence;
using SistemaRecursosHumanos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursosHumanos.Test.CORE.Application.Contracts.Services
{
    [TestClass]
    public class DepartamentoUseCaseTest
    {
        private Mock<IDepartamento> _repoMock;

        [TestInitialize]
        public void Setup()
        {
            _repoMock = new Mock<IDepartamento>();
        }

        // =====================================
        // 🔹 TEST: CREAR DEPARTAMENTO
        // =====================================
        [TestMethod]
        public async Task CrearDepartamento_DeberiaGuardarCorrectamente()
        {
            var depto = new Departamento(
                "Recursos Humanos",
                DateTime.Now,
                "Activo"
            );

            _repoMock
                .Setup(r => r.AgregarAsync(It.IsAny<Departamento>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(depto);

            var result = await _repoMock.Object.AgregarAsync(depto);

            Assert.IsNotNull(result);
            Assert.AreEqual("Recursos Humanos", result.Descripcion);
        }

        // =====================================
        // 🔹 TEST: ACTUALIZAR DEPARTAMENTO
        // =====================================
        [TestMethod]
        public async Task ActualizarDepartamento_DeberiaModificarDatos()
        {
            var depto = new Departamento(
                "TI",
                DateTime.Now,
                "Activo"
            );

            _repoMock
                .Setup(r => r.ActualizarAsync(It.IsAny<Departamento>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(depto);

            var result = await _repoMock.Object.ActualizarAsync(depto);

            Assert.IsNotNull(result);
            Assert.AreEqual("TI", result.Descripcion);
        }

        // =====================================
        // 🔹 TEST: ELIMINAR DEPARTAMENTO
        // =====================================
        [TestMethod]
        public async Task EliminarDepartamento_DeberiaEliminarCorrectamente()
        {
            var depto = new Departamento(
                "Finanzas",
                DateTime.Now,
                "Activo"
            );

            _repoMock
                .Setup(r => r.EliminarAsync(It.IsAny<Departamento>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(depto);

            var result = await _repoMock.Object.EliminarAsync(depto);

            Assert.IsNotNull(result);
        }

        // =====================================
        // 🔹 TEST: OBTENER TODOS
        // =====================================
        [TestMethod]
        public async Task ObtenerTodos_DeberiaRetornarLista()
        {
            var lista = new List<Departamento>
            {
                new Departamento("RRHH", DateTime.Now, "Activo"),
                new Departamento("IT", DateTime.Now, "Activo")
            };

            _repoMock
                .Setup(r => r.ObtenerTodosAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(lista);

            var result = await _repoMock.Object.ObtenerTodosAsync();

            Assert.IsTrue(result.Count > 0);
        }

        // =====================================
        // 🔹 TEST: OBTENER POR ID
        // =====================================
        [TestMethod]
        public async Task ObtenerPorId_DeberiaRetornarDepartamento()
        {
            var depto = new Departamento(
                "Marketing",
                DateTime.Now,
                "Activo"
            );

            var id = depto.IdDepartamento;

            _repoMock
                .Setup(r => r.ObtenerPorIdAsync(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(depto);

            var result = await _repoMock.Object.ObtenerPorIdAsync(id);

            Assert.IsNotNull(result);
            Assert.AreEqual("Marketing", result.Descripcion);
        }
    }
}

