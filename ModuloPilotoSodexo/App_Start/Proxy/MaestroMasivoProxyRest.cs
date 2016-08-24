using GR.Scriptor.Comun.Controladoras.Proxys;
using RANSA.MCIP.DTO.MaestrosMasivos.ClienteMasivo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ModuloPilotoSodexo.Proxy
{
    public class MaestroMasivoProxyRest : ProxyBaseRest
    {

        public ResponseClienteMasivoDTO RegistrarMasivoCliente(RequestClienteMasivoDTO request)
        {
            var url = ConfigurationManager.AppSettings["UrlRegistrarMasivoCliente"];

            var response = DeserializarJSON<RequestClienteMasivoDTO, ResponseClienteMasivoDTO>(request, url);
            if (response == null)
                throw new Exception(string.Format("Problemas con el servicio: {0}", url));

            return response;
        }



    }
}