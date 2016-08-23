/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:36:29 p.m.
*/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using RANSA.MCIP.DTO;
using RANSA.MCIP.Framework;


namespace RANSA.MCIP.AgenteServicios
{
    public class ComunAgenteServicioSAP : BaseAgenteServicios
    {
        //public ResponseSociedadesDTO listarEjemplo(RequestSociedadesDTO request)
        //{
        //    var url = "http://10.72.20.29:2021/MaestrosServicio.svc/Sociedad/ListarSociedades";

        //    //request.SetRequestBaseDTO(GR.COMEX.Comun.Controladoras.HelperControlador.GetRequestBaseDTO());
        //    ResponseSociedadesDTO responseSociedadesDTO  = DeserializarJSON<RequestSociedadesDTO, ResponseSociedadesDTO>(request, url);

        //    return responseSociedadesDTO;
        //}
        public void prueba()
        {
           // ServicioOracle.Servicio servicio= new ServicioOracle.Servicio();
           // servicio.HelloWorld();
            //request.SetRequestBaseDTO(GR.COMEX.Comun.Controladoras.HelperControlador.GetRequestBaseDTO());
            RequestRegistroPedidoIndividualDTO obj=new RequestRegistroPedidoIndividualDTO();
            ResponseRegistarPedidoDTO responseSociedadesDTO = DeserializarJSON<RequestRegistroPedidoIndividualDTO, ResponseRegistarPedidoDTO>(obj, "http://localhost:46694/Service1.svc/RegistrarPedidoIndividual");

         
        }
    }
}