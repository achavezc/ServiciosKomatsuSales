using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO.Comun
{
    public class BaseRequestDTO
    {
        public int? NroRegistrosPorPagina { get; set; }
        public string OrdenCampo { get; set; }
        public string OrdenOrientacion { get; set; }
        public int? PaginaActual { get; set; }
    }
}
