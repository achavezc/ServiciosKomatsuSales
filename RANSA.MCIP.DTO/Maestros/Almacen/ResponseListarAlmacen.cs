using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO
{
    public class ResponseListarAlmacenDTO : BaseDTO
    {
        public List<AlmacenDTO> Almacenes { get; set; }

        public string DefaultCodigoAlmacen { get; set; }
    }
}
