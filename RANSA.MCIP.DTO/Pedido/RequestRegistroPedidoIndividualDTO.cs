using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO
{
    public class RequestRegistroPedidoIndividualDTO
    {
        public RequestRegistroPedidoIndividualDTO()
        {
            ListaDetallePedido = new List<DetallePedidoDTO>(); 
            ListaPedidoAnexos = new List<DetalleAnexoPedidoDTO>();
            ListaPedidoAnexosAdjuntos = new List<DetalleAnexoAdjuntoPedidoDTO>();
        }
        public string CodigoTipoPedido { get; set; }
        public string NroPedido { get; set; }
        public string CodigoNegocio { get; set; }
        public string EstadoPedido { get; set; }
        public string FechaInicioSolicitud { get; set; }
        public string FechaFinSolicitud { get; set; }

        public DateTime FechaSolicitud { get; set; }
        public string HoraSolicitud { get; set; }
        public string CodigoCuenta { get; set; }

        public DateTime FechaEstimadaEntrega { get; set; }
        public string NroReferencia { get; set; }
        public string CodigoPuntoOrigen { get; set; }
        public string CodigoPuntoDestino { get; set; }
        public double ImporteTotalDocumento { get; set; }
        public string CondicionPago { get; set; }
        public string MonedaPago { get; set; }
        public string AreaSolicitante { get; set; }
        public string NroFactura { get; set; }
        public string ClaveSeguimiento { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int EstadoRegistro { get; set; }
        public string IdPedido { get; set; }

        public string DireccionOrigen { get; set; }
        public string DireccionDestino { get; set; }

        public List<DetallePedidoDTO> ListaDetallePedido { get; set; }
        public List<DetalleAnexoPedidoDTO> ListaPedidoAnexos { get; set; }
        public List<DetalleAnexoAdjuntoPedidoDTO> ListaPedidoAnexosAdjuntos { get; set; }
        
    }
}
