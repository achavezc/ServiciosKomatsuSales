using GR.Scriptor.Comun.Controladoras.Proxys;
using RANSA.MCIP.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;


namespace ModuloPilotoSodexo.Proxy
{
    public class AdjuntarArchivosProxyRest : ProxyBaseRest
    {
        public ResponseAdjuntarArchivoDTO AgregarArchivo(RequestAdjuntarArchivosDTO requestAdjuntarArchivosDTO)
        {
            //requestAdjuntarArchivosDTO.SetRequestBaseDTO(GR.COMEX.Comercial.Web.Helpers.Helper.GetRequestBaseDTO());
            var url = ConfigurationManager.AppSettings["UrlAgregarArchivo"];
            //var url = "http://localhost:8733/AdjuntarArchivosServicio.svc/AgregarArchivo";

            var responseBandejaPendientes = DeserializarJSON<RequestAdjuntarArchivosDTO, ResponseAdjuntarArchivoDTO>(requestAdjuntarArchivosDTO, url);
            return responseBandejaPendientes;
        }

        public ResponseEliminarAdjuntarArchivoDTO EliminarArchivos(EliminarArchivoAdjuntoDTO obj)
        {
            //obj.SetRequestBaseDTO(GR.COMEX.Comercial.Web.Helpers.Helper.GetRequestBaseDTO());
            var url = ConfigurationManager.AppSettings["UrlEliminarArchivos"];
            //var url = "http://localhost:8733/AdjuntarArchivosServicio.svc/EliminarArchivos";

            var responseBandejaPendientes = DeserializarJSON<EliminarArchivoAdjuntoDTO, ResponseEliminarAdjuntarArchivoDTO>(obj, url);
            return responseBandejaPendientes;
        }

        public ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request)
        {
            //request.SetRequestBaseDTO(GR.COMEX.Comercial.Web.Helpers.Helper.GetRequestBaseDTO());
            var url = ConfigurationManager.AppSettings["UrlDescargarArchivo"];
            //var url = "http://localhost:8733/AdjuntarArchivosServicio.svc/DescargarArchivo";

            var responseBandejaPendientes = DeserializarJSON<RequestDescargarArchivoDTO, ResponseDescargarArchivoDTO>(request, url);
            return responseBandejaPendientes;
        }
    }
}