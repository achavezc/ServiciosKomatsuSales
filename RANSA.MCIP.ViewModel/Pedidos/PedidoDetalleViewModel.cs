using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.ViewModel.Pedidos
{
    public class PedidoDetalleViewModel
    {
        public PedidoDetalleDatosViewModel Datos { get; set; }

        public PedidoDetalleViewModel() 
        {
            Datos = new PedidoDetalleDatosViewModel();
        }
    }
}