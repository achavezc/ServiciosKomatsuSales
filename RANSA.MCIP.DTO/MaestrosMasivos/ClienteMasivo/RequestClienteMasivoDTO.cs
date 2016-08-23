using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO.MaestrosMasivos.ClienteMasivo
{
    public class RequestClienteMasivoDTO
    {

        public List<MasivoClienteDTO> ListaCliente { get; set; }
        public RequestClienteMasivoDTO()
        {
            ListaCliente = new List<MasivoClienteDTO>();
        }

    }
}
