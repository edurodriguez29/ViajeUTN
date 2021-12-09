using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaDeViajes
{
    public abstract class Paquete
    {
        private string apelativo;
        private short cantidadDias;
        private DateTime fechaDeSalida;
        private Boolean vigencia = true;
        private byte cantCuotas;
        private double precio;

        protected Paquete()
        {
        }

        protected Paquete(string apelativo, short cantidadDias, DateTime fechaDeSalida, bool vigencia, byte cantCuotas, double precio)
        {
            this.apelativo = apelativo;
            this.cantidadDias = cantidadDias;
            this.fechaDeSalida = fechaDeSalida;
            this.vigencia = vigencia;
            this.cantCuotas = cantCuotas;
            this.precio = precio;
        }
        private string Apelativo { get; set; }
        private short CantidadDias { get; set; }
        private DateTime FechaDeSalida { get; set; }
        private Boolean Vigencia { get; set; }
        private double CantidadCuotas { get; set; }
        private byte Precio { get; set; }
    }
}
