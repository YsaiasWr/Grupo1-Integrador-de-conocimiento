using Moq;
using SistemaRecursoshumanos.Application.Contracts.Persistence;
using SistemaRecursoshumanos.Application.Models;
using SistemaRecursoshumanos.Application.Services;
using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.ObjectsValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursosHumanos.Test.CORE.Application.Contracts.Services
{
    [TestClass]
    public class EmpleadoUseCaseTest
    {
        private Mock<IEmpleadoRepositorio> _repoMock;
        private EmpleadosService _service;

        [TestInitialize]
        public void Setup()
        {
            _repoMock = new Mock<IEmpleadoRepositorio>();
            _service = new EmpleadosService(_repoMock.Object);
        }

        // =====================================
        // 🔹 TEST: CREAR EMPLEADO
        // =====================================
        [TestMethod]
        public async Task CrearEmpleado_DeberiaCrearCorrectamente()
        {
            var model = new EmpleadoModel
            {
                TipoEmpleado = "Tiempo completo",
                Documento = "11023454356",
                NombreCompleto = "Juan Perez",
                Telefono = "8092331233",
                Correo = "juan@gmail.com",
                Genero = "Masculino",
                Direccion = "Santo Domingo",
                Estado = "Activo",
                IdDepartamento = Guid.NewGuid(),
                IdCargo = Guid.NewGuid(),
                FechaNacimiento = DateTime.Now.AddYears(-25),
                FechaIngreso = DateTime.Now,
                Salario = 45000,
                Horario = "Mañana",
                Horas = "8",
                Imagen = null
            };

            var entity = new Empleados(
                model.TipoEmpleado,
                new DocumentoVO(model.Documento),
                model.NombreCompleto,
                new TelefonoVO(model.Telefono),
                model.Correo,
                model.Genero,
                model.Direccion,
                model.Estado,
                model.IdDepartamento,
                model.IdCargo,
                model.FechaNacimiento,
                model.FechaIngreso,
                model.Salario,
                model.Horario,
                model.Horas,
                null
            );

            _repoMock
                .Setup(r => r.AgregarAsync(It.IsAny<Empleados>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(entity);

            var result = await _service.CrearEmpleadoAsync(model);

            Assert.IsTrue(result.EsExitoso);
            Assert.IsNotNull(result.Datos);
            Assert.AreEqual("Juan Perez", result.Datos.NombreCompleto);
        }

        // =====================================
        // 🔹 TEST: ACTUALIZAR EMPLEADO
        // =====================================
        [TestMethod]
        public async Task ActualizarEmpleado_DeberiaModificarDatos()
        {
            var id = Guid.NewGuid();

            var empleado = new Empleados(
                "Tiempo completo",
                new DocumentoVO("11023454356"),
                "Juan",
                new TelefonoVO("8092331233"),
                "juan@gmail.com",
                "Masculino",
                "Santo Domingo",
                "Activo",
                Guid.NewGuid(),
                Guid.NewGuid(),
                DateTime.Now.AddYears(-25),
                DateTime.Now,
                45000,
                "Mañana",
                "8",
                null
            );

            // FORZAR ID (solo para test)
            typeof(Empleados)
                .GetProperty("IdEmpleado")!
                .SetValue(empleado, id);

            _repoMock
                .Setup(r => r.ObtenerPorIdAsync(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(empleado);

            _repoMock
                .Setup(r => r.ActualizarAsync(It.IsAny<Empleados>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(empleado);

            var model = new EmpleadoModel
            {
                IdEmpleado = id,
                TipoEmpleado = "Tiempo completo",
                Documento = "11023454356",
                NombreCompleto = "Juan Actualizado",
                Telefono = "8092331233",
                Correo = "juan@gmail.com",
                Genero = "Masculino",
                Direccion = "Santo Domingo",
                Estado = "Activo",
                IdDepartamento = Guid.NewGuid(),
                IdCargo = Guid.NewGuid(),
                FechaNacimiento = DateTime.Now.AddYears(-25),
                FechaIngreso = DateTime.Now,
                Salario = 50000,
                Horario = "Tarde",
                Horas = "8",
                Imagen = null
            };

            var result = await _service.ActualizarEmpleadoAsync(model);

            Assert.IsTrue(result.EsExitoso);
        }

        // =====================================
        // 🔹 TEST: ELIMINAR EMPLEADO
        // =====================================
        [TestMethod]
        public async Task EliminarEmpleado_DeberiaEliminarCorrectamente()
        {
            var id = Guid.NewGuid();

            var empleado = new Empleados(
                "Tiempo completo",
                new DocumentoVO("11023454356"),
                "Juan",
                new TelefonoVO("8092331233"),
                "juan@gmail.com",
                "Masculino",
                "Santo Domingo",
                "Activo",
                Guid.NewGuid(),
                Guid.NewGuid(),
                DateTime.Now.AddYears(-25),
                DateTime.Now,
                45000,
                "Mañana",
                "8",
                null
            );

            _repoMock
                .Setup(r => r.ObtenerPorIdAsync(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(empleado);

            _repoMock
                .Setup(r => r.EliminarAsync(empleado, It.IsAny<CancellationToken>()))
                .ReturnsAsync(empleado);

            var result = await _service.EliminarEmpleadoAsync(id);

            Assert.IsTrue(result.EsExitoso);
        }

        // =====================================
        // 🔹 TEST: OBTENER TODOS
        // =====================================
        [TestMethod]
        public async Task ObtenerEmpleados_DeberiaRetornarLista()
        {
            var lista = new List<Empleados>
            {
                new Empleados(
                    "Tiempo completo",
                    new DocumentoVO("11023454356"),
                    "Juan",
                    new TelefonoVO("8092331233"),
                    "juan@gmail.com",
                    "Masculino",
                    "Santo Domingo",
                    "Activo",
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    DateTime.Now.AddYears(-25),
                    DateTime.Now,
                    45000,
                    "Mañana",
                    "8",
                    null
                )
            };

            _repoMock
                .Setup(r => r.ObtenerTodosAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(lista);

            var result = await _service.ObtenerEmpleadoAsync();

            Assert.IsTrue(result.EsExitoso);
            Assert.IsTrue(result.Datos.Count > 0);
        }

        // =====================================
        // 🔹 TEST: OBTENER POR ID
        // =====================================
        [TestMethod]
        public async Task ObtenerEmpleadoPorId_DeberiaRetornarEmpleado()
        {
            var id = Guid.NewGuid();

            var empleado = new Empleados(
                "Tiempo completo",
                new DocumentoVO("11023454356"),
                "Juan",
                new TelefonoVO("8092331233"),
                "juan@gmail.com",
                "Masculino",
                "Santo Domingo",
                "Activo",
                Guid.NewGuid(),
                Guid.NewGuid(),
                DateTime.Now.AddYears(-25),
                DateTime.Now,
                45000,
                "Mañana",
                "8",
                null
            );

            typeof(Empleados)
                .GetProperty("IdEmpleado")!
                .SetValue(empleado, id);

            _repoMock
                .Setup(r => r.ObtenerPorIdAsync(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(empleado);

            var result = await _service.ObtenerEmpleadoPorIdAsync(id);

            Assert.IsTrue(result.EsExitoso);
            Assert.AreEqual("Juan", result.Datos.NombreCompleto);
        }

        // =====================================
        // 🔹 TEST: NO EXISTE EMPLEADO
        // =====================================
        [TestMethod]
        public async Task ActualizarEmpleado_NoExiste_DeberiaFallar()
        {
            _repoMock
                .Setup(r => r.ObtenerPorIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Empleados)null);

            var model = new EmpleadoModel
            {
                IdEmpleado = Guid.NewGuid(),
                TipoEmpleado = "Test",
                Documento = "123",
                NombreCompleto = "Test",
                Telefono = "123",
                Correo = "test@test.com",
                Genero = "M",
                Direccion = "X",
                Estado = "Activo",
                IdDepartamento = Guid.NewGuid(),
                IdCargo = Guid.NewGuid(),
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                Salario = 1000,
                Horario = "M",
                Horas = "8",
                Imagen = null
            };

            var result = await _service.ActualizarEmpleadoAsync(model);

            Assert.IsFalse(result.EsExitoso);
        }
    }
}
