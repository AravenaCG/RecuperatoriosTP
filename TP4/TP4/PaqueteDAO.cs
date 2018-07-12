using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {

        #region Atributos

       private static SqlCommand command;
       private static SqlConnection conexion;
        #endregion

      

        static PaqueteDAO()
        {
            
             PaqueteDAO.conexion = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True");
             PaqueteDAO.command = new SqlCommand(); 
             PaqueteDAO.command.CommandType = System.Data.CommandType.Text; 
             PaqueteDAO.command.Connection = PaqueteDAO.conexion;
            

        }

        public static bool Insertar(Paquete p)
        {
            string sql = String.Format("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) VALUES('{0}','{1}',{2});",
            p.DireccionEntrega, p.TrackingId, "Cristian Aravena");
            return EjecutNonQuery(sql);
        }


        static bool EjecutNonQuery(string sql) 
         { 
             bool bandera = false; 
             try 
             { 
                
                 PaqueteDAO.command.CommandText = sql;
                 PaqueteDAO.conexion.Open();
                 PaqueteDAO.command.ExecuteNonQuery(); 
                 bandera = true; 
             } 
             catch (Exception) 
             { 
                 bandera = false; 
             } 
             finally 
             {
                 if (bandera)
                 {
                     PaqueteDAO.conexion.Close();
                 }
             } 
             return bandera; 
         } 



    }
}
