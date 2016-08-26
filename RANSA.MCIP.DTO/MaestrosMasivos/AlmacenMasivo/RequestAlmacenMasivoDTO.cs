using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO.MaestrosMasivos.AlmacenMasivo
{
    public class RequestAlmacenMasivoDTO
    {
        public List<MasivoAlmacenDTO> ListaAlmacen { get; set; }
        public RequestAlmacenMasivoDTO()
        {
            this.ListaAlmacen = new List<MasivoAlmacenDTO>();
        }
    }
}
