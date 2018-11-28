using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region ATRIBUTOS

        Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor statico donde se instancia random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Profesor() : base ()
        {

        }

        /// <summary>
        /// Constructor de instancia de Profesor con 4 parámetros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="dni"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : 
                        base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Agrega una clase a la cola de clases del día del profesor
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 3));
        }

        /// <summary>
        /// Devuelve un string con todos los datos del profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve un string con la clase que dá el profesor ese día.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return String.Format("CLASES DEL DÍA: " + this.clasesDelDia);
        }

        /// <summary>
        /// Hace públicos todos los datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Constata que la clase es una de las que dá el profesor
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>Sie es verdadero, True; caso contrario devuelve False</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach(Universidad.EClases claseDelProfe in i.clasesDelDia)
            {
                if (claseDelProfe == clase)
                    retorno = true;
            }
            
            return retorno;
        }

        /// <summary>
        /// Constata que la clase no es una de las que dá el profesor
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>Si dá la clase devuelve False; si no la dá devuelve True</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}