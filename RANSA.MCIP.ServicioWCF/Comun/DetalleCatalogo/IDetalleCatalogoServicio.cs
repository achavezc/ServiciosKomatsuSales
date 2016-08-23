/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:37:28 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RANSA.MCIP.DTO;
using RANSA.MCIP.Entidades.Core;

namespace RANSA.MCIP.ServicioWCF
{
    [ServiceContract]
    public interface IDetalleCatalogoServicio
	{
        //public ResponseObtenerUnoDetalleCatalogo ObtenerUnoDetalleCatalogo(RequestObtenerUnoDetalleCatalogo request)
        //{
        //    throw new System.NotImplementedException();
        //}

        /// <summary>
        /// 
        /// <br/><b>Url Invocación:</b> <a href=""></a>
        /// <br/><b>Request Json:</b> ""
        /// <br/><b>Response Json:</b> ""
        /// </summary>
        /// <param name="request">Entidad con los datos para la operación.</param>
        /// <returns>Entidad con datos de la respuesta de la operación.</returns>        
        [OperationContract]
        [WebInvoke(UriTemplate = "/ListarDetalleCatalogo", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DetalleCatalogo> ListarDetalleCatalogo(Dictionary<string, string> request);

        /// <summary>
        /// 
        /// <br/><b>Url Invocación:</b> <a href=""></a>
        /// <br/><b>Request Json:</b> ""
        /// <br/><b>Response Json:</b> ""
        /// </summary>
        /// <param name="request">Entidad con los datos para la operación.</param>
        /// <returns>Entidad con datos de la respuesta de la operación.</returns>        
        [OperationContract]
        [WebInvoke(UriTemplate = "/GrabarDetalleCatalogoMasivo", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseRegistrarDetalleCatalogoMasivo GrabarDetalleCatalogoMasivo(RequestRegistrarDetalleCatalogoMasivo request);


	}
}