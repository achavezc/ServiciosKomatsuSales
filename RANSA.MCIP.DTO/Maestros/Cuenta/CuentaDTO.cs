using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO
{
    public class CuentaDTO
    {
        public string IdCuenta { get; set; }
        public string CodigoCuenta { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string CodigoNegocio { get; set; }
        public string FlagAnulacion { get; set; }
    }
}
