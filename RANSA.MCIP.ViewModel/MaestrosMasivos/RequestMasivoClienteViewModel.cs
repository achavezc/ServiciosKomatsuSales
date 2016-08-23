using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.ViewModel.MaestrosMasivos
{
    public class RequestMasivoClienteViewModel
    {
        public List<MasivoClienteViewModel> ListaCliente { get; set; }

        public RequestMasivoClienteViewModel()
        {
            ListaCliente = new List<MasivoClienteViewModel>();
        }
    }
}
