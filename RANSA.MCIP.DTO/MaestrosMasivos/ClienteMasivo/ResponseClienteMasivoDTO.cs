using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO.MaestrosMasivos.ClienteMasivo
{
    public class ResponseClienteMasivoDTO 
    {

        public ResponseClienteMasivoDTO()
        {
            this.Result = new Resultado();
        }
        public Resultado Result { get; set; }
    }
}
