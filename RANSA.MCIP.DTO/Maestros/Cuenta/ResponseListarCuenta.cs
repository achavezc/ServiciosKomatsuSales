using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO
{
    public class ResponseListarCuentaDTO : BaseDTO
    {
        public List<CuentaDTO> Cuentas { get; set; }

        public string DefaultCodigoCuenta { get; set; }
    }
}
