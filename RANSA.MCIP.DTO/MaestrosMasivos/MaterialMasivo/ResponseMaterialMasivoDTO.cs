using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO.MaestrosMasivos.MaterialMasivo
{
    public class ResponseMaterialMasivoDTO
    {
         public Resultado Result { get; set; }
         public ResponseMaterialMasivoDTO()
        {
            Result = new Resultado();

        }

    }
}
