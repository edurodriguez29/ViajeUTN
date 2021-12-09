using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaDeViajes
{
    public class Cliente
    {
        private int id;
        private bool esParticular = true;
        private string nombre;
        private string apellido;
        private byte edad;
        private string dni;
        private string nacionalidad;
        private string localidad;
        private string direccion;
        private string telefono;

        public Cliente(int id, bool esParticular, string nombre, string apellido, byte edad,
            string dni, string nacionalidad, string localidad, string direccion, string telefono)
        {
            this.id = id;
            this.esParticular = esParticular;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.dni = dni;
            this.nacionalidad = nacionalidad;
            this.localidad = localidad;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public int Id { get; set; }
        public bool EsParticular { get => esParticular; set => esParticular = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public byte Edad { get => edad; set => edad = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public string Localidad { get => localidad; set => localidad = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        
    }

    public class Corporativo : Cliente
    {
        private string cuit;
        private string razonSocial;
        private bool esCorporativo = true;

        public Corporativo(int id, bool esParticular, string nombre, string apellido, byte edad, string dni, string nacionalidad, string localidad, string direccion, string telefono, string cuit, string razonSocial, bool esCorporativo)
            : base(id, esParticular, nombre, apellido, edad, dni, nacionalidad, localidad, direccion, telefono)
        {
            this.cuit = cuit;
            this.razonSocial = razonSocial;
        }

        public string Cuit { get => cuit; set => cuit = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public bool EsCorporativo { get => esCorporativo;}
    }
}
