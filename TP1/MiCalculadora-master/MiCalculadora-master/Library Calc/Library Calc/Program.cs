using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Program
    {
        static void Main(string[] args)
        {
            string numeroUno;
            string numeroDos;
            Calculadora calcu = new Calculadora();
            Numero num1 = new Numero();
            Numero num2 = new Numero();
            Console.WriteLine("ingrese el maldito numero");
            numeroUno = Console.ReadLine();
            num1.SetNumero = numeroUno;
            Console.WriteLine("ingrese el maldito numero dos");
            numeroDos = Console.ReadLine();
            num2.SetNumero = numeroDos;

            //num2 = 20;
            string operador1;
            Console.WriteLine("Ingrese un operador");
            operador1 = Console.ReadLine();
            double result = 0;
            result = calcu.Operar(num1, num2, operador1);
            Console.WriteLine(result);
            Console.ReadLine();


        }
    }
}
