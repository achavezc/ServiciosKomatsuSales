using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RANSA.MCIP.DTO;

namespace RANSA.MCIP.ServicioWCF
{
    [ServiceContract]
    public interface IPedidoIndividualServicio
    {


        [OperationContract]
        [WebInvoke(UriTemplate = "/RegistrarPedidoIndividual", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseRegistarPedidoDTO RegistrarPedidoIndividual(RequestRegistroPedidoIndividualDTO request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ActualizarPedidoIndividual", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseRegistarPedidoDTO ActualizarPedidoIndividual(RequestRegistroPedidoIndividualDTO request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ListarPedidoIndividual", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseListarPedidoDTO ListarPedidoIndividual(RequestListarPedidoIndividualDTO request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ObtenerDetallePedidoIndividual", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseDetallePedidoDTO ObtenerDetallePedidoIndividual(RequestDetallePedidoIndividualDTO request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/EliminarPedidoIndividual", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseRegistarPedidoDTO EliminarPedidoIndividual(List<EliminarPedidoDTO> request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ValidarPedidoIndividual", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseValidarCamposDTO ValidarPedidoIndividual(RequestValidarCamposDTO request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/RegistrarPedidoIndividualMasivo", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseRegistarPedidoDTO RegistrarPedidoIndividualMasivo(List<RequestRegistroPedidoIndividualDTO> request);
    }
}
