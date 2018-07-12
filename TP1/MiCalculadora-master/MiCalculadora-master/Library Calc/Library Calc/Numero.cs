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

        public Numero(double numero)
        {
            this.numero = numero;
        }


        private static double ValidarNumero(string strNumero)
        {
            double num = 0;
            if (EsNumero(strNumero) == true)
            {
                num = Convert.ToDouble(strNumero);
            }

            return num;
        }

        public static bool EsNumero(string strNumero)
        {
            double num;
            bool isNum = Double.TryParse(Convert.ToString(strNumero),
               System.Globalization.NumberStyles.Any,
               System.Globalization.NumberFormatInfo.InvariantInfo, out num);
            return isNum;
        }

        public string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }



        public string BinarioDecimal(string binario)
        {

            string retorno = "Valor invalido";
            if (EsNumero(binario))
            {
                for (int i = 1; i <= binario.Length; i++)
                {
                    retorno += int.Parse(binario[i - 1].ToString()) * (int)Math.Pow(2, binario.Length - i);
                }
            }

            return retorno;
        }



        public string DecimalBinario(double numero)
        {
            string bina = DecimalBinario(numero.ToString());
            return bina;
        }

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

        public static double operator -(Numero n1, Numero n2)
        {
            double rtn = n1.numero - n2.numero;
            return rtn;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double rtn;
            rtn = n1.numero + n2.numero;
            return rtn;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double rtn = n1.numero / n2.numero;
            return rtn;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double rtn = n1.numero * n2.numero;
            return rtn;
        }


    }
}
