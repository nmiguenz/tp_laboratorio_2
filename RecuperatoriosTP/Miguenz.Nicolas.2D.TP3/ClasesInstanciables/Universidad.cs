using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{

    public class Universidad 
    {
        public enum EClases { Programacion, Laboratorio, Legizlación, SPD}

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
                return Jornadas[i];
            }
            set
            {
                Jornadas[i] = value;
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

        #endregion
    }
}
