using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Excepciones;

namespace EntidadesAbstractas
{

    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region ATRIBUTOS
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Devuelve y setea el nombre de la Persona
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Devuelve y setea el apellido de la Persona
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Devuelve y setea la nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }

        }

        /// <summary>
        /// Devuelve y setea el DNI
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Setea el DNI pasado como string 
        /// </summary>
        public string StringToDni
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de persona por defecto
        /// </summary>
        public Persona()
        {
            this.dni = 0;
        }

        /// <summary>
        /// Constructor de Persona a partir de los datos pasados por parámetro
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) 
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de Persona a partir de los datos pasados por parámetro
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : 
                        this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor de Persona a partir de los datos pasados por parámetro y con el DNI pasado como string
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):
                        this(nombre,apellido,nacionalidad)
        {
            this.StringToDni = dni;
        }
#endregion

        #region MÉTODOS
        /// <summary>
        /// Retorna los datos de la persona en formato String
        /// </summary>
        /// <returns></returns>
        public virtual string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0} {1} ", this.Nombre, this.Apellido);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad.ToString());
            sb.AppendLine("DNI: " + this.DNI);

            return sb.ToString();
        }


        /// <summary>
        /// Validad el DNi, con dato tipo INT 
        /// </summary>
        /// <param name="nacionalidad"> valor campo _nacionalidad</param>
        /// <param name="dato">valor int para _dni</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato >= 1 && dato <= 89999999)
                        return dato;
                    break;

                case ENacionalidad.Extranjero:
                    if (dato >= 90000000 && dato <= 99999999)
                        return dato;
                    break;
            }

            throw new NacionalidadInvalidaException();
        }

        /// <summary>
        /// Valida el DNI pasado como string con la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="numeroDni"></param>
        /// <returns>Devuelve el DNI</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int documento;
            if (int.TryParse(dato, out int dni))
            {
                documento = this.ValidarDni(nacionalidad, dni);
                return documento;
            }
            throw new DniInvalidoException();
        }

        /// <summary>
        /// Valida que el nombre o apellido sea un string que no supere los 30 caracteres.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            if (dato.Length < 30)
            {
                foreach (char caracter in dato)
                {
                    if (!(char.IsLetter(caracter)))
                    {
                        return "No es Nombre o apellido válido";
                    }
                }
            }
            return dato;
        }
        #endregion
    }
}
