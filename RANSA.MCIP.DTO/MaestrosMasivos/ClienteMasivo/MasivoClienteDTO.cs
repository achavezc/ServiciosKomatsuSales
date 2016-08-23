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
        [DataMember(Order = 0)]
        public string Direccion { get; set; }

        [DataMember(Order = 1)]
        public string IdPais { get; set; }

        [DataMember(Order = 2)]
        public string IdDepartamento { get; set; }

        [DataMember(Order = 3)]
        public string IdProvincia { get; set; }

        [DataMember(Order = 4)]
        public string IdDistrito { get; set; }

        [DataMember(Order = 5)]
        public string FlagAnulacion { get; set; }

        [DataMember(Order = 6)]
        public string CodigoTipoDocumento { get; set; }

        [DataMember(Order = 6)]
        public string Nombre { get; set; }

        [DataMember(Order = 7)]
        public string CodigoCliente { get; set; }

        [DataMember(Order = 8)]
        public string NumDocumento { get; set; }

    }
}
