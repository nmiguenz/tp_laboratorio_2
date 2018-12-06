using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region ATRIBUTOS
        List<Thread> mockPaquetes;
        List<Paquete> paquetes;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Devuelve y setea una lista de paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Constructor por defecto de correo
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion

        #region MÉTODOS

        /// <summary>
        /// Si hay hilos activos en la lista mockPaquetes, los cierra.
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread t in mockPaquetes)
            {
                if (t.IsAlive)
                    t.Abort();
            }
        }
    
        /// <summary>
        /// Devuelve todos los datos de los paquetes
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Devuelve un string</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            List<Paquete> listaPaquetes = (List<Paquete>)((Correo) elemento).paquetes;

            string datos = "";

            foreach(Paquete p in listaPaquetes)
            {
                datos += String.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }

            return datos;
        }

        /// <summary>
        /// Agrega un paquete a la lista de paquetes del correo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns>Devuelve un objeto correo con el paquete agregado</returns>
        public static Correo operator + (Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.paquetes)
            {
                if (paquete == p)
                    throw new TrackingIdRepetidoException("El ID del paquete es repetido");               
            }
            //Agrego paquete a la lista
            c.paquetes.Add(p);
            //Creo hilo para el método mockCicloDeVida
            Thread hilo = new Thread(p.MockCicloDeVida);
            //Agrego el hilo al mock de paquetes
            c.mockPaquetes.Add(hilo);
            //Inicio hilo
            hilo.Start();

            return c;
        }
        #endregion
    }
}
