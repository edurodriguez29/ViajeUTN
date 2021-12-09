using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empresa
    {
            
        private int id=0;
        private string nombre="";
        private string telefono="";
        private string webpage="";
        private string codEmpresa = "";
        
        [Key]
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Webpage { get => webpage; set => webpage = value; }
        public string CodEmpresa { get => codEmpresa; set => codEmpresa = value; }

        /* Ejemplo de Clave Compuesta-->[Key, Column(Order=0)] */
    }
}
