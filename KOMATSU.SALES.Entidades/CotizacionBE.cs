using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOMATSU.SALES.Entidades
{
    public class CotizacionBE
    {
        public string NumeroCotizacion { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaOfertaValida { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
        public double ValorVenta { get; set; }
        public double IGV { get; set; }
        public double PrecioTotal { get; set; }
        public int IdPersona { get; set; }
        public int IdCliente { get; set; }
        public string NombrePersonal { get; set; }
        public string ApellidoPersonal { get; set; }
        public string DNI { get; set; }
    }
}
