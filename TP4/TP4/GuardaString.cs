using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {
         public static bool Guardar(this String texto, string archivo) 
         { 
             try 
             { 
                 using (System.IO.StreamWriter auxWriter = new System.IO.StreamWriter(archivo, true)) 
                 {
                     auxWriter.WriteLine(texto);
                     auxWriter.Close(); 
                 } 
                 return true; 
             } 
             catch (Exception e) 
             { 
                 Console.WriteLine(e.Message); 
                 return false; 
             } 
         } 

        

    }
}
