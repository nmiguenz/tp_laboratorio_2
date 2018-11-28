
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ClasesInstanciables;
using Excepciones;

namespace ProyectoTest
{
    [TestClass]
    public class UniversidadTest
    {
        [TestMethod]
        public void TestUniversidadAlumnosProfesorJornadaIsNotNull()
        {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Alumnos);
            Assert.IsNotNull(universidad.Instructores);
            Assert.IsNotNull(universidad.Jornadas);
        }

        [TestMethod]
        public void TestNoHayProfesorParaLaClase_LanzaExecepcionSinProfesorException()
        {
            Universidad universidad = new Universidad();
            Profesor profesor = new Profesor(10, "Juan", "Pérez", "987456", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            Universidad.EClases clase = Universidad.EClases.Programacion;

            try
            {
                profesor = universidad != clase;
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(SinProfesorException));
            }
        }
    }
}
