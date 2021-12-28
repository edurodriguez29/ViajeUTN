using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{


    public class FacturaContext:Conexion
    {
        /// <summary>
        /// Retorna facturas de Clientes en base a un nombre
        /// </summary>
        /// <param name="apellido"></param>
        /// <returns></returns>
        public DataTable GetFacturas(string apellido) {

            string par1 = "'%" + apellido + "%'";


            string strqry = "Select "+
                            "factura.IDFACTURA " +
                            ",factura.IDCLIENTE " +
                            ",factura.FECHA " +
                            ",factura.TOTAL " +
                            ",cliente.DNI " +
                            ",CLIENTE.APELLIDO " +
                            ",CLIENTE.NOMBRE " +
                            ",CLIENTE.ESPARTICULAR " +
                            ",PAQUETE.id as IDpaquete " +
                            ",PAQUETE.NOMBRE as paqueteNombre " +
                            ",FACTDETALLE.CANTPAQUETES " +
                            ",FACTDETALLE.CANTCUOTAS " +
                            ",FACTDETALLE.SUBTOTAL " +
                            " From factura inner join CLIENTE on factura.IDCLIENTE = CLIENTE.ID " +
                             "left join FACTDETALLE on FACTURA.IDFACTURA = FACTDETALLE.idfactura " +
                             "left join PAQUETE On FACTDETALLE.IDPAQUETE = PAQUETE.ID "+
                             " where cliente.apellido like " + par1;
            try
            {
                //Hago query, transformo DataSet a DataTable y a List para manejar standar de C#
                SqlDataAdapter DA = new SqlDataAdapter(strqry, base.GetConexion);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                DataTable DT = DS.Tables[0];

                return DT;

                //DataRow row;
                //for (int i = 0; i < DT.Rows.Count; i++)
                //{
                //    row = DT.Rows[i];
                //    Console.WriteLine($"IDFACTURA:{row["IDFACTURA"]}");
                //    Console.WriteLine($"IDCLIENTE:{row["IDCLIENTE"]}");
                //    Console.WriteLine($"Fecha:{row["Fecha"]}");
                // }


                /////Obtengo la lista de Facturas
                //List<Dominio.Factura> ListaFacturas = DT.DataTableToList<Dominio.Factura>();

            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error en la insercion del Cliente: " + Ex.Message);
                Console.WriteLine("Error en la insercion del Cliente: " + Ex.InnerException);
                return new DataTable();
            }




        }


        /// <summary>
        /// Inserta una factura con todos sus detalles
        /// </summary>
        /// <param factura="una factura completa"></param>
        /// <returns></returns>
        public bool PutFactura(Dominio.Factura factura)
        {

            double Monto = 0;
            foreach (var item in factura.LFacturaDet)
            {
                Monto += item.Subtotal;
            }
            factura.Total = Monto;
            string strqry = "INSERT INTO[dbo].[FACTURA] ([IDCLIENTE],[FECHA],[TOTAL]) VALUES (" +
            "@IDCLIENTE,@FECHA,@TOTAL);select SCOPE_IDENTITY();";
            try
            {
                SqlCommand cmd = new SqlCommand(strqry, base.GetConexion);
                cmd.Parameters.Add("@IDCLIENTE", System.Data.SqlDbType.Int).Value = factura.OCliente.Id;
                cmd.Parameters.Add("@FECHA", System.Data.SqlDbType.Date).Value = factura.Fecha;
                cmd.Parameters.Add("@TOTAL", System.Data.SqlDbType.Decimal).Value = factura.Total;
                factura.IDFactura = Convert.ToInt32(cmd.ExecuteScalar());
                int itemContador = 0;
                foreach (var item in factura.LFacturaDet)
                {
                    strqry = "INSERT INTO[dbo].[FACTDETALLE] ([IDFACTURA],[ITEM] ,[IDPAQUETE] ,[CANTPAQUETES] " +
                        ",[CANTCUOTAS] ,[MONTOCUOTAS] ,[IMPUESTONAC] ,[IMPUESTOINT] ,[SUBTOTAL]) " +
                        " VALUES (@IDFACTURA,@ITEM,@IDPAQUETE,@CANTPAQUETES,@CANTCUOTAS,@MONTOCUOTAS"+
                        ",@IMPUESTONAC,@IMPUESTOINT,@SUBTOTAL);";
                    cmd = new SqlCommand(strqry, base.GetConexion);
                    cmd.Parameters.Add("@IDFACTURA", System.Data.SqlDbType.Int).Value = factura.IDFactura;
                    cmd.Parameters.Add("@ITEM", System.Data.SqlDbType.Int).Value = itemContador++;
                    cmd.Parameters.Add("@IDPAQUETE", System.Data.SqlDbType.Int).Value = item.paquete.Id;
                    cmd.Parameters.Add("@CANTPAQUETES", System.Data.SqlDbType.Int).Value = item.CantPaquetes;
                    cmd.Parameters.Add("@CANTCUOTAS", System.Data.SqlDbType.Int).Value = item.CantCuotas;
                    cmd.Parameters.Add("@MONTOCUOTAS", System.Data.SqlDbType.Int).Value = item.Subtotal/item.CantCuotas;
                    cmd.Parameters.Add("@IMPUESTONAC", System.Data.SqlDbType.Int).Value = item.paquete.EsNacional ? item.ImpuestosNac : 0;
                    cmd.Parameters.Add("@IMPUESTOINT", System.Data.SqlDbType.Int).Value = !item.paquete.EsNacional ? item.InpuestosInt : 0;
                    cmd.Parameters.Add("@SUBTOTAL", System.Data.SqlDbType.Int).Value = item.Subtotal;
                    cmd.ExecuteScalar();
                }
                return true;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error en la insercion del Cliente: " + Ex.Message);
                Console.WriteLine("Error en la insercion del Cliente: " + Ex.InnerException);
                return false;
            }
        }

    }
}
