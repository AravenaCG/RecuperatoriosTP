using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Entidades
{
     public class Correo : IMostrar<List<Paquete>>
     {


             #region Atributos
             private List<Paquete> paquetes;
             private List<Thread> mockPaquetes;
             #endregion


             #region Propiedades

             public List<Paquete> Paquetes
             { 
                 get
                 {
                     return this.paquetes;
                 }
                 set
                 {
                     this.paquetes = value; 
                 }
             }

             #endregion

             #region Constructores

             public Correo()
             {
             mockPaquetes = new List<Thread>();
             paquetes = new List<Paquete>();
             }

             #endregion


             #region Metodos



         public void FinEntregas()

         {
             foreach (Thread hilo in this.mockPaquetes)
             {


                 if (hilo.IsAlive)
                    hilo.Abort();
             }

         }

         public string MostrarDatos(IMostrar<List<Paquete>>elementos)
         {
             StringBuilder stb = new StringBuilder();

             foreach (Paquete paq in ((Correo)elementos).Paquetes)
             {
                 stb.AppendFormat("{0} para {1} ({2})", paq.TrackingId, paq.DireccionEntrega,paq.Estado.ToString());
             }
             return stb.ToString();
         }
             #endregion


             #region Sobrecargas

         public static Correo operator +(Correo c, Paquete p)
         {

            foreach (Paquete paq in c.Paquetes)
            {
                if (paq == p)
                    throw new TranckingIdRepetidoException("Paquete repetido");
            }
            c.Paquetes.Add(p);
            Thread hMock = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hMock);
            hMock.Start();
            return c;

         }

        
}
        #endregion





}


    

