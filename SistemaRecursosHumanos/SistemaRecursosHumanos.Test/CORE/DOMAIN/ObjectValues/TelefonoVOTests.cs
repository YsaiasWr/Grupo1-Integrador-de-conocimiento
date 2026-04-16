using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaRecursosHumanos.Domain.ObjectsValues;
using SistemaRecursosHumanos.Domain.Exceptions;

namespace SistemaRecursoshumanos.Tests
{
    [TestClass]
    public class TelefonoVOTests
    {
        // =====================================
        // 🔹 TEST: TELÉFONO VÁLIDO
        // =====================================
        [TestMethod]
        public void TelefonoVO_Valido_DeberiaCrearseCorrectamente()
        {
            var telefono = new TelefonoVO("8091234567");

            Assert.IsNotNull(telefono);
            Assert.AreEqual("8091234567", telefono.Valor);
        }

        // =====================================
        // 🔹 TEST: VACÍO
        // =====================================
        [TestMethod]
        public void TelefonoVO_Vacio_DeberiaLanzarExcepcion()
        {
            Assert.ThrowsException<ExcepcionReglaNegocio>(() =>
            {
                new TelefonoVO("");
            });
        }

        // =====================================
        // 🔹 TEST: NULL
        // =====================================
        [TestMethod]
        public void TelefonoVO_Null_DeberiaLanzarExcepcion()
        {
            Assert.ThrowsException<ExcepcionReglaNegocio>(() =>
            {
                new TelefonoVO(null);
            });
        }

        // =====================================
        // 🔹 TEST: MENOS DE 10 CARACTERES
        // =====================================
        [TestMethod]
        public void TelefonoVO_LongitudMenor_DeberiaLanzarExcepcion()
        {
            Assert.ThrowsException<ExcepcionReglaNegocio>(() =>
            {
                new TelefonoVO("12345");
            });
        }

        // =====================================
        // 🔹 TEST: MÁS DE 10 CARACTERES
        // =====================================
        [TestMethod]
        public void TelefonoVO_LongitudMayor_DeberiaLanzarExcepcion()
        {
            Assert.ThrowsException<ExcepcionReglaNegocio>(() =>
            {
                new TelefonoVO("1234567890123");
            });
        }
    }
}