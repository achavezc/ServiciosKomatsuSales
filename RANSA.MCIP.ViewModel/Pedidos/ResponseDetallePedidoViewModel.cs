using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RANSA.MCIP.ViewModel.Pedidos;
using RANSA.MCIP.DTO;

namespace RANSA.MCIP.ViewModel.Pedidos
{
    public class ResponseDetallePedidoViewModel //: ResponsePaginacionBaseDTO
    {
        public Resultado Resultado { get; set; }
        public List<DetallePedidoViewModel> ListaDetallePedido { get; set; }
        public List<DetalleAnexoPedidoViewModel> ListaPedidoAnexos { get; set; }
        public List<DetalleAnexoAdjuntoPedidoViewModel> ListaPedidoAnexosAdjuntos { get; set; }

        public string CodigoTipoPedido { get; set; }
        public string TipoPedido { get; set; }
        public string NroPedido { get; set; }
        public string FechaSolicitud { get; set; }
        public string HoraSolicitud { get; set; }
        public string CodigoCuenta { get; set; }
        public string Cuenta { get; set; }
        public string CodigoNegocio { get; set; }
        public string Negocio { get; set; }
        public string FechaEstimadaEntrega { get; set; }
        public string NroReferencia { get; set; }
        public string CodigoPuntoOrigen { get; set; }
        public string NombrePuntoOrigen { get; set; }
        public string CodigoPuntoDestino { get; set; }
        public string NombrePuntoDestino { get; set; }
       

        public double ImporteTotalDocumento { get; set; }
        public string CondicionPago { get; set; }
        public string MonedaPago { get; set; }
        public string AreaSolicitante { get; set; }
        public string NroFactura { get; set; }
        public string ClaveSeguimiento { get; set; }
        public string Observaciones { get; set; }


        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int EstadoRegistro { get; set; }
        public string IdPedido { get; set; }
        public string EstadoPedido { get; set; }
        public string DireccionOrigen { get; set; }
        public string DireccionDestino { get; set; }

        public ResponseDetallePedidoViewModel()
        {
            this.Resultado = new Resultado();
            this.ListaDetallePedido = new List<DetallePedidoViewModel>();
            this.ListaPedidoAnexos = new List<DetalleAnexoPedidoViewModel>();
            this.ListaPedidoAnexosAdjuntos = new List<DetalleAnexoAdjuntoPedidoViewModel>();

        }
    }
}
