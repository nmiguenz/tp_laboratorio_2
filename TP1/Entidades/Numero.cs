using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public Numero()
        {
            numero = 0;
        }

        /// <summary>
        /// Setter
        /// </summary>
        public string SetNumero
        {
            set
            {
                if (ValidarNumero(value)!=0)
                {
                    this.numero = ValidarNumero(value);
                }
            }
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero (string strNumero)
        {
            this.SetNumero = strNumero;
        }

        private static double ValidarNumero(string strNumero)
        {
            bool numeroValido;
            numeroValido = double.TryParse(strNumero, out double numero);

            if (numeroValido)
            {
                return numero;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Convierte un número binario a decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>el numero en formato string</returns>
        public static string BinarioDecimal(string binario)
        {
            string stringNumero = "";
            int cantidadDeCifras;
            bool numeroValido;
            numeroValido = double.TryParse(binario, out double numeroDecimal);

            if (numeroValido)
            {
                cantidadDeCifras = binario.Length;
                numeroDecimal = 0;
                for (int i = 0; i < cantidadDeCifras; i++)
                {
                    if (binario.ElementAt(i) == '1')
                    {
                        numeroDecimal = numeroDecimal + Math.Pow(2, cantidadDeCifras - i - 1);
                    }
                    else if (binario.ElementAt(i) != '0')
                    {
                        return "Numero invalido";
                    }
                }

                stringNumero = numeroDecimal + "";
            }
            else
                stringNumero = "Numero invalido";

            return stringNumero;
        }
        
        /// <summary>
        /// Convierte un número decimal a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>retorna un string de número en binario</returns>
        public static string DecimalBinario(double numero)
        {
            string numeroBinario = "";
            if (numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        numeroBinario = "0" + numeroBinario;
                    }
                    else
                    {
                        numeroBinario = "1" + numeroBinario;
                    }
                    numero = (int)numero / 2;
                }
            }
            else if (numero == 0)
            {
                numeroBinario = "0";
            }
            else
            {
                numeroBinario = "No se pudo convertir a binario";
            }

            return numeroBinario;
        }

        /// <summary>
        /// Convierte un número decimal a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(string numero)
        {
            
            double numeroDecimal;
            bool numeroValido;

            string numeroEnBinario = "Numero invalido";

            numeroValido = double.TryParse(numero, out numeroDecimal);

            if (numeroValido)
                numeroEnBinario = DecimalBinario(numeroDecimal);

            return numeroEnBinario;
        }

        public static double operator - (Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator * (Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator / (Numero n1, Numero n2)
        {
            if (n2.numero != 0)
                return n1.numero / n2.numero;
            else
                return double.MinValue;
        }

        public static double operator + (Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
    }
}
