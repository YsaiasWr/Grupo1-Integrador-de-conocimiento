using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaRecursosHumanos.Domain.ObjectsValues;
using SistemaRecursosHumanos.Domain.Exceptions;
using System;

namespace SistemaRecursoshumanos.Tests
{
    [TestClass]
    public class DocumentoVOTests
    {
        // =====================================
        // 🔹 TEST: CREACIÓN VÁLIDA
        // =====================================
        [TestMethod]
        public void DocumentoVO_Valido_DeberiaCrearseCorrectamente()
        {
            var documento = new DocumentoVO("12345678901");

            Assert.IsNotNull(documento);
            Assert.AreEqual("12345678901", documento.Valor);
        }

        // =====================================
        // 🔹 TEST: DOCUMENTO VACÍO
        // =====================================
        [TestMethod]
        public void DocumentoVO_Vacio_DeberiaLanzarExcepcion()
        {
            Assert.ThrowsException<ExcepcionReglaNegocio>(() =>
            {
                new DocumentoVO("");
            });
        }

        // =====================================
        // 🔹 TEST: DOCUMENTO NULL
        // =====================================
        [TestMethod]
        public void DocumentoVO_Null_DeberiaLanzarExcepcion()
        {
            Assert.ThrowsException<ExcepcionReglaNegocio>(() =>
            {
                new DocumentoVO(null);
            });
        }

        // =====================================
        // 🔹 TEST: LONGITUD INCORRECTA (MENOS)
        // =====================================
        [TestMethod]
        public void DocumentoVO_LongitudMenor_DeberiaLanzarExcepcion()
        {
            Assert.ThrowsException<ExcepcionReglaNegocio>(() =>
            {
                new DocumentoVO("12345");
            });
        }

        // =====================================
        // 🔹 TEST: LONGITUD INCORRECTA (MÁS)
        // =====================================
        [TestMethod]
        public void DocumentoVO_LongitudMayor_DeberiaLanzarExcepcion()
        {
            Assert.ThrowsException<ExcepcionReglaNegocio>(() =>
            {
                new DocumentoVO("1234567890123");
            });
        }
    }
}