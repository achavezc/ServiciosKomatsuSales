using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.Entidades
{
    public class ConfiguracionCamposPedidosDTO
    {
   
        public string Valor { get; set; }
        public string FlagObligatorio { get; set; }
        public string FlagInhabilitado { get; set; }
        public string TipoCampo { get; set; }
    }
}
