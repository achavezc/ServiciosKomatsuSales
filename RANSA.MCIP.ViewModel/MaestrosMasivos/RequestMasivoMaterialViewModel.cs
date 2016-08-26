using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.ViewModel.MaestrosMasivos
{
    public class RequestMasivoMaterialViewModel
    {

        public List<MasivoMaterialViewModel> ListaMaterial { get; set; }

        public RequestMasivoMaterialViewModel()
        {
            this.ListaMaterial = new List<MasivoMaterialViewModel>();
        }

    }
}
