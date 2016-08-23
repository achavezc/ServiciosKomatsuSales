using RANSA.MCIP.DTO;
using RANSA.MCIP.DTO.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.ServicioWCF
{
    [ServiceContract]
    public interface IMaestroServicio
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/ListarCliente", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseListarClienteDTO ListarCliente();

        [OperationContract]
        [WebInvoke(UriTemplate = "/ListarCuenta", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseListarCuentaDTO ListarCuenta();

        [OperationContract]
        [WebInvoke(UriTemplate = "/ListarNegocio", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseListarNegocioDTO ListarNegocio();

        [OperationContract]
        [WebInvoke(UriTemplate = "/ListarTipoPedido", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseListarTipoPedidoDTO ListarTipoPedido();

        [OperationContract]
        [WebInvoke(UriTemplate = "/ListarAlmacen", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseListarAlmacenDTO ListarAlmacen();

        [OperationContract]
        [WebInvoke(UriTemplate = "/ObtenerCorrelativoMaestro", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseObtenerCorrelativoMaestro ObtenerCorrelativoMaestro(RequestObtenerCorrelativoMaestro requestObtenerCorrelativoMaestro);

    }
}
