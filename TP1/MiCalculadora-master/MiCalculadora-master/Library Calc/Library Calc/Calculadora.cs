using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Entidades
{
    class Calculadora
    {
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
