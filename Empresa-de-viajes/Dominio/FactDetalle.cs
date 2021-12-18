using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class FactDetalle
    {
        private int item=0;
        private Paquete opaquete=new Paquete(); 
        private int cantPaquetes=0;
        private int cantCuotas = 0;
        private double montoCuotas = 0;
        private double impuestosNac = 0;
        private double inpuestosInt = 0;
        private double subtotal = 0;

        public int Item { get => item; set => item = value; }
        public Paquete paquete { get => opaquete; set => opaquete = value; }
        public int CantPaquetes { get => cantPaquetes; set => cantPaquetes = value; }
        public int CantCuotas { get => cantCuotas; set => cantCuotas = value; }
        public double MontoCuotas { get => montoCuotas; set => montoCuotas = value; }
        public double ImpuestosNac { get => impuestosNac; set => impuestosNac = value; }
        public double InpuestosInt { get => inpuestosInt; set => inpuestosInt = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
    }
}
