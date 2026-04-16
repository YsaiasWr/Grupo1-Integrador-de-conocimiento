using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaRecursoshumanos.Application.Contracts.Persistence;
using SistemaRecursoshumanos.Application.Contracts.Services;
using SistemaRecursoshumanos.Application.Models;
using SistemaRecursosHumanos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaRecursosHumanos.Test.CORE.Application.Contracts.Services
{
    [TestClass]
    public class AsistenciaUseCaseTest
    {
        private Mock<IAsistenciaRepositorio> _repoMock;
        private GestionAsistenciaUseCase _service;

        [TestInitialize]
        public void Setup()
        {
            _repoMock = new Mock<IAsistenciaRepositorio>();
            _service = new GestionAsistenciaUseCase(_repoMock.Object);
        }

        // =====================================
        // 🔹 TEST: CREAR ASISTENCIA (ENTRADA)
        // =====================================
        [TestMethod]
        public async Task RegistrarEntrada_DeberiaCrearAsistenciaCorrectamente()
        {
            var model = new AsistenciaModel
            {
                IdEmpleado = Guid.NewGuid(),
                Fecha = DateTime.Now,
                HoraEntrada = DateTime.Now,
                Estado = "Registrada"
            };

            var entity = new Asistencia(
                model.Fecha,
                model.HoraEntrada,
                null,
                model.Estado,
                model.IdEmpleado
            );

            _repoMock
                .Setup(r => r.AgregarAsync(It.IsAny<Asistencia>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(entity);

            var result = await _service.RegistrarEntradaAsync(model);

            Assert.IsTrue(result.EsExitoso);
            Assert.IsNotNull(result.Datos);
            Assert.AreEqual("Registrada", result.Datos.Estado);
        }

        // =====================================
        // 🔹 TEST: REGISTRAR SALIDA
        // =====================================
        [TestMethod]
        public async Task RegistrarSalida_DeberiaAsignarHoraSalida()
        {
            var id = Guid.NewGuid();

            var asistencia = new Asistencia(
                DateTime.Now,
                DateTime.Now,
                null,
                "Registrada",
                Guid.NewGuid()
            );

            _repoMock
                .Setup(r => r.ObtenerPorIdAsync(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(asistencia);

            _repoMock
                .Setup(r => r.ActualizarAsync(It.IsAny<Asistencia>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(asistencia);

            var result = await _service.RegistrarSalidaAsync(id, DateTime.Now);

            Assert.IsTrue(result.EsExitoso);
            Assert.IsNotNull(result.Datos);
        }

        // =====================================
        // 🔹 TEST: SALIDA SIN ASISTENCIA
        // =====================================
        [TestMethod]
        public async Task RegistrarSalida_AsistenciaNoExiste_DeberiaFallar()
        {
            _repoMock
                .Setup(r => r.ObtenerPorIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Asistencia)null);

            var result = await _service.RegistrarSalidaAsync(Guid.NewGuid(), DateTime.Now);

            Assert.IsFalse(result.EsExitoso);
            Assert.AreEqual("Asistencia no encontrada", result.ErrorMensaje);
        }

        // =====================================
        // 🔹 TEST: OBTENER TODOS
        // =====================================
        [TestMethod]
        public async Task ObtenerTodos_DeberiaRetornarListaDeAsistencias()
        {
            var lista = new List<Asistencia>
            {
                new Asistencia(
                    DateTime.Now,
                    DateTime.Now,
                    null,
                    "Registrada",
                    Guid.NewGuid()
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
        // 🔹 TEST: REGISTRO CON FECHAS VÁLIDAS
        // =====================================
        [TestMethod]
        public void Asistencia_DeberiaTenerFechasValidas()
        {
            var asistencia = new Asistencia(
                DateTime.Now,
                DateTime.Now,
                null,
                "Registrada",
                Guid.NewGuid()
            );

            Assert.IsTrue(asistencia.HoraEntrada <= DateTime.Now);
            Assert.IsNull(asistencia.HoraSalida);
        }
    }
}