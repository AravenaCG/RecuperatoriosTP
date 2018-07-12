using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// La clase Producto será abstracta, evitando que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        
        EMarca _marca;
        string _codigoDeBarras;
        ConsoleColor _colorPrimarioEmpaque;

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <param name="codigoDeBarras"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Producto(string codigoDeBarras, EMarca marca, ConsoleColor color)
        {
            this._marca = marca;
            this._codigoDeBarras = codigoDeBarras;
            this._colorPrimarioEmpaque = color;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del producto
        /// </summary>
        protected abstract short CantidadCalorias { get; }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <returns>True si son iguales, False si no lo son</returns>
        public override bool Equals(object obj)
        {
            return (this == (Producto)obj);
        }

        /// <summary>
        /// Obtiene el HashCode de la instancia.
        /// </summary>
        /// <returns>HashCode de la instancia</returns>
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Retorna todos los datos del producto recibido
        /// </summary>
        /// <param name="p">Producto del cual se retornan los datos</param>
        /// <returns>String con todos los datos del producto.</returns>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p._codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p._marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p._colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1">Producto a comparar</param>
        /// <param name="v2">Producto a comparar</param>
        /// <returns>True si son iguales, False si no lo son</returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras == v2._codigoDeBarras);
        }

        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1">Producto a comparar</param>
        /// <param name="v2">Producto a comparar</param>
        /// <returns>True si son distintos, False si no lo son</returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);
        }
        #endregion
    }
}
