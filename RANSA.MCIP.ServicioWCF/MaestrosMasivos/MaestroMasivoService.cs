using RANSA.MCIP.DTO;
using RANSA.MCIP.DTO.MaestrosMasivos.ClienteMasivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RANSA.MCIP.ServicioWCF.MaestrosMasivos
{

    public class MaestroMasivoService : IMaestroMasivoService
    {

        public ResponseClienteMasivoDTO RegistrarClienteMasivo(RequestClienteMasivoDTO request)
        {

            var response = new ResponseClienteMasivoDTO();
           

            return response;
        }



    }
}
