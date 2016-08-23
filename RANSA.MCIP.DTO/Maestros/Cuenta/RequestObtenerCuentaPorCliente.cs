using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO
{
    public class RequestObtenerCuentaPorCliente : RequestBaseDTO
    {
        public string CodigoCliente { get; set; }
    }
}
