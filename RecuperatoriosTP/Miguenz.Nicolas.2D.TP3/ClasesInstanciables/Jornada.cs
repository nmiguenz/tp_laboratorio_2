using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region ATRIBUTOS
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Devuelve y setea la lista de Alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Devulve y setea las clases de tipo EClases.
        /// </summary>
        public Universidad.EClases Clases
        {
            get
            {
                return this.clase;
            }

            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Devuelve y setea un instructor de tipo Profesor.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto que inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de instancia con dos parámetros
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clases = Clases;
            this.Instructor = instructor;
        }
        #endregion

        #region MÉTODOS

        /// <summary>
        /// Guarda en un archivo de texto todos los datos correspondientes a Jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto archivoText = new Texto();

            return (archivoText.Guardar("Jornada.txt", jornada.ToString()));
        }

        /// <summary>
        /// Lee el archivo de texto y devuelve los datos de Jornada
        /// </summary>
        /// <returns>Ldatos de la jornada en formato string</returns>
        public string Leer()
        {
            string datosJornada = null;
            Texto archivoText = new Texto();

            archivoText.Leer("Jornada.txt", out datosJornada);

            return datosJornada;
        }

        /// <summary>
        /// Muestra todos los datos de la Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DE " + this.Clases);
            sb.AppendLine("POR " + this.Instructor);
            sb.AppendLine("ALUMNOS");
            sb.AppendLine("");

            foreach(Alumno alumno in this.Alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Si el alumno no forma parte de la jornada de clases, se lo agrega.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Retorna la jornada con el alumno</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!(j == a))
                j.alumnos.Add(a);

            else
                throw new AlumnoRepetidoException();

            return j;
        }

        /// <summary>
        /// Constata si el alumno participa de la jornada de clases
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>True si participa; False si no participa</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach(Alumno alumno in j.alumnos)
            {
                if (alumno == a)
                    retorno = true;
            }

            return retorno;
        }
        
        /// <summary>
        /// Constata si el alumno no participa de la jornada de clases
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>True si no participa; False si participa</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        #endregion
    }
}