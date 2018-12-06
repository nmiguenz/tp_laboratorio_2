using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Sql;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region ATRIBUTOS
        static SqlConnection conexion;
        static SqlCommand comando;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Constructor de instancia. Inicializa la conexión y el comando
        /// </summary>
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True");
            PaqueteDAO.comando = new SqlCommand();
        }
        #endregion

        #region MÉTODOS
        /// <summary>
        /// Inserta el paquete en la base de datos. En caso negativo lanza una excepción.
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Si logra insertarlo devuelve TRUE; caso contrario FALSE</returns>
        public static bool Insertar (Paquete p)
        {
            bool retorno = false;

            try
            {
                PaqueteDAO.conexion.Open();
                string alumnoDatos = "Nicolás Miguenz";
                string consulta = String.Format("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno)" + "VALUES ('{0}','{1}','{2}')", 
                                                p.DireccionEntrega,p.TrackingID,alumnoDatos);
                PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
                PaqueteDAO.comando.CommandText = consulta;
                PaqueteDAO.comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (!(PaqueteDAO.conexion is null))
                    PaqueteDAO.conexion.Close();
            }

            return retorno;
        }
        #endregion
    }
}
