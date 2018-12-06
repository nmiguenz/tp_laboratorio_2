using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guarda un archivo de texto en el escritorio
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns>Si lo hace retorna TRUE, caso contrario FALSE</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;
            string ruta;

            ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo;
            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(ruta, true, Encoding.UTF8);
                writer.Write(texto);
                retorno = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (!(writer is null))
                    writer.Close();
            }

            return retorno;
        }
    }
}
