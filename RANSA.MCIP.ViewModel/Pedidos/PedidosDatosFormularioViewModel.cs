using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.ViewModel.Pedidos
{
    public class PedidosDatosFormularioViewModel
    {
        public string CodigoPedido { get; set; }
        public string CodigoCuenta { get; set; }
        public string CodigoTipoPedido { get; set; }
        public string CodigoPuntoOrigen { get; set; }
        public string CodigoPuntoDestino { get; set; }
        public string NroPedido { get; set; }
        public string DireccionOrigen { get; set; }
        public string DireccionDestino { get; set; }
        public string CodigoNegocio { get; set; }
        public string FechaSolicitud { get; set; }
        public string HoraSolicitud { get; set; }
        public string Estado { get; set; }
        /*Propiedades auxiliares*/
        public string CodigoCliente { get; set; }
        public string CodigoRol { get; set; }
    }
}
