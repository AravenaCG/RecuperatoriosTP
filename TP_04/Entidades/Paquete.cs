using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        // Delegado del evento
        public delegate void DelegadoEstado(object sender, EventArgs e);
        // Evento del tipo del delegado
        public event DelegadoEstado InformaEstado;

        /// <summary>
        /// Enumerado con estados de paquete.
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        #region Atributos
        private string direccionEntrega;
        EEstado estado;
        private string trackingID;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto, inicializa la lista de productos.
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;
        }
        #endregion
       
        #region Propiedades
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Retorna la informacion del paquete recibido
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>string con info del paquete</returns>  
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
        }

        /// <summary>
        /// Simula trayectoria de paquete e inserta el mismo en base de datos
        /// </summary>
        /// <returns>void</returns>  
        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(10000);
                Estado = (Estado == EEstado.Ingresado) ? EEstado.EnViaje : EEstado.Entregado;
                InformaEstado(this,new EventArgs());

            } while (Estado != EEstado.Entregado);
            PaqueteDAO.Insertar(this);
        }
        #endregion

        #region Operators & Override
        /// <summary>
        /// Override del metodo ToString
        /// </summary>
        /// <returns>Info de paquete</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>true si ambos paquetes son iguales, false si no lo son</returns>  
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
                return false;
            return (p1.TrackingID == p2.TrackingID);
        }

        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>false si ambos paquetes son iguales, true si no lo son</returns>  
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Override del metodo Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true si ambos paquetes son iguales, false si no lo son</returns>  
        public override bool Equals(object obj)
        {
            if (!(obj is Paquete))
                return false;
            return this == (Paquete)obj;
        }

        /// <summary>
        /// Override del metodo GetHashCode
        /// </summary>
        /// <returns>HashCode</returns>  
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        #endregion

    }
}
