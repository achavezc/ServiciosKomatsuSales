using RANSA.MCIP.DTO;
using RANSA.MCIP.DTO.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioOracleWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
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
        [WebInvoke(UriTemplate = "/RegistrarPedidoIndividualMasivo", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseRegistarPedidoDTO RegistrarPedidoIndividualMasivo(List<RequestRegistroPedidoIndividualDTO> request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ObtenerCorrelativoPedido", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseObtenerCorrelativoMaestro ObtenerCorrelativoPedido();


    }

}
