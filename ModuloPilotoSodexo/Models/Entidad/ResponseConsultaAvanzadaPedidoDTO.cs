using ModuloPilotoSodexo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuloPilotoSodexo
{
    public class ResponseConsultaAvanzadaPedidoDTO
    {
        public List<ConsultaAvanzadaPedidos> ConsultaAvanzadaPedidosList { get; set; }
        public Result Result { get; set; }
        public int NroPagina { get; set; }
        
    }

    public class ConsultaAvanzadaPedidos
    {
        public long NumeroPedido { get; set; }
        public string FechaPedido { get; set; }
        public string FechaTransmision { get; set; }
        public string Referencia { get; set; }
        public string Observaciones { get; set; }
        public string Planta { get; set; }
        public string CodigoPlanta { get; set; }
        public string DireccionPlanta { get; set; }
    }
}