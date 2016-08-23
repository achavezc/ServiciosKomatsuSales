using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.Entidades
{
    public class TipoPedido
    {
        public string IdTipoPedido { get; set; }
        public string CodigoTipoPedido { get; set; }
        public string DescripcionBreve { get; set; }
        public string Descripcion { get; set; }
        public string FlagAnulacion { get; set; }
    }
}
