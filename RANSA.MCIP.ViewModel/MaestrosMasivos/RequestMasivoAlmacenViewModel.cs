using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.ViewModel.MaestrosMasivos
{
    public class RequestMasivoAlmacenViewModel
    {
        public List<MasivoAlmacenViewModel> ListaAlmacen { get; set; }
        public RequestMasivoAlmacenViewModel()
        {
            this.ListaAlmacen = new List<MasivoAlmacenViewModel>();
        }
    }
}
