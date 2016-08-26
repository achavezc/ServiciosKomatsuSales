using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO.MaestrosMasivos.AlmacenMasivo
{
    public class MasivoAlmacenDTO
    {
        public string CodigoAlmacen { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string FlagAnulacion { get; set; }
        public string IdPais { get; set; }
        public string IdDepartamento { get; set; }
        public string IdProvincia { get; set; }
        public string IdDistrito { get; set; }
        public string CodigoCuenta { get; set; }
        public string CodigoNegocio { get; set; }
    }
}
