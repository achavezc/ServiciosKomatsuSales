using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RANSA.MCIP.DTO;

namespace RANSA.MCIP.ViewModel.Pedidos
{
    public class RequestBusquedaPedidosViewModel : RequestBaseDTO
    {
        public BusquedaPedidosViewModel filtro { get; set; }
        public PaginacionDTO paginacionDTO { get; set; }
        public RequestBusquedaPedidosViewModel()
        {
            filtro = new BusquedaPedidosViewModel();
            paginacionDTO = new PaginacionDTO();
        }
    }
}
