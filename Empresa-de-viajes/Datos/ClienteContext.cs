using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ClienteContext:Conexion
    {
        //Conexion cn = new Conexion();
        /// <summary>
        /// Graba un Cliente en la Base de Datos
        /// </summary>
        /// <param name="cli"></param>
        /// <returns></returns>
        public int PutCliente(Cliente cli) {

            string strqry = "INSERT INTO [dbo].[CLIENTE] ([DNI],[NACIONALIDAD],[PROVINCIA],[FNACIMIENTO],[APELLIDO],[DIRECCION],[NOMBRE],[ESPARTICULAR],[TELEFONO],[LOCALIDAD]) "; //,[CUIT],[RAZON_SOCIAL]
            strqry += " Values(@DNI,@NACIONALIDAD,@PROVINCIA,@FNACIMIENTO,@APELLIDO,@DIRECCION,@NOMBRE,@ESPARTICULAR,@TELEFONO,@LOCALIDAD);select SCOPE_IDENTITY();"; //,@CUIT,@RAZON_SOCIAL
            try
            {
                SqlCommand cmd = new SqlCommand(strqry, base.GetConexion);
                cmd.Parameters.Add("@DNI", System.Data.SqlDbType.Int).Value = cli.Dni;
                cmd.Parameters.Add("@NACIONALIDAD", System.Data.SqlDbType.VarChar, 50).Value = cli.Nacionalidad;
                cmd.Parameters.Add("@PROVINCIA", System.Data.SqlDbType.VarChar, 50).Value = cli.Provincia;
                cmd.Parameters.Add("@FNACIMIENTO", System.Data.SqlDbType.Date).Value = cli.Fnac;
                cmd.Parameters.Add("@APELLIDO", System.Data.SqlDbType.VarChar, 50).Value = cli.Apellido;
                cmd.Parameters.Add("@DIRECCION", System.Data.SqlDbType.VarChar, 50).Value = cli.Direccion;
                cmd.Parameters.Add("@NOMBRE", System.Data.SqlDbType.VarChar, 50).Value = cli.Nombre;
                cmd.Parameters.Add("@ESPARTICULAR", System.Data.SqlDbType.Bit).Value = cli.EsParticular;
                cmd.Parameters.Add("@TELEFONO", System.Data.SqlDbType.VarChar, 50).Value = cli.Telefono;
                cmd.Parameters.Add("@LOCALIDAD", System.Data.SqlDbType.VarChar, 50).Value = cli.Localidad;
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error en la insercion del Cliente: " + Ex.Message);
                Console.WriteLine("Error en la insercion del Cliente: " + Ex.InnerException);
                return 0;
            }
        }
    }
}
