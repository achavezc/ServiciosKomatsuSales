using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO
{
    public class ResponseRegistarPedidoDTO
    {
        public Resultado Result { get; set; }
        public ResponseRegistarPedidoDTO()
        {
            this.Result = new Resultado();
        }
    }
}
