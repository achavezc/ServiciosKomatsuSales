using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO.MaestrosMasivos.ClienteMasivo
{
    public class MasivoClienteDTO
    {
        //[DataMember(Order = 0)]
        public string Direccion { get; set; }
        public string IdPais { get; set; }
        public string IdDepartamento { get; set; }
        public string IdProvincia { get; set; }
        public string IdDistrito { get; set; }
        public string FlagAnulacion { get; set; }
        public string CodigoTipoDocumento { get; set; }
        public string Nombre { get; set; }
        public string CodigoCliente { get; set; }
        public string NumDocumento { get; set; }

    }
}
