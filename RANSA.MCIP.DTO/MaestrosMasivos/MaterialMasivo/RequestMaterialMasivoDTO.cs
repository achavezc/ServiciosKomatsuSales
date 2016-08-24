using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO.MaestrosMasivos.MaterialMasivo
{
    public class RequestMaterialMasivoDTO
    {
        public List<MasivoMaterialDTO> ListaMaterial { get; set; }
        public RequestMaterialMasivoDTO()
        {
            this.ListaMaterial = new List<MasivoMaterialDTO>();
        }
    }
}
