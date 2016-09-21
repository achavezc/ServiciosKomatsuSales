using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using KOMATSU.SALES.Entidades;
using KOMATSU.SALES.LogicaNegocio;

namespace ServiciosKomatsuSales
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public PersonalBE Login(RequestLogin request)
        {
            return new PersonalBL().Login(request.usuario, request.password);
        }
        public List<ClienteBE> ObtenerClientes(RequestConsultarClientes request)
        {
            return new ClienteBL().ObtenerClientes(request.Ruc, request.RazonSocial);
        }
        public List<ProductoBE> ObtenerProductos(RequestConsultarProductos request)
        {
            return new ProductoBL().ObtenerProductos(request.CodigoProducto, request.NombreProducto);
        }
        public List<VisitaBE> ObtenerVisitas(RequestObtenerVisitas request)
        {
            return new VisitaBL().ObtenerVisitas(request.NombrePersonal, request.DNI);
        }

        public List<CotizacionBE> ObtenerCotizaciones(RequestObtenerCotizaciones request)
        {
            return new CotizacionBL().ObtenerCotizaciones(request.NumeroCotizacion, request.FechaEmision, request.Estado, request.NombrePersonal, request.DNI);
        }

        public List<DetalleCotizacionBE> ObtenerDetalleCotizacion(string numeroCotizacion)
        {
            return new CotizacionBL().ObtenerDetalleCotizacion(numeroCotizacion);
        }
    }
}
