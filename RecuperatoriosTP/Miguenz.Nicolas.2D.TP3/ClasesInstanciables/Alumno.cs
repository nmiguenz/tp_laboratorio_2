using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesAbstractas;

namespace ClasesInstanciables
{

    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta {AlDia, Deudor, Becado}
        
        #region CAMPOS
        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno() : base()
        {

        }

        /// <summary>
        /// Crea una instancia de alumno con 5 parámetros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="clasesQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma) : 
                        base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = clasesQueToma; 
        }

        /// <summary>
        /// Crea la instancia de Alumno a partir de 6 parámetros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="clasesQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, 
                      EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region MÉTODOS
        /// <summary>
        /// Devuelve un string con los datos del Alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta.ToString());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve un string con la información de la clase que toma 
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return String.Format("TOMA CLASES DE: " + this.claseQueToma.ToString());
        }

        /// <summary>
        /// Muestra los datos de un Alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        
        /// <summary>
        /// Un Alumno será igual a EClase si toma la clase y si no adeuda la cuota
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>True si es verdadero. Sino devuelve False</returns>
        public static bool operator == (Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
                retorno = true;

            return retorno;
        }

        /// <summary>
        /// Un Alumno no será igual a EClase si no toma esa clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>True si no toma la clase</returns>
        public static bool operator != (Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }
        #endregion
    }
}
