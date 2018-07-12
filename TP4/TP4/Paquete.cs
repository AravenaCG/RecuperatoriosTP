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

        
            #region Atributos
             private string direccionEntrega;
             private EEstado estado;
             private string trackingID;

            #endregion

            public delegate void DelegadoDeEstado(object sender, EventArgs e);
            public event DelegadoDeEstado Event1;


            #region Propiedades
            
            
            public string DireccionEntrega
            { 
                get
                {
                    return this.direccionEntrega;
        
                }
                set
                {
                    this.direccionEntrega = value;
                }
            }
            public EEstado Estado
            { 
                get
                {
                    return this.estado;
                }
                set
                {
                    this.estado=value;
                }
            }
            public string TrackingId  
            { 
                get
                {
                    return this.trackingID;
                }
                set
                {
                    this.trackingID = value;
                }
                
            }

            #endregion
            #region Constructores
            
            public Paquete(string direccionEntrega, string trackingId)
            {
                this.estado=EEstado.Ingresado;
               // this.Event1 += InformaEstado;
                this.direccionEntrega = direccionEntrega;
                this.trackingID = trackingId;
            }

            #endregion


            #region Metodos

            public  string MostrarDatos(IMostrar<Paquete> elemento)
            {
            return String.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
            }
        
            public void MockCicloDeVida()
            {
                 do 
             { 
                 Thread.Sleep(10000); 
                 Estado = (Estado == EEstado.Ingresado) ? EEstado.EnViaje : EEstado.Entregado; 
                 Event1(this, new EventArgs()); 
 
 
             } while (Estado != EEstado.Entregado); 

            }
           
            public void InformaEstado()
            {


            }
            #endregion
         
        #region Sobrecargas
            
            public  override string ToString()
            {
               return this.MostrarDatos(this);
        
            }


       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null)) 
            return false; 

            return (p1.trackingID == p2.trackingID); 

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1,Paquete p2)
        {
             return !(p1 == p2);
        }
     

        public override bool Equals(object obj) 
         {
            if (!(obj is Paquete))
                return false;
            return this == (Paquete)obj;
        } 


        public override int GetHashCode() 
         {
            return this.ToString().GetHashCode();
        } 

            #endregion

            #region NestedTypes

            public  enum EEstado { Ingresado, EnViaje, Entregado }
            #endregion
    }



}





