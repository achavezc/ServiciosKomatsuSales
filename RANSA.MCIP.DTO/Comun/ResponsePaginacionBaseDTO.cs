using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO
{

    public class ResponsePaginacionBaseDTO
    {

        public Result Result { get; set; }
        public int TotalRegistros { get; set; }
        public int CantidadPaginas { get; set; }
    }
}
