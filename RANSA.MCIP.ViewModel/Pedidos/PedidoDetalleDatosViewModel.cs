using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.ViewModel.Pedidos
{
    public class PedidoDetalleDatosViewModel
    {
        public int? IdPedidoDetalle { get; set; }
        public string Item { get; set; }
        public string CodigoMaterial { get; set; }
        public string DescripcionMaterial { get; set; }
        public int Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public string Peso { get; set; }
        public string UnidadMedidaPeso { get; set; }
        public string Observaciones { get; set; }
        public string EstadoRegistro { get; set; }
    }
}
