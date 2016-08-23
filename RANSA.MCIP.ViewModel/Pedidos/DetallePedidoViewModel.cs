using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.ViewModel.Pedidos
{
    public class DetallePedidoViewModel
    {
        public string IdDetallePedido { get; set; }
        public string Item { get; set; }
        public string CodigoMaterial { get; set; }
        public string DescripcionMaterial { get; set; }
        public double Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public string UnidadMedidaPeso { get; set; }
        public string PesoUnitario { get; set; }
        public string PesoTotal { get; set; }
        public string Observaciones { get; set; }
        public string IdPedido { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int EstadoRegistro { get; set; }
    }
}
