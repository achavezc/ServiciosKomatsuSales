using RANSA.MCIP.DTO;
using RANSA.MCIP.DTO.MaestrosMasivos.ClienteMasivo;
using RANSA.MCIP.Framework;
using RANSA.MCIP.LogicaNegocio.MaestrosMasivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RANSA.MCIP.ServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MaestroMasivoService" en el código y en el archivo de configuración a la vez.
    public class MaestroMasivoService : IMaestroMasivoService
    {

        public ResponseClienteMasivoDTO RegistraMasivocliente(RequestClienteMasivoDTO request)
        {
            var response = new ResponseClienteMasivoDTO();
            try
            {
                response = new ClienteMasivoBL().RegistrarClienteMasivo(request);
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
            }
            return response;
        }
    }
}
