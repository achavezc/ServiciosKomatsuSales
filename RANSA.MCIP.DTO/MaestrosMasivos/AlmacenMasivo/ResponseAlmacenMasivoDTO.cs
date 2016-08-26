using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO.MaestrosMasivos.AlmacenMasivo
{
    public class ResponseAlmacenMasivoDTO
    {
        public Resultado Result { get; set; }
        public ResponseAlmacenMasivoDTO()
        {
            this.Result = new Resultado();
        }
    }
}
