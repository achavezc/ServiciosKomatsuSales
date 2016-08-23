using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RANSA.MCIP.Entidades;

namespace RANSA.MCIP.DTO
{
    public class ResponseValidarCamposDTO //: ResponsePaginacionBaseDTO
    {

        public List<ConfiguracionCamposPedidosDTO> campos { get; set; }
        public Resultado Resultado { get; set; }
        public ResponseValidarCamposDTO()
        {
            this.Resultado = new Resultado();
        }

    }
}
