using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO
{
    public class ResponseListarPedidoDTO //: ResponsePaginacionBaseDTO
    {
        public Resultado Resultado { get; set; }
        public List<PedidoDTO> ListaPedidos { get; set; }
        public int TotalRegistros { get; set; }
        public int CantidadPaginas { get; set; }
        public int NroPagina { get; set; }
        

        public ResponseListarPedidoDTO()
        {
            this.Resultado = new Resultado();
            this.ListaPedidos = new List<PedidoDTO>();
        }
    }
}
