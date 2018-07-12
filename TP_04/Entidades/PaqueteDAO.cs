using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        private static SqlConnection _conexion;
        private static SqlCommand _comando;
        #endregion


        #region Constructores
        static PaqueteDAO()
        {
            // CREO UN OBJETO SQLCONECTION
            PaqueteDAO._conexion = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True"); //Properties.Settings.Default.conexion
            // CREO UN OBJETO SQLCOMMAND"
            PaqueteDAO._comando = new SqlCommand();
            // INDICO EL TIPO DE COMANDO
            PaqueteDAO._comando.CommandType = System.Data.CommandType.Text;
            // ESTABLEZCO LA CONEXION
            PaqueteDAO._comando.Connection = PaqueteDAO._conexion;
        }
        #endregion


        #region Métodos

        #region Insertar Paquete
        public static bool Insertar(Paquete p)
        {
            string sql = String.Format("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) VALUES('{0}','{1}','{2}');",
                p.DireccionEntrega, p.TrackingID, "Ariel Traut");

            return EjecutarNonQuery(sql);
        }
        #endregion

        
        private static bool EjecutarNonQuery(string sql)
        {
            bool todoOk = false;
            try
            {
                // LE PASO LA INSTRUCCION SQL
                PaqueteDAO._comando.CommandText = sql;

                // ABRO LA CONEXION A LA BD
                PaqueteDAO._conexion.Open();

                // EJECUTO EL COMMAND
                PaqueteDAO._comando.ExecuteNonQuery();

                todoOk = true;
            }
            catch (Exception e)
            {
                todoOk = false;
            }
            finally
            {
                if (todoOk)
                    PaqueteDAO._conexion.Close();
            }
            return todoOk;
        }
        #endregion
    }
}