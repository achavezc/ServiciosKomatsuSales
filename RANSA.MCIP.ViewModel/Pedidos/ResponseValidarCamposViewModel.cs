using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RANSA.MCIP.Entidades;
using RANSA.MCIP.DTO;
namespace RANSA.MCIP.ViewModel.Pedidos
{
    public class ResponseValidarCamposViewModel //: ResponsePaginacionBaseDTO
    {

        public List<ConfiguracionCamposPedidosViewModel> campos { get; set; }
        public Resultado Resultado { get; set; }
        public ResponseValidarCamposViewModel()
        {
            this.campos = new List<ConfiguracionCamposPedidosViewModel>();
            this.Resultado = new Resultado();
        }

    }
}
