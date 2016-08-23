using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.ViewModel.Pedidos
{
    public class PedidoViewModel
    {
        public PedidosDatosFormularioViewModel DatosFormulario { get; set; }
        public PedidosObjetosFormularioViewModel ObjetosFormulario { get; set; }
        public bool SoloLectura { get; set; }
    }
}
