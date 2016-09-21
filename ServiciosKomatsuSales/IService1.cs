using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using KOMATSU.SALES.Entidades;

namespace ServiciosKomatsuSales
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Login", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PersonalBE Login(RequestLogin request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ObtenerClientes", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<ClienteBE> ObtenerClientes(RequestConsultarClientes request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ObtenerProductos", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<ProductoBE> ObtenerProductos(RequestConsultarProductos request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ObtenerVisitas", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<VisitaBE> ObtenerVisitas(RequestObtenerVisitas request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ObtenerCotizaciones", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<CotizacionBE> ObtenerCotizaciones(RequestObtenerCotizaciones request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ObtenerDetalleCotizacion", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DetalleCotizacionBE> ObtenerDetalleCotizacion(string numeroCotizacion);
    }


}
