using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RANSA.MCIP.DTO;

namespace RANSA.MCIP.ViewModel.Pedidos
{
    public class ResponseBusquedaPedidoViewModel
    {
        public List<ListaPedidosViewModel> ListaPedidos { get; set; }
        public int TotalRegistros { get; set; }
        public int CantidadPaginas { get; set; }
        public int NroPagina { get; set; }
        public Resultado Resultado { get; set; }
        public ResponseBusquedaPedidoViewModel()
        {
            ListaPedidos = new List<ListaPedidosViewModel>();
            this.Resultado = new Resultado();
        }
    }
}
