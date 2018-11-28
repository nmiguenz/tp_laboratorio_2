using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region PARÁMETROS
        private int legajo;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto de Universitarios
        /// </summary>
        public Universitario() : base()
        {

        }

        /// <summary>
        /// Constructor con parámetros de Universitario
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad): 
                            base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region MÉTODOS
        /// <summary>
        /// Se fija si el tipo de la instancia actual es igual a la del objeto pasado por parámetro 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals (object obj)
        {
            bool retorno = false;

            if (this.GetType() == obj.GetType())
                retorno = true;

            return retorno;
        }

        /// <summary>
        /// Devuelve un string con los datos del Universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos() 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NÚMERO: " + this.legajo);

            return sb.ToString();
        }

        /// <summary>
        /// Método abstracto Participar en clase    
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Dos objetos serán iguales si son del mismo tipo y comparten el legajo o el mismo DNI
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>True si cumplen las condiciones; caso contrario devuelve false</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            if (pg1.Equals(pg2))
                if (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
                    retorno = true;

            return retorno;
        }

        /// <summary>
        /// Dos objetos serán diferentes si no son del mismo tipo y no comparten el mismo legajo o DNI
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>True si cumplen las condiciones; caso contrario devuelve false</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
