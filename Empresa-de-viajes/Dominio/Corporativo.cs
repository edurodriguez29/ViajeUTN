using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Corporativo : Cliente
    {

        private string cuit;
        private string razonSocial;
        private bool esCorporativo = true;

        public Corporativo()
        {
        }

        public Corporativo(bool esParticular, string nombre, string apellido, DateTime Fnac,
                    string dni, string nacionalidad, string localidad, string direccion,
                    string telefono, string cuit, string razonSocial, bool esCorporativo, string Provincia)
                    : base(esParticular, nombre, apellido, Fnac, dni, nacionalidad, localidad, direccion, telefono, Provincia)
        {
            this.cuit = cuit;
            this.razonSocial = razonSocial;
        }

        public string Cuit { get => cuit; set => cuit = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public bool EsCorporativo { get => esCorporativo; set => esCorporativo = value; }
    }
}
