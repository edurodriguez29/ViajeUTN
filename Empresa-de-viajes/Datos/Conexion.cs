using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    internal class Conexion
    {
        /// <summary>
        /// Conexion a la Base de Datos
        /// </summary>
        private SqlConnection cn;
        /// <summary>
        /// Creo un nueva conexion a la BD
        /// </summary>
        public Conexion()
        {
            string server = @"LAPTOP-PC0K8BMI\SQLEXPRESS";
            string baseDatos = "TrabajoIntegrador";
            string IntegratedSecurity = "true";
            string persistSecurityInfo = "true";
            string timeOut = "2";


            string strconeccion = "server=" + server + ";Initial Catalog=" + baseDatos + ";Persist Security Info=" 
                + persistSecurityInfo + ";Integrated Security=" + IntegratedSecurity + ";database=" + baseDatos + ";Connection Timeout =" + timeOut;
            
            try
            {
                cn=new SqlConnection(strconeccion);
               cn.Open();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(DateTime.Today.ToLongDateString() + "- Error al intentar abrir una conexion con la BD:" + Ex.Message);
                Console.WriteLine(DateTime.Today.ToLongDateString() + "- "+ Ex.InnerException);
            }
        }

        public SqlConnection GetConexion { get => cn;}

        public System.Data.DataSet GetDataSet(SqlConnection conn, string SQL)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = SQL;
            da.SelectCommand = cmd;
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
