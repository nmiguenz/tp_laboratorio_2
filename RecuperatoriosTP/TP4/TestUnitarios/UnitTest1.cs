using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Entidades;
using System.Collections.Generic;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ListaPaquetesDeCorreo_VerificaInstancia()
        {
            List<Paquete> paquetes;

            Correo correo = new Correo();

            paquetes = correo.Paquetes;

            Assert.IsNotNull(paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void VerificaPaquetesPorID_LanzaTrackingIdRepetidoException()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("9 de Julio", "1234");
            Paquete p2 = new Paquete("Azcuenaga", "1234");

            correo += p1;
            correo += p2;
            Assert.Fail();
        }
    }
}