using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
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
        public int PutClienteCorp(Corporativo cli)
        {
            string strqry = "INSERT INTO [dbo].[CLIENTE] ([DNI],[NACIONALIDAD],[PROVINCIA],[FNACIMIENTO],[APELLIDO],[DIRECCION],[NOMBRE],[ESPARTICULAR],[TELEFONO],[LOCALIDAD],[CUIT],[RAZON_SOCIAL]) ";
            strqry += " Values(@DNI,@NACIONALIDAD,@PROVINCIA,@FNACIMIENTO,@APELLIDO,@DIRECCION,@NOMBRE,@ESPARTICULAR,@TELEFONO,@LOCALIDAD,@CUIT,@RAZON_SOCIAL);select SCOPE_IDENTITY()";
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
                cmd.Parameters.Add("@ESPARTICULAR", System.Data.SqlDbType.Bit).Value = false;
                cmd.Parameters.Add("@TELEFONO", System.Data.SqlDbType.VarChar, 50).Value = cli.Telefono;
                cmd.Parameters.Add("@LOCALIDAD", System.Data.SqlDbType.VarChar, 50).Value = cli.Localidad;
                cmd.Parameters.Add("@CUIT", System.Data.SqlDbType.VarChar, 20).Value = cli.Cuit;
                cmd.Parameters.Add("@RAZON_SOCIAL", System.Data.SqlDbType.VarChar, 50).Value = cli.RazonSocial;
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error en la insercion del Cliente Corporativo: " + Ex.Message);
                Console.WriteLine("Error en la insercion del Cliente Corporativo: " + Ex.InnerException);
                return 0;
            }
        }
        /// <summary>
        /// Obtiene el Listadeo de Clientes en base al Apellido
        /// </summary>
        /// <param name="apellido"></param>
        /// <returns>Lista de Clientes</returns>
        public List<Dominio.Cliente> GetClientes(string apellido)
        {

            string par1 = "'%" + apellido + "%'";
            string strqry = "Select ID,DNI,Nacionalidad,Provincia,Fnacimiento as Fnac,Apellido,Direccion,Nombre,EsParticular,Telefono,Localidad From Cliente Where Cliente.ESPARTICULAR=1 and Apellido like " + par1;

            try
            {
                //Hago query, transformo DataSet a DataTable y a List para manejar standar de C#
                SqlDataAdapter DA = new SqlDataAdapter(strqry, base.GetConexion);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                DataTable DT = DS.Tables[0];
                List<Dominio.Cliente> ListaClientes = DT.DataTableToList<Dominio.Cliente>();
                return ListaClientes;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error en la insercion del Cliente: " + Ex.Message);
                Console.WriteLine("Error en la insercion del Cliente: " + Ex.InnerException);
                return new List<Cliente>();
            }
        }

        /// <summary>
        /// Lista las EMpresas
        /// </summary>
        /// <param name="RazonSocial"></param>
        /// <returns></returns>
        public List<Dominio.Corporativo> GetClientesCorporativos(string RazonSocial)
        {

            string par1 = "'%" + RazonSocial + "%'";
            string strqry = "Select ID,DNI,Nacionalidad,Provincia,Fnacimiento as Fnac,Apellido,Direccion,Nombre,EsParticular,Telefono,Localidad " +
                ",EsCorporativo=1,CUIT,Razon_social as razonSocial " +            
                "From Cliente Where Cliente.ESPARTICULAR=0 and Razon_social like " + par1;

            try
            {
                //Hago query, transformo DataSet a DataTable y a List para manejar standar de C#
                SqlDataAdapter DA = new SqlDataAdapter(strqry, base.GetConexion);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                DataTable DT = DS.Tables[0];
                List<Dominio.Corporativo> ListaClientes = DT.DataTableToList<Dominio.Corporativo>();
                return ListaClientes;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error en la insercion del Cliente: " + Ex.Message);
                Console.WriteLine("Error en la insercion del Cliente: " + Ex.InnerException);
                return new List<Corporativo>();
            }
        }
    }
}
