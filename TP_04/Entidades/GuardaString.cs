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
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(archivo, true))
                {
                    file.WriteLine(texto);
                    file.Close();
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
