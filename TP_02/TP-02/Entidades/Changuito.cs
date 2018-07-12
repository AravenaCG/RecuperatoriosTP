using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        List<Producto> _productos;
        int _espacioDisponible;
        
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto, inicializa la lista de productos.
        /// </summary>
        private Changuito()
        {
            this._productos = new List<Producto>();
        }

        /// <summary>
        /// Sobrecarga del Constructor, establece espacio disponible.
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Changuito(int espacioDisponible) : this()
        {
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro la concecionaria y TODOS los Productos
        /// </summary>
        /// <returns>Metodo Mostrar con tipo Todos</returns>
        public override string ToString()
        {
            return this.Mostrar(ETipo.Todos);
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public string Mostrar(ETipo tipo) //quitar static
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", this._productos.Count, this._espacioDisponible);
            sb.AppendLine("");

            foreach (Producto v in this._productos)
            {
                if (tipo == ETipo.Todos)
                    sb.AppendLine(v.Mostrar());
                else if (v.GetType().Name.ToString() == tipo.ToString())
                    sb.AppendLine(v.Mostrar());
            }       

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="changuito">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns>Instancia de Changuito</returns>
        public static Changuito operator +(Changuito changuito, Producto p)
        {
            if (changuito._espacioDisponible > changuito._productos.Count())
            {
                foreach (Producto v in changuito._productos)
                {
                    if (v == p)
                        return changuito;
                }
                changuito._productos.Add(p);
            }

            return changuito;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="changuito">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns>Instancia de Changuito</returns>
        public static Changuito operator -(Changuito changuito, Producto p)
        {
            foreach (Producto v in changuito._productos)
            {
                if (v == p)
                {
                    changuito._productos.Remove(p);
                    break;
                }
            }
            return changuito;
        }
        #endregion
    }
}
