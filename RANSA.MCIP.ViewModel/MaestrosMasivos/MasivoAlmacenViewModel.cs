using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.ViewModel.MaestrosMasivos
{
    public class MasivoAlmacenViewModel
    {
        public string CodigoAlmacen { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Anulado { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string CodigoCuenta { get; set; }
        public string CodigoNegocio { get; set; }
    }
}
