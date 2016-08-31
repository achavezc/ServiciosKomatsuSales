using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  RANSA.MCIP.DTO.Comun;

namespace RANSA.MCIP.DTO
{
    public class RequestListarPedidoIndividualDTO : BaseRequestDTO
    {

        public string CodigoTipoPedido { get; set; }
        public string NroPedido { get; set; }
        public string NumeroReferencia { get; set; }
        public string CodigoNegocio { get; set; }
        public string CodigoCuenta { get; set; }
        public string EstadoPedido { get; set; }
        public DateTime? FechaInicioSolicitud { get; set; }
        public DateTime? FechaFinSolicitud { get; set; }
         

        
    }
}
