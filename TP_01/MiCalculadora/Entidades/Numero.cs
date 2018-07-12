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

        #region Constructores

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion
        
        #region Set

        /// <summary>
        /// Método que valida valores numericos.
        /// </summary>
        /// <param name="strNumero">Cadena a validar</param>
        /// <returns>Valor ingresado en formato double</returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno=0;
            if (double.TryParse(strNumero, out retorno))
                return retorno;
            return retorno;
        }

        /// <summary>
        /// Propiedad que asigna valor al atributo numero.
        /// </summary>
        /// <returns>Valor ingresado en formato double</returns>
        public string SetNumero
        {
            set
            {
                double aux = ValidarNumero(value);
                if (aux != 0)
                    this.numero = aux;
            }
        }

        #endregion

        #region Conversiones Decimal/Binario

        /// <summary>
        /// Método que convierte un numero binario en un número entero
        /// </summary>
        /// <param name="binario">Binario a convertir.</param>
        /// <returns>Valor entero resultado de la conversión.</returns>
        public static string BinarioDecimal(string binario)
        {
            int nroDecimal = 0, aux = 0;
            string retorno = "";

            for (int i = 1; i <= binario.Length; i++)
            {
                if (Int32.TryParse(binario[i-1].ToString(), out aux) && (aux == 1 || aux == 0))
                {
                    nroDecimal += aux * (int)Math.Pow(2, binario.Length - i);
                    retorno = nroDecimal.ToString();
                }
                else
                    retorno = "Valor invalido";
            }
            return retorno;
        }

        /// <summary>
        /// Método que convierte un número entero en un binario
        /// </summary>
        /// <param name="numero">Número a convertir.</param>
        /// <returns>Valor binario resultado de la conversión.</returns>
        public static string DecimalBinario(double numero)
        {
            string binario = "";
            int entero = (int)numero;
            while (entero >= 2)
            {
                binario = (entero % 2).ToString() + binario;
                entero = (int)entero / 2;
            }
            return entero.ToString()+binario;
        }

        /// <summary>
        /// Método que convierte un string entero en un binario
        /// </summary>
        /// <param name="numero">Número a convertir.</param>
        /// <returns>Valor binario resultado de la conversión.</returns>
        public static string DecimalBinario(string numero)
        {
            string error = "Valor invalido";
            double retorno = 0;

            if(Double.TryParse(numero, out retorno))
                return DecimalBinario(retorno);     
            else
                return error;
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Método que sobrecarga el operador +
        /// </summary>
        /// <param name="n1">Operador de tipo Numero.</param>
        /// <param name="n2">Operador de tipo Numero.</param>
        /// <returns>Resultado de la sobrecarga</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Método que sobrecarga el operador -
        /// </summary>
        /// <param name="n1">Operador de tipo Numero.</param>
        /// <param name="n2">Operador de tipo Numero.</param>
        /// <returns>Resultado de la sobrecarga</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Método que sobrecarga el operador *
        /// </summary>
        /// <param name="n1">Operador de tipo Numero.</param>
        /// <param name="n2">Operador de tipo Numero.</param>
        /// <returns>Resultado de la sobrecarga</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Método que sobrecarga el operador /
        /// </summary>
        /// <param name="n1">Operador de tipo Numero.</param>
        /// <param name="n2">Operador de tipo Numero.</param>
        /// <returns>Resultado de la sobrecarga</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }
        #endregion
    }
}
