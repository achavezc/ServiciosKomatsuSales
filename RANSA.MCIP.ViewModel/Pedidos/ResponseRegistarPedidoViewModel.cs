using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RANSA.MCIP.DTO;

namespace RANSA.MCIP.ViewModel.Pedidos
{
    public class ResponseRegistarPedidoViewModel
    {
        public Result Result { get; set; }
        public ResponseRegistarPedidoViewModel()
        {
            this.Result = new Result();
        }
    }
}
