using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Método que valida operadores aritmericos.
        /// </summary>
        /// <param name="operador">Cadena a validar</param>
        /// <returns>Cadena validada</returns>
        private static string ValidarOperador(string operador)
        {
            if (operador != "-" && operador != "/" && operador != "*")
                return "+";
            return operador;
        }

        /// <summary>
        /// Metodo que realiza operaciones aritmeticas.
        /// </summary>
        /// <param name="num1">Primer operando.</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Operador</param>
        /// <returns>Resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            switch (ValidarOperador(operador))
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
            }
            return resultado;
        }
    }
}
