using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Calculadora
    {
        /// <summary>
        /// Valida que el ingresado sea un operador recibido sea un simbolo "+" o "-" o "*" o "/"
        /// </summary>
        /// <param name="operat"></param>
        /// <returns>rtn, un operador valido o un "+"</returns>
        private static string ValidarOperador(string operat)
        {
            string rtn;

            if (operat == "+" || (operat == "-") || (operat == "/") || (operat == "*"))
            {
                rtn = operat;
            }
            else
            {

                rtn = "+";

            }


            return rtn;

        }

        /// <summary>
        /// Realiza las operaciones seleccionadas segun el caso
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>rtn es el resultado de la operacion</returns>
        public double Operar(Numero num1, Numero num2, string operador)
        {
            double rtn = 0;
            operador = ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    rtn = num1 + num2;
                    break;
                case "-":
                    rtn = num1 - num2;
                    break;
                case "/":
                    rtn = num1 / num2;
                    break;
                case "*":
                    rtn = num1 * num2;
                    break;
            }
            return rtn;


        }




    }
}
