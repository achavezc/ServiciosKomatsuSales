using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.ViewModel.Pedidos
{
    public class CambiarEstadoPedidoViewModel
    {
        public string Id { get; set; }
        public string EstadoPedido { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
