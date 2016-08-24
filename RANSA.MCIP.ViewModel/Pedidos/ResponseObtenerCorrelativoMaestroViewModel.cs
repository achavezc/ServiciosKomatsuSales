using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RANSA.MCIP.DTO;

namespace RANSA.MCIP.ViewModel.Pedidos
{
    public class ResponseObtenerCorrelativoMaestroViewModel
    {
        public string Correlativo { get; set; }
        public Result Result { get; set; }
        public ResponseObtenerCorrelativoMaestroViewModel()
        {
            this.Result = new Result();
        }
    }
}
