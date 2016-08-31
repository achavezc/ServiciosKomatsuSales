using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.ViewModel.Pedidos
{
    public class BusquedaPedidosViewModel
    {
        public string CodigoTipoPedido { get; set; }
        public string NroPedido { get; set; }
        public string NumeroReferencia { get; set; }
        public string CodigoNegocio { get; set; }
        public string CodigoCuenta { get; set; }
        //public string EstadoPedido { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaSolicitudInicio { get; set; }
        public DateTime? FechaSolicitudFin { get; set; }
    }
}
