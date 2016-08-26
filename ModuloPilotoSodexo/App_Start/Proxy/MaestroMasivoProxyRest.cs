using GR.Scriptor.Comun.Controladoras.Proxys;
using RANSA.MCIP.DTO.MaestrosMasivos.AlmacenMasivo;
using RANSA.MCIP.DTO.MaestrosMasivos.ClienteMasivo;
using RANSA.MCIP.DTO.MaestrosMasivos.MaterialMasivo;
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


        public ResponseMaterialMasivoDTO RegistrarMasivoMaterial(RequestMaterialMasivoDTO request)
        {
            var url = ConfigurationManager.AppSettings["UrlRegistrarMasivoMaterial"];

            var response = DeserializarJSON<RequestMaterialMasivoDTO, ResponseMaterialMasivoDTO>(request, url);
            if (response == null)
                throw new Exception(string.Format("Problemas con el servicio: {0}", url));

            return response;
        }


        public ResponseAlmacenMasivoDTO RegistrarMasivoAlmacen(RequestAlmacenMasivoDTO request)
        {
            var url = ConfigurationManager.AppSettings["UrlRegistrarMasivoAlmacen"];

            var response = DeserializarJSON<RequestAlmacenMasivoDTO, ResponseAlmacenMasivoDTO>(request, url);
            if (response == null)
                throw new Exception(string.Format("Problemas con el servicio: {0}", url));

            return response;
        }


    }
}