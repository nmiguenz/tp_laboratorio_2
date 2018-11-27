using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public enum EMarca
    {
        Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
    }
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        
        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;

        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del producto
        /// </summary>
        protected abstract short CantidadCalorias {
            get;    
        }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public abstract string Mostrar();

        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("CODIGO DE BARRAS: {0}", p.codigoDeBarras));
            sb.AppendLine(string.Format("MARCA          : {0}", p.marca.ToString()));
            sb.AppendLine(string.Format("COLOR EMPAQUE  : {0}", p.colorPrimarioEmpaque.ToString()));
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="productoUno"></param>
        /// <param name="productoDos"></param>
        /// <returns></returns>
        public static bool operator ==(Producto productoUno, Producto productoDos)
        {
            return (productoUno.codigoDeBarras == productoDos.codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="productoUno"></param>
        /// <param name="productoDos"></param>
        /// <returns></returns>
        public static bool operator !=(Producto productoUno, Producto productoDos)
        {
            return !(productoUno == productoDos);
        }

        /// <summary>
        /// Constructor de Producto a partir de la patente, la marca y el color
        /// </summary>
        /// <param name="patente"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Producto (string patente, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = patente;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }
    }
}
