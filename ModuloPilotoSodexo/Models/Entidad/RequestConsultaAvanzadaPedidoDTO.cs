using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuloPilotoSodexo.Models
{
    /// <summary>
    /// CALL DC@RNSLIB.SP_AS400_CONSULTA_AVANZADA(1 ,21317,20150623,20150803,0,'139','LFR',10,1,'TCMPCP',0)

    /// </summary>
    public class RequestConsultaAvanzadaPedidoDTO
    {
        public long CodigoCliente { get; set; }
        public long CodigoProvincia { get; set; }
        public string ColumnaOrden { get; set; }
        public long FechaFin { get; set; }
        public long FechaInicio { get; set; }
        public long NumeroPedido { get; set; }
        public string Observacion { get; set; }
        public long PaginaActual { get; set; }
        public string Referencia { get; set; }
        public long TamanoPagina { get; set; }

    }
}