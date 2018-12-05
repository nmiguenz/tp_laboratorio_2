using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Archivos;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;

namespace ClasesInstanciables
{

    public class Universidad 
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD}

        #region ATRIBUTOS
        private List<Alumno> alumnos; //Lista de Inscriptos
        private List<Jornada> jornada;
        private List<Profesor> profesores; //Lista de quienes pueden dar clase
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Devuelve y setea la lista de alumnos
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
        /// Devuelve y setea la lista de Jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Devuelve y setea la lista de Profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Indexador de Jornadas
        /// </summary>
        /// <param name="i"></param>
        /// <returns>Obtiene una jornada específica o la setea</returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.jornada.Count)
                {
                    return this.jornada[i];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de instacia Universidad
        /// </summary>
        public Universidad()
        {
            this.jornada = new List<Jornada>();
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region MÉTODOS
        /// <summary>
        /// Serializa los datos de Universidad en un archivo XML
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            XML<Universidad> guardarXml = new XML<Universidad>();
            
            return (guardarXml.Guardar("Universidad.xml", uni));
        }

        /// <summary>
        /// Obtiene todos los datos de Universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>Devuelve un string con los mismos</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach(Jornada jornada in uni.Jornadas)
            {
                sb.AppendLine(jornada.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Muestra los datos de Universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Se fija si un alumno está inscripto en la Universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>True si está inscripto. False si no</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            
            foreach(Alumno alumno in g.Alumnos)
            {
                if (alumno == a)
                    retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Se fija si el alumno no está inscripto en la Universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>True si no está inscripto. False si lo está.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Se fija si el profesor pertenece a la Universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>True si pertenece. False si no es de la Universidad</returns>
        public static bool operator == (Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach(Profesor instructor in g.Instructores)
            {
                if (instructor == i)
                    retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Se fija si el profesor no pertenece a la Universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>True si no pertenece. False si pertece</returns>
        public static bool operator != (Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Se fija quién es el primer profesor que puede dar la clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>Si lo encuentra devuelve al profesor. Si no lanza una excepción</returns>
        public static Profesor operator == (Universidad u, EClases clase)
        {
            Profesor retorno = new Profesor();
            int i;
            bool posicion = false;


            for (i = 0; i < u.profesores.Count; i++)
            {
                if (u.profesores[i] == clase)
                {
                    retorno = u.profesores[i];
                    posicion = true;
                    break;
                }
            }
            if (posicion == false)
            {

                throw new SinProfesorException();
            }
            return retorno;
        }

        /// <summary>
        /// Se fija quién es el primer profesor que no puede dar la clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>Si lo encuentra devuelve el profesor. Si no, lanza una excepción</returns>
        public static Profesor operator != (Universidad u, EClases clase)
        {
            Profesor retorno = new Profesor();
            int i;

            for (i = 0; i < u.profesores.Count; i++)
            {
                if (u.profesores[i] != clase)
                {
                    retorno = u.profesores[i];
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Agrega una nueva Jornada a la Universidad segun la clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clases"></param>
        /// <returns>La universidad</returns>
        public static Universidad operator +(Universidad g, EClases clases)
        {
            Jornada nuevaJornada = new Jornada(clases , g == clases);

            foreach(Alumno alumno in g.Alumnos)
            {
                if (alumno == clases)
                    nuevaJornada += alumno;
            }

            g.Jornadas.Add(nuevaJornada);
            return g;
        }

        /// <summary>
        /// Agrega un alumno si este no estaba previamente cargado en la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>La universidad</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u == a)
            {
                throw new AlumnoRepetidoException();
            }
            else
            {
                u.alumnos.Add(a);
            }

            return u;
        }

        /// <summary>
        /// Agrega un profesor si este no estaba previamente cargado en la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns>La universidad</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.Instructores.Add(i);

            return u; 
        }
        #endregion
    }
}
