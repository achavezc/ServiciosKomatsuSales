using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.ViewModel.Pedidos
{
    public class RequestRegistroMasivoPedidoIndividualViewModel
    {
        public RequestRegistroMasivoPedidoIndividualViewModel()
        {
            ListaCargaMasiva = new List<RequestRegistroPedidoIndividualViewModel>();
        }
        public List<RequestRegistroPedidoIndividualViewModel> ListaCargaMasiva { get; set; }

    }
}
