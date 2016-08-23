using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace RANSA.MCIP.DTO
{
    
    public class ResponseListarTipoPedidoDTO : BaseDTO
    {
        public List<TipoPedidoDTO> TipoPedidos { get; set; }

        public string DefaultCodigoTipoPedido { get; set; }
    }
}
