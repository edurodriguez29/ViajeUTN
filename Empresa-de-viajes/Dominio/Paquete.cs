using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Paquete
    {
        private int id = 0;
        private string nombre = "";
        private double precio = 0.0;
        private DateTime fecha_Inicio = DateTime.ParseExact("01-01-1900", "dd-MM-yyyy", CultureInfo.InvariantCulture); //Fecha en la que estara disponible el Paquete
        private DateTime fecha_Fin = DateTime.ParseExact("01-01-1900", "dd-MM-yyyy", CultureInfo.InvariantCulture);//Fecha en la que estara disponible el Paquete
        private DateTime fecha_Viaje = DateTime.ParseExact("01-01-1900", "dd-MM-yyyy", CultureInfo.InvariantCulture);//Fecha en la que se viaja
        private bool esNacional=false;
        private double cotizacionDol = 0.0;
        private bool requiereVisa=false;
        private double impuestoNacional=0.0;
        private double impuestoInt = 0.0;
        private int cantCuotas=0;
        private double montoCuota=0.0;
        private bool activo = false;
        private int cantDias = 0;
        private List<Lugares> LstLugares= new List<Lugares>();
      

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Precio { get => precio; set => precio = value; }
        public DateTime Fecha_Inicio { get => fecha_Inicio; set => fecha_Inicio = value; }
        public DateTime Fecha_Fin { get => fecha_Fin; set => fecha_Fin = value; }
        public bool EsNacional { get => esNacional; set => esNacional = value; }
        public double CotizacionDol { get => cotizacionDol; set => cotizacionDol = value; }
        public bool RequiereVisa { get => requiereVisa; set => requiereVisa = value; }
        public double ImpuestoNacional { get => impuestoNacional; set => impuestoNacional = value; }
        public double ImpuestoInt { get => impuestoInt; set => impuestoInt = value; }
        public int CantCuotas { get => cantCuotas; set => cantCuotas = value; }
        public double MontoCuota { get => montoCuota; set => montoCuota = value; }
        public bool Activo { get => activo; set => activo = value; }
        public DateTime Fecha_Viaje { get => fecha_Viaje; set => fecha_Viaje = value; }
        public int CantDias { get => cantDias; set => cantDias = value; }
        public List<Lugares> Lugares { get => LstLugares; set => LstLugares = value; }
    }
}
