using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO.MaestrosMasivos.ClienteMasivo
{
    public class ResponseClienteMasivoDTO
    {

        public Resultado Result { get; set; }
        public ResponseClienteMasivoDTO()
        {
            Result = new Resultado();

        }


    }
}
