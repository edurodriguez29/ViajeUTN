using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Factura
    {
        private int idFactura=0;
        private Cliente oCliente=new Cliente();
        private DateTime fecha=DateTime.Now;
    
        private double total = 0;

        private List<FactDetalle> lFacturaDet=new List<FactDetalle>();



        public Cliente OCliente { get => oCliente; set => oCliente = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int IDFactura { get => idFactura; set => idFactura = value; }
        public List<FactDetalle> LFacturaDet { get => lFacturaDet; set => lFacturaDet = value; }

        public double Total { get => total; set => total = value; }
    }
}
