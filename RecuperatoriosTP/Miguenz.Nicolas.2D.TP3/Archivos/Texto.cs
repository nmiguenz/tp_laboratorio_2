using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string> 
    {
        /// <summary>
        /// Guarda un archivo de texto en la ubicacion pasada a través de un string y con los datos proporcionados
        /// </summary>
        /// <param name="archivo">Ubicacion donde se va a guardar el archivo</param>
        /// <param name="datos">Datos que serán agregados al archivo</param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            StreamWriter sw = null;
            // Abro el archivo ubicado en una dirección pasada como parámetro
            sw = new StreamWriter(archivo, true, Encoding.UTF8);

            try
            {
                // Agrego los datos pasados como parámetro 
                sw.WriteLine(datos);
                retorno = true;
            }
            catch(ArchivosException excepcion)
            {
                throw excepcion;
            }
            finally
            {
                // Cierro el archivo 
                if(!(sw is null))
                    sw.Close();
            }

            return retorno;
        }

        /// <summary>
        /// Lee un archivo de texto de la ubicacion pasada a través de un string y copia los datos en un objeto 
        /// </summary>
        /// <param name="archivo">Ubicacion del archivo que va a ser leido</param>
        /// <param name="datos">String donde se guardarán los datos</param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            StreamReader sr = null;
            //Abro un archivo txt de una ubicacion pasada como parámetro
            sr = new StreamReader(archivo, Encoding.UTF8);

            try
            {
                //Leo el archivo hasta el final y lo guardo en una cadena de caracteres
                datos = sr.ReadToEnd();
                retorno = true;
            }
            catch (ArchivosException excepcion)
            {
                throw excepcion;
            }
            finally
            {
                //Si el StreamReader es distinto de null cierro el archivo
                if (!(sr is null))
                    sr.Close();
            }

            return retorno;
        }
    }
}
