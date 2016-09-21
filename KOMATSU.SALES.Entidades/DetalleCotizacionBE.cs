using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOMATSU.SALES.Entidades
{
    public class DetalleCotizacionBE
    {
        public int IdDetalleCotizacion { get; set; }
        public int Cantidad { get; set; }
        public double CostoTotal { get; set; }
        public string NumeroCotizacion { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
    }
}
