using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO
{
    public class ResponseListarNegocioDTO : BaseDTO
    {
        public List<NegocioDTO> Negocios { get; set; }

        public string DefaultCodigoNegocio { get; set; }
    }
}
