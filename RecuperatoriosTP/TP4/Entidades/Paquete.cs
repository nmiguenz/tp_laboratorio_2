using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace Entidades
{
    
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado{ Ingresado, EnViaje, Entregado}

        public delegate void DelegadoEstado(Object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        #region ATRIBUTOS
        string direccionEntrega;
        EEstado estado;
        string trackingID;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Devuelve y setea la direccion de entrega.
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Devuelve y setea el estado del paquete.
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
    
        /// <summary>
        /// Devuelve y setea la identificación del paquete
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de instancia paquete
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = default(EEstado);
        }
        #endregion

        #region MÉTODOS
        /// <summary>
        /// Muestra los datos del paquete segun TrackingID y direccion de entrega
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Devuelve un string con los datos</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete) elemento;

            return String.Format("{0} para {1}", p.TrackingID, p.DireccionEntrega);
        }

        /// <summary>
        /// Sobrecarga del método ToString, que hace visible la información del paquete.
        /// </summary>
        /// <returns>Devuelve un string con los datos</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Cambia el estado del paquete con un retraso de 4 segundos. 
        /// Cuando el estado cambia a ENTREGADO, el paquete se guarda en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            while(this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado++;
                //Tengo dudas sobre si debo usarlo asi
                // this.InformaEstado.Invoke(null, null);
                this.InformaEstado.Invoke(this, null);
            }

            //Utilizo un condicional porque no puedo capturar la excepcion. Error!
            if (Paquete.EEstado.Entregado == this.Estado)
                PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Dos paquetes serán iguales si tienen el mismo TrackingID.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>True si son iguales; False si no lo son</returns>
        public static bool operator == (Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if (p1.TrackingID == p2.TrackingID)
                retorno = true;
            return retorno;
        }

        /// <summary>
        /// Dos paquetes serán diferentes si los TrackingID son distintos.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>True si son diferentes; False si no lo son</returns>
        public static bool operator != (Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
