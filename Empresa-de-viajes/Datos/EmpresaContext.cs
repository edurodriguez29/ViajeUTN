using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EmpresaContext
    {
        Conexion cn = new Conexion();
    
        public Dominio.Empresa GetEmpresa()
        {
            Empresa Emp = new Empresa();
            string sql = "Select top 1 * from Empresa;";
           SqlCommand cmd = new SqlCommand(sql, cn.GetConexion);
            using (SqlDataReader reader=cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Emp.Id = Convert.ToInt32(reader["ID"]);
                    Emp.CodEmpresa=reader["COD_EMPRESA"].ToString();
                    Emp.Nombre = reader["Nombre"].ToString();
                    Emp.Webpage = reader["webpage"].ToString();
                    Emp.Telefono = reader["telefono"].ToString();
                }
            }
            return Emp;
        }
    }
}
