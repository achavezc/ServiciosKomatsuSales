using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace RANSA.MCIP.DTO
{

    public class ResponseListarMaterialDTO : BaseDTO
    {
        public List<MaterialDTO> Materiales { get; set; }

        public string DefaultCodigoTipoPedido { get; set; }
    }
}
