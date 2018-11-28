using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class XML<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda los datos en un archivo XML
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Si pudo guardarlos retorna True</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            //Objeto que escribirá en XML.
            XmlTextWriter writer = null;
            //Objeto que serializará. 
            XmlSerializer ser = new XmlSerializer(typeof(T));

            try
            {
                //Se indica ubicación del archivo XML y su codificación. 
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                ser.Serialize(writer, datos);
                retorno = true;
            }
            catch(ArchivosException excepcion)
            {
                throw excepcion;
            }
            finally
            {
                //Se cierra la conexion con el archivo
                if (!(writer is null))
                    writer.Close();
            }

            return retorno;
        }

        /// <summary>
        /// Lee los datos de un archivo XML y los guarda en un objeto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;

            //Objeto que leerá XML. 
            XmlTextReader reader = null;
            //Objeto que Deserializará, que indica el tipo de objeto ha serializar. 
            XmlSerializer ser = new XmlSerializer(typeof(T));
            
            try
            {
                //Se indica ubicación del archivo XML. 
                reader = new XmlTextReader(archivo); 
                //Deserializa el archivo contenido en reader, lo guarda en datos. 
                datos = (T)ser.Deserialize(reader);
                retorno = true;
            }
            catch(ArchivosException excepcion)
            {
                throw excepcion;
            }
            finally
            {
                //Se cierra el objeto reader. 
                if(!(reader is null))
                    reader.Close();
            }

            return retorno;
        }
    }
}
