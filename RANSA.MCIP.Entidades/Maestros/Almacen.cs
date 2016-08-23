using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.Entidades
{
    public class Almacen
    {
        public string IdAlmacen { get; set; }
        public string CodigoAlmacen { get; set; }
        public string IdNegocio { get; set; }
        public string IdCuenta { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string IdPais { get; set; }
        public string IdDepartamento { get; set; }
        public string IdProvincia { get; set; }
        public string IdDistrito { get; set; }
        public string FlagAnulacion { get; set; }
    }
}
