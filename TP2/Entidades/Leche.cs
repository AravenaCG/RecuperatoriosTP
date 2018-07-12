using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Drawing;

namespace Entidades
{
    public class Leche : Producto
    {
        #region Atributos
        public enum ETipo { Entera, Descremada }
        private ETipo _tipo;
        #endregion
        #region Constructores
        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        /// 
        public Leche(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
            _tipo = ETipo.Entera;
        }

        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo)
            : base(patente, marca, color)
        {

            _tipo = tipo;

        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        #endregion

        #region Metodos


        public override  string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());

            sb.AppendLine("CALORIAS :" + this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this._tipo);
            sb.AppendLine("---------------------");



            return sb.ToString();
        }

        #endregion
    }
}