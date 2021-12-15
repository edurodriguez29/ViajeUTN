using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Lugares
    {
        private int id_paquete = 0;
        private int cont = 0;
        private string nombre = "";

        public int Id_paquete { get => id_paquete; set => id_paquete = value; }
        public int Cont { get => cont; set => cont = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Lugares() { }

    }
}
