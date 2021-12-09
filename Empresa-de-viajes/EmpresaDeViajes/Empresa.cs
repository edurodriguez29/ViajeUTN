using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaDeViajes
{
    internal class OLD_Empresa
    {
        private string nombreEmpresa;
        private string direccion;
        private string correo;
        private string tel;
        private string sitioWeb;

        public OLD_Empresa(string nombreEmpresa, string direccion, string correo, string tel, string otroTel, string sitioWeb)
        {
            this.nombreEmpresa = nombreEmpresa;
            this.direccion = direccion;
            this.correo = correo;
            this.tel = tel;

            this.sitioWeb = sitioWeb;
        }

        public string NombreEmpresa { get => nombreEmpresa; set => nombreEmpresa = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Tel { get => tel; set => tel = value; }
        public string SitioWeb { get => sitioWeb; set => sitioWeb = value; }
    }
}
