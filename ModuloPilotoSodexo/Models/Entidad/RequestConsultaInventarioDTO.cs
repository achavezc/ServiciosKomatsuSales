using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuloPilotoSodexo
{
    public class RequestConsultaInventarioDTO
    {
        public long CodigoCliente { get; set; }
        public long CodigoZona { get; set; }
        public string CodigoMercancia { get; set; }
        public long CodigoPais { get; set; }
        public string MercanciaSinSaldo { get; set; }
       // public string FechaInicio { get; set; }
       // public string FechaFin { get; set; }
        public long NumeroOrden { get; set; }
     //   public string Observacion { get; set; }
     //   public string Referencia { get; set; }

        public string ColumnaOrden { get; set; }
        public long PaginaActual { get; set; }
        public long TamanoPagina { get; set; }

    }
}