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
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public PersonalBE Login(string usuario, string password)
        {
            return new PersonalBL().Login(usuario, password);
        }
        public List<ClienteBE> ObtenerClientes(string ruc, string razonsocial)
        {
            return new ClienteBL().ObtenerClientes(ruc, razonsocial);
        }
        public List<ProductoBE> ObtenerProductos(string codigoProducto, string nombreProducto)
        {
            return new ProductoBL().ObtenerProductos(codigoProducto, nombreProducto);
        }
        public List<VisitaBE> ObtenerVisitas(string nombrePersonal, string dni)
        {
            return new VisitaBL().ObtenerVisitas(nombrePersonal, dni);
        }

        public List<CotizacionBE> ObtenerCotizaciones(string numeroCotizacion, DateTime fechaEmision, string estado,
            string nombrePersonal, string dni)
        {
            return new CotizacionBL().ObtenerCotizaciones(numeroCotizacion, fechaEmision, estado, nombrePersonal, dni);
        }

        public List<DetalleCotizacionBE> ObtenerDetalleCotizacion(string numeroCotizacion)
        {
            return new CotizacionBL().ObtenerDetalleCotizacion(numeroCotizacion);
        }
    }
}
