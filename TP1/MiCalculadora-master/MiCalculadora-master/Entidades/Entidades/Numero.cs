using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Numero
    {

        private double numero;

        public Numero()
        {
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Valida que el string recibido/ingresado sea un Numero.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>num es el string convertido a Double</returns>
        private static double ValidarNumero(string strNumero)
        {
            double num = 0;
            if (EsNumero(strNumero) == true)
            {
                num = Convert.ToDouble(strNumero);
            }

            return num;
        }
        /// <summary>
        /// Valida que el string contenga solo numeros
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>isNum true si es Numero, False si no es numerico</returns>
        public static bool EsNumero(string strNumero)
        {
            double num;
            bool isNum = Double.TryParse(Convert.ToString(strNumero),
               System.Globalization.NumberStyles.Any,
               System.Globalization.NumberFormatInfo.InvariantInfo, out num);
            return isNum;
        }
        /// <summary>
        /// Settea el numero si cumple la condicion de ser tal.
        /// </summary>
        public string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }


        /// <summary>
        /// Convierte de Binario a Decimal un string recibido
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>retorno es el Numero (en string) si se puede convertir o "Valor Invalido" si no </returns>
        public string BinarioDecimal(string binario)
        {

            string retorno2 = "Valor Invalido";
           /* if (EsNumero(binario))
            {
                for (int i = 1; i <= binario.Length; i++)
                {
                    retorno += int.Parse(binario[i - 1].ToString()) * (int)Math.Pow(2, binario.Length - i);
                }
            }*/

            char[] array = binario.ToCharArray();
        
            Array.Reverse(array);
            int retorno = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {
                    // Usamos la potencia de 2, según la posición
                    retorno += (int)Math.Pow(2, i);
                }
            }

           retorno2 = retorno.ToString();

            return retorno2;
        }


        /// <summary>
        /// Convierte de Decimal a Binario el numero recibido
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>bina es el numero convertido a Binario en string</returns>
        public string DecimalBinario(double numero)
        {
            string bina = DecimalBinario(numero.ToString());
            return bina;
        }
        /// <summary>
        /// Convierte de Decimal a Binario el string recibido
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>binario es el numero convertido a Binario</returns>
        public string DecimalBinario(string numero)
        {
            string binario = "";

            int entero = int.Parse(numero);
            while (entero > 0)
            {
                binario = (entero % 2).ToString() + binario;
                entero = entero / 2;
            }

            return binario;
        }
        /// <summary>
        /// Sobrecarga del operador "-" para realizar esa operacion entre 2 Obj de la clase Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>rtn es el double con el valor del resultado de la operacion</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double rtn = n1.numero - n2.numero;
            return rtn;
        }
        /// <summary>
        /// Sobrecarga del operador "+" para realizar esa operacion entre 2 Obj de la clase Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>rtn es el double con el valor del resultado de la operacion</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double rtn;
            rtn = n1.numero + n2.numero;
            return rtn;
        }
        /// <summary>
        /// Sobrecarga del operador "/" para realizar esa operacion entre 2 Obj de la clase Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>rtn es el double con el valor del resultado de la operacion</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double rtn = n1.numero / n2.numero;
            return rtn;
        }
        /// <summary>
        /// Sobrecarga del operador "*" para realizar esa operacion entre 2 Obj de la clase Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>rtn es el double con el valor del resultado de la operacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double rtn = n1.numero * n2.numero;
            return rtn;
        }


    }
}
