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
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #region Constructor
        /// <summary>
        /// Constructor por defecto, inicializa la lista de paquetes y threads.
        /// </summary>
        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }
        #endregion


        #region Propiedades
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }
        #endregion


        #region Metodos
        /// <summary>
        /// Termina todos los threads en ejecucion
        /// </summary>
        /// <returns>void</returns>
        public void FinEntregas()
        {
            foreach (Thread aux in this.mockPaquetes)
            {
                if (aux.IsAlive)
                    aux.Abort();
            }          
        }

        /// <summary>
        /// Retorna la lista de paquetes del correo (incluidas sus herencias)
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns>string con lista de paquetes</returns>        
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            if (elementos is Correo)
            {
                foreach(Paquete aux in ((Correo)elementos).Paquetes)
                {
                    sb.AppendFormat("{0} para {1} ({2})", aux.TrackingID, aux.DireccionEntrega,
                    aux.Estado.ToString());
                    sb.AppendLine();
                } 
            }
            return sb.ToString();
        }
        #endregion


        #region Operadores
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns>Instancia de Correo</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete aux in c.Paquetes)
            {
                if (aux == p)
                    throw new TrackingIdRepetidoException("Paquete repetido");
            }
            c.Paquetes.Add(p);
            Thread hiloMock = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hiloMock);            
            hiloMock.Start();
            return c;
        }       
        #endregion

    }
}
