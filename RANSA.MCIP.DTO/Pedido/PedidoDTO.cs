using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO
{
    public class PedidoDTO
    {
        public string CodigoTipoPedido { get; set; }
        public string TipoPedido { get; set; }
        public string NroPedido { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public string HoraSolicitud { get; set; }
        public string CodigoCuenta { get; set; }
        public string Cuenta { get; set; }
        public string CodigoNegocio { get; set; }
        public string Negocio { get; set; }
        public DateTime? FechaEstimadaEntrega { get; set; }
        public string NroReferencia { get; set; }
        public string CodigoPuntoOrigen { get; set; }
        public string CodigoPuntoDestino { get; set; }
        public double ImpTotalDocumento { get; set; }
        public string CodigoCondicionPago { get; set; }
        public string CodigoMonedaPago { get; set; }
        public string CodigoAreaSolicitante { get; set; }
        public string NumeroFactura { get; set; }
        public string ClaveSeguimiento { get; set; }
        public string ObservacionesComentarios { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int EstadoRegistro { get; set; }
        public string IdPedido { get; set; }
        public string EstadoPedido { get; set; }
        public string DireccionOrigen { get; set; }
        public string DireccionDestino { get; set; }
    }
}
