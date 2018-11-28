using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ClasesInstanciables;
using Excepciones;

namespace ProyectoTest
{

    [TestClass]
    public class AlumnoTest
    { 
        string dniValido = "33747845";

        string dniInvalido = "45f558s55";

        [TestMethod]
        public void TestValidarDNiNumerico()
        {
            Alumno alumno = new Alumno(1, "Sergio", "Hernandez", dniValido, EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);

            Assert.AreEqual(int.Parse(this.dniValido), alumno.DNI);
        }

        [TestMethod]
        public void TestDniInvalido_LanzaUnaExcepcion()
        {
            try
            {
                Alumno alumno = new Alumno(1, "Sergio", "Hernandez", dniInvalido, EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
                return;
            }
            Assert.Fail("El DNI invalido {0} no fue capturado", this.dniInvalido);
        }

        [TestMethod]
        public void TestAlumnoRepetido_LanzaExcepcionAlumnoRepetidoException()
        {
            Universidad universidad = new Universidad();

            Alumno alumno = new Alumno(1, "John", "Lennon", "16458698", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            try
            {
                universidad += alumno;
                universidad += alumno;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }
    }
}
