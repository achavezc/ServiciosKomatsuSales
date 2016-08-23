using GR.Scriptor.Comun.Controladoras.Proxys;
using ModuloPilotoSodexo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloPilotoSodexo.Proxy
{
    public class ProxyRest : ProxyBaseRest
    {
        public string Execute(string request, string urlServicio)
        {
            string salida = "[]";
            string response = DeserializarJSON(request, urlServicio);
            if (!String.IsNullOrEmpty(response))
                salida = response;
            return salida;
        }
        public ResponseListarResumenPedidoDTO ListarResumenPedido(RequestListarResumenPedidoDTO request, string urlServicio)
        {
            ResponseListarResumenPedidoDTO response = DeserializarJSON<RequestListarResumenPedidoDTO, ResponseListarResumenPedidoDTO>(request, urlServicio);

            if (response == null)
            {
                response.ListarResumenPedido = new List<DatosListarResumenPedido>();
                List<DatosListarResumenPedido> lst = new List<DatosListarResumenPedido>();
                lst.Add(new DatosListarResumenPedido()
                {
                    Estado = "ENVIADO",
                    Cantidad = 965
                });
                lst.Add(new DatosListarResumenPedido()
                {
                    Estado = "EN PREPARACION",
                    Cantidad = 5
                });
                lst.Add(new DatosListarResumenPedido()
                {
                    Estado = "DESPACHO PARCIAL",
                    Cantidad = 21
                });
                lst.Add(new DatosListarResumenPedido()
                {
                    Estado = "DESPACHO TOTAL",
                    Cantidad = 44
                });

                response.ListarResumenPedido.AddRange(lst);

                return response;
            }

            if (response == null)
                throw new Exception(string.Format("Problemas con el servicio: {0}", urlServicio));

            return response;
        }
        //public ResponseConsultaAvanzadaPedidoDTO BusquedaAvanzadaPedido(RequestConsultaAvanzadaPedidoDTO request, string urlServicio)
        //{
        //    ResponseConsultaAvanzadaPedidoDTO response = DeserializarJSON<RequestConsultaAvanzadaPedidoDTO, ResponseConsultaAvanzadaPedidoDTO>(request, urlServicio);

        //    if (response == null)
        //    {
        //        response.ConsultaAvanzadaPedidosList = new List<ConsultaAvanzadaPedidos>();
        //        return response;
        //    }

        //    if (response == null)
        //        throw new Exception(string.Format("Problemas con el servicio: {0}", urlServicio));

        //    return response;
        //}
        //public ResponseConsultaInventarioDTO BusquedaInventarios(RequestConsultaInventarioDTO request, string urlServicio)
        //{
        //    ResponseConsultaInventarioDTO response = DeserializarJSON<RequestConsultaInventarioDTO, ResponseConsultaInventarioDTO>(request, urlServicio);

        //    if (response == null)
        //    {
        //        ResponseConsultaInventarioDTO response2 = new ResponseConsultaInventarioDTO();
        //        response2.Result = new ModuloPilotoSodexo.Result();
        //        response2.Result.Success = false;

        //        //response.ListaInventario = new List<DatosConsultaInventario>();
        //        return response2;
        //    }

        //    if (response == null)
        //        throw new Exception(string.Format("Problemas con el servicio: {0}", urlServicio));

        //    return response;
        //}
        //public ResponseConsultaPedidoDTO ListarConsultaPedido(RequestConsultaPedidoDTO request, string urlServicio)
        //{
        //    ResponseConsultaPedidoDTO response = DeserializarJSON<RequestConsultaPedidoDTO, ResponseConsultaPedidoDTO>(request, urlServicio);

        //    if (response == null)
        //    {
        //        response.ListarConsultaPedido = new List<DatosConsultaPedido>();
        //        return response;
        //    }

        //    if (response == null)
        //        throw new Exception(string.Format("Problemas con el servicio: {0}", urlServicio));

        //    return response;
        //}
        public ResponseConsultaCabeceraPedidoDTO ObtenerCabeceraPedido(RequestConsultaCabeceraPedidoDTO request, string urlServicio)
        {
            ResponseConsultaCabeceraPedidoDTO response = DeserializarJSON<RequestConsultaCabeceraPedidoDTO, ResponseConsultaCabeceraPedidoDTO>(request, urlServicio);

            if (response == null)
            {
                ResponseConsultaCabeceraPedidoDTO responseOpcional = new ResponseConsultaCabeceraPedidoDTO();
                responseOpcional.CabeceraPedido = new DatosCabeceraPedido();
                return responseOpcional;
            }

            if (response == null)
                throw new Exception(string.Format("Problemas con el servicio: {0}", urlServicio));
            return response;
        }

        //public ResponseConsultaDetallePedidoDTO ListarDetallePedido(RequestConsultaDetallePedidoDTO request, string urlServicio)
        //{
        //    ResponseConsultaDetallePedidoDTO response = DeserializarJSON<RequestConsultaDetallePedidoDTO, ResponseConsultaDetallePedidoDTO>(request, urlServicio);

        //    if (response == null)
        //    {
        //        response.ListarDetallePedido = new List<DatosListarDetallePedido>();

        //        List<DatosListarDetallePedido> lst = new List<DatosListarDetallePedido>();
        //        response.ListarDetallePedido.AddRange(lst);

        //        return response;
        //    }



        //    if (response == null)
        //        throw new Exception(string.Format("Problemas con el servicio: {0}", urlServicio));

        //    return response;
        //}
        public ResponseCabeceraItemPedidoDTO ObtenerCabeceraDetallePedido(RequestCabeceraItemPedidoDTO request, string urlServicio)
        {
            ResponseCabeceraItemPedidoDTO response = DeserializarJSON<RequestCabeceraItemPedidoDTO, ResponseCabeceraItemPedidoDTO>(request, urlServicio);

            if (response == null)
                throw new Exception(string.Format("Problemas con el servicio: {0}", urlServicio));

            return response;
        }
        //public ResponseConsultaGuiaRemisionDTO ListarGuiaRemision(RequestConsultaGuiaRemisionDTO request, string urlServicio)
        //{
        //    ResponseConsultaGuiaRemisionDTO response = DeserializarJSON<RequestConsultaGuiaRemisionDTO, ResponseConsultaGuiaRemisionDTO>(request, urlServicio);
        //    if (response == null)
        //        throw new Exception(string.Format("Problemas con el servicio: {0}", urlServicio));

        //    return response;
        //}
        public ResponseConsultaCabeceraGuiaRemisionDTO ObtenerGuiaRemision(RequestConsultaCabeceraGuiaRemisionDTO request, string urlServicio)
        {

            ResponseConsultaCabeceraGuiaRemisionDTO response = DeserializarJSON<RequestConsultaCabeceraGuiaRemisionDTO, ResponseConsultaCabeceraGuiaRemisionDTO>(request, urlServicio);
            if (response == null)
                throw new Exception(string.Format("Problemas con el servicio: {0}", urlServicio));

            return response;
        }
        //public ResponseConsultarDetalleGuiaRemisionDTO ListarDetalleGuiaRemision(RequestDetalleGuiaRemisionDTO request, string urlServicio)
        //{
        //    ResponseConsultarDetalleGuiaRemisionDTO response = DeserializarJSON<RequestDetalleGuiaRemisionDTO, ResponseConsultarDetalleGuiaRemisionDTO>(request, urlServicio);
        //    if (response == null)
        //        throw new Exception(string.Format("Problemas con el servicio: {0}", urlServicio));

        //    return response;
        //}

        public dynamic ListarGrillas(dynamic request, string urlServicio)
        {
            dynamic response = DeserializarJSON<dynamic, dynamic>(request, urlServicio);

            if (response == null)
            {
                //response.ListarConsultaPedido = new List<DatosConsultaPedido>();
                return null;
            }

            if (response == null)
                return null;
            //throw new Exception(string.Format("Problemas con el servicio: {0}", urlServicio));

            return response;
        }

    }
}
