using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO
{
    public class ResponseListarClienteDTO : BaseDTO
    {
        public List<ClienteDTO> Clientes { get; set; }

        public string DefaultCodigoCliente { get; set; }
    }
}
