using RANSA.MCIP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.ViewModel.Pedidos
{
    public class PedidosObjetosFormularioViewModel
    {
        public List<ElementoDTO> ListaCodigoPuntoOrigen { get; set; }
        public List<ElementoDTO> ListaCodigoTipoPedido { get; set; }
        public List<ElementoDTO> ListaCodigoPuntoDestino { get; set; }
        public List<ElementoDTO> ListaCodigoCuenta { get; set; }
        public List<ElementoDTO> ListaCodigoNegocio { get; set; }
        public List<string> ListaPermisos { get; set; }
    }
}
