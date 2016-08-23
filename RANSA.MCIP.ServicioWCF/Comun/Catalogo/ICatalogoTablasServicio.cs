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

namespace RANSA.MCIP.ServicioWCF
{
    [ServiceContract]
    public interface ICatalogoTablasServicio
	{
        /// <summary>
        /// 
        /// <br/><b>Url Invocación:</b> <a href=""></a>
        /// <br/><b>Request Json:</b> ""
        /// <br/><b>Response Json:</b> ""
        /// </summary>
        /// <param name="request">Entidad con los datos para la operación.</param>
        /// <returns>Entidad con datos de la respuesta de la operación.</returns>        
        [OperationContract]
        [WebInvoke(UriTemplate = "/BuscarCatalogoTablas", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseBusquedaCatalogoTablasDTO BuscarCatalogoTablas(RequestBusquedaCatalogoTablasDTO request);

        /// <summary>
        /// 
        /// <br/><b>Url Invocación:</b> <a href=""></a>
        /// <br/><b>Request Json:</b> ""
        /// <br/><b>Response Json:</b> ""
        /// </summary>
        /// <param name="request">Entidad con los datos para la operación.</param>
        /// <returns>Entidad con datos de la respuesta de la operación.</returns>        
        [OperationContract]
        [WebInvoke(UriTemplate = "/BuscarCatalogoTablasMasivo", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseBusquedaCatalogoTablasMasivoDTO BuscarCatalogoTablasMasivo(RequestBusquedaCatalogoTablasDTO request);


        /// <summary>
        /// 
        /// <br/><b>Url Invocación:</b> <a href=""></a>
        /// <br/><b>Request Json:</b> ""
        /// <br/><b>Response Json:</b> ""
        /// </summary>
        /// <param name="request">Entidad con los datos para la operación.</param>
        /// <returns>Entidad con datos de la respuesta de la operación.</returns>        
        [OperationContract]
        [WebInvoke(UriTemplate = "/EliminarCatalogoTablas", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseEliminarCatalogoTablas EliminarCatalogoTablas(RequestEliminarCatalogoTablas request);

        /// <summary>
        /// 
        /// <br/><b>Url Invocación:</b> <a href=""></a>
        /// <br/><b>Request Json:</b> ""
        /// <br/><b>Response Json:</b> ""
        /// </summary>
        /// <param name="request">Entidad con los datos para la operación.</param>
        /// <returns>Entidad con datos de la respuesta de la operación.</returns>        
        [OperationContract]
        [WebInvoke(UriTemplate = "/GrabarCatalogoTablas", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseRegistrarCatalogoTablas GrabarCatalogoTablas(RequestRegistrarCatalogoTablas request);

        
        

        /// <summary>
        /// 
        /// <br/><b>Url Invocación:</b> <a href=""></a>
        /// <br/><b>Request Json:</b> ""
        /// <br/><b>Response Json:</b> ""
        /// </summary>
        /// <param name="request">Entidad con los datos para la operación.</param>
        /// <returns>Entidad con datos de la respuesta de la operación.</returns>        
        [OperationContract]
        [WebInvoke(UriTemplate = "/ObtenerCatalogoTablas", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseObtenerCatalogoTablasDTO ObtenerCatalogoTablas(RequestObtenerCatalogoTablasDTO request);
	}
}