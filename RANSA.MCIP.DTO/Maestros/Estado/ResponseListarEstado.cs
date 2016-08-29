using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO
{
    public class ResponseListarEstado : BaseDTO
    {
        public List<EstadoDTO> Estados { get; set; }

        public string DefaultCodigoEstado { get; set; }
    }
}
