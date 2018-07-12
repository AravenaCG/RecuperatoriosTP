using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TranckingIdRepetidoException:Exception
    {

         public TranckingIdRepetidoException(string mensaje, Exception innerException)
             : base(mensaje,innerException) 
         { 

         }


         public TranckingIdRepetidoException(string mensaje)
             : this(mensaje, null) 
         { 

         } 


    }
}
