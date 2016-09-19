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

        public string CodigoGenerico1 { get; set; }
        public string CodigoGenerico2 { get; set; }
        public string CodigoGenerico3 { get; set; }
        public string CodigoGenerico4 { get; set; }
        public string CodigoGenerico5 { get; set; }
        public string CodigoGenerico6 { get; set; }
        public string CodigoGenerico7 { get; set; }
        public string CodigoGenerico8 { get; set; }
        public string CodigoGenerico9 { get; set; }
        public string CodigoGenerico10 { get; set; }
        public string CodigoGenerico11 { get; set; }
        public string CodigoGenerico12 { get; set; }
        public string CodigoGenerico13 { get; set; }
        public string CodigoGenerico14 { get; set; }
        public string CodigoGenerico15 { get; set; }
        public string CodigoGenerico16 { get; set; }
        public string CodigoGenerico17 { get; set; }
        public string CodigoGenerico18 { get; set; }
        public string CodigoGenerico19 { get; set; }
        public string CodigoGenerico20 { get; set; }
        public string CodigoGenerico21 { get; set; }
        public string CodigoGenerico22 { get; set; }
        public string CodigoGenerico23 { get; set; }
        public string CodigoGenerico24 { get; set; }
        public string CodigoGenerico25 { get; set; }
        public string CodigoGenerico26 { get; set; }
        public string CodigoGenerico27 { get; set; }
        public string CodigoGenerico28 { get; set; }
        public string CodigoGenerico29 { get; set; }
        public string CodigoGenerico30 { get; set; }

        public List<DetallePedidoDTO> ListaDetallePedido { get; set; }
        public List<DetalleAnexoPedidoDTO> ListaPedidoAnexos { get; set; }
        public List<DetalleAnexoAdjuntoPedidoDTO> ListaPedidoAnexosAdjuntos { get; set; }
        
    }
}
