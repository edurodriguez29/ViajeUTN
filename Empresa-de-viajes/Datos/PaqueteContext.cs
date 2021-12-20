using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Datos
{
    public class PaqueteContext:Conexion
    {
        public bool PutPaquete(Paquete oPaquete)
        {
            //Inserto Paquete
            string strqry;
            int Contador = 0;
            SqlCommand cmd;
            strqry = "INSERT INTO[dbo].[PAQUETE] ([NOMBRE],[PRECIO],[FECHA_INICIO],[FECHA_FIN],[ESNACIONAL],[COTIZACIONDOL],[REQUIEREVISA],[IMPUESTONAC],[IMPUESTOINT],[CANTCUOTAS],[MONTOCUOTA],[ACTIVO],[CANTDIAS]) " +
                " VALUES (@NOMBRE,@PRECIO,@FECHA_INICIO, @FECHA_FIN, @ESNACIONAL, @COTIZACIONDOL, @REQUIEREVISA, @IMPUESTONAC, @IMPUESTOINT, " +
                " @CANTCUOTAS, @MONTOCUOTA, @ACTIVO, @CANTDIAS);select SCOPE_IDENTITY();";
            try
            {
                cmd = new SqlCommand(strqry, base.GetConexion);
                cmd.Parameters.Add("@NOMBRE", System.Data.SqlDbType.VarChar, 50).Value = oPaquete.Nombre;
                cmd.Parameters.Add("@PRECIO", System.Data.SqlDbType.Decimal).Value = oPaquete.Precio;
                cmd.Parameters.Add("@FECHA_INICIO", System.Data.SqlDbType.Date).Value = oPaquete.Fecha_Inicio;
                cmd.Parameters.Add("@FECHA_FIN", System.Data.SqlDbType.Date).Value = oPaquete.Fecha_Fin;
                cmd.Parameters.Add("@ESNACIONAL", System.Data.SqlDbType.Bit).Value = oPaquete.EsNacional;
                cmd.Parameters.Add("@COTIZACIONDOL", System.Data.SqlDbType.Decimal).Value = oPaquete.CotizacionDol;
                cmd.Parameters.Add("@REQUIEREVISA", System.Data.SqlDbType.Bit).Value = oPaquete.RequiereVisa;
                cmd.Parameters.Add("@IMPUESTONAC", System.Data.SqlDbType.Decimal).Value = oPaquete.ImpuestoNacional;
                cmd.Parameters.Add("@IMPUESTOINT", System.Data.SqlDbType.Decimal).Value = oPaquete.ImpuestoInt;
                cmd.Parameters.Add("@CANTCUOTAS", System.Data.SqlDbType.Int).Value = oPaquete.CantCuotas;
                cmd.Parameters.Add("@MONTOCUOTA", System.Data.SqlDbType.Decimal).Value = oPaquete.MontoCuota;
                cmd.Parameters.Add("@ACTIVO", System.Data.SqlDbType.Bit).Value = oPaquete.Activo;
                cmd.Parameters.Add("@CANTDIAS", System.Data.SqlDbType.Int).Value = oPaquete.CantDias;
                oPaquete.Id = Convert.ToInt32(cmd.ExecuteScalar());

                //Insert Destinos
                foreach (var item in oPaquete.Lugares)
                {
                    Contador++;
                    strqry = "INSERT INTO[dbo].[LUGARES] ([ID_PAQUETE],[CONT],[NOMBRE])" +
                    " VALUES (@ID_PAQUETE,@CONT,@NOMBRE);";

                    cmd = new SqlCommand(strqry, base.GetConexion);
                    cmd.Parameters.Add("@ID_PAQUETE", System.Data.SqlDbType.Int).Value = oPaquete.Id;
                    cmd.Parameters.Add("@CONT", System.Data.SqlDbType.Int).Value = Contador;
                    cmd.Parameters.Add("@NOMBRE", System.Data.SqlDbType.VarChar, 50).Value = item.Nombre;
                    cmd.ExecuteScalar();
                }
                return true;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error en la insercion del Paquete: " + Ex.Message);
                Console.WriteLine("Error en la insercion del Paquete: " + Ex.InnerException);
                return false;
            }
        }


        /// <summary>
        /// Obtiene el Listado de Paquetes en base al Nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>Lista de Paquetes</returns>
        public List<Dominio.Paquete> GetPaquetes(string nombre)
        {

            string par1 = "'%" + nombre + "%'";
            string strqry = "Select ID,Nombre,Precio,Fecha_Inicio,Fecha_Fin,EsNacional,CotizacionDol RequiereVisa,ImpuestoNac,ImpuestoInt,CantCuotas,MontoCuota,Activo,CantDias From Paquete Where Nombre like " + par1;

            try
            {
                //Hago query, transformo DataSet a DataTable y a List para manejar standar de C#
                SqlDataAdapter DA = new SqlDataAdapter(strqry, base.GetConexion);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                DataTable DT = DS.Tables[0];
                List<Dominio.Paquete> ListaPaquetes = DT.DataTableToList<Dominio.Paquete>();
                return ListaPaquetes;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error en la insercion del Paquete: " + Ex.Message);
                Console.WriteLine("Error en la insercion del Paquete: " + Ex.InnerException);
                return new List<Paquete>();
            }
        }


        public int SetPaquete(Paquete paq)
        {
            string strqry;
            SqlCommand cmd;
            strqry = "Update [dbo].[PAQUETE] SET  (@NOMBRE,@PRECIO,@FECHA_INICIO, @FECHA_FIN, @ESNACIONAL, @COTIZACIONDOL, @REQUIEREVISA, @IMPUESTONAC, @IMPUESTOINT, " +
                " @CANTCUOTAS, @MONTOCUOTA, @ACTIVO, @CANTDIAS) WHERE ID = @ID;";

           
            try
            {
                cmd = new SqlCommand(strqry, base.GetConexion);
                cmd.Parameters.Add("@NOMBRE", System.Data.SqlDbType.VarChar, 50).Value = paq.Nombre;
                cmd.Parameters.Add("@PRECIO", System.Data.SqlDbType.Decimal).Value = paq.Precio;
                cmd.Parameters.Add("@FECHA_INICIO", System.Data.SqlDbType.Date).Value = paq.Fecha_Inicio;
                cmd.Parameters.Add("@FECHA_FIN", System.Data.SqlDbType.Date).Value = paq.Fecha_Fin;
                cmd.Parameters.Add("@ESNACIONAL", System.Data.SqlDbType.Bit).Value = paq.EsNacional;
                cmd.Parameters.Add("@COTIZACIONDOL", System.Data.SqlDbType.Decimal).Value = paq.CotizacionDol;
                cmd.Parameters.Add("@REQUIEREVISA", System.Data.SqlDbType.Bit).Value = paq.RequiereVisa;
                cmd.Parameters.Add("@IMPUESTONAC", System.Data.SqlDbType.Decimal).Value = paq.ImpuestoNacional;
                cmd.Parameters.Add("@IMPUESTOINT", System.Data.SqlDbType.Decimal).Value = paq.ImpuestoInt;
                cmd.Parameters.Add("@CANTCUOTAS", System.Data.SqlDbType.Int).Value = paq.CantCuotas;
                cmd.Parameters.Add("@MONTOCUOTA", System.Data.SqlDbType.Decimal).Value = paq.MontoCuota;
                cmd.Parameters.Add("@ACTIVO", System.Data.SqlDbType.Bit).Value = paq.Activo;
                cmd.Parameters.Add("@CANTDIAS", System.Data.SqlDbType.Int).Value = paq.CantDias;
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
