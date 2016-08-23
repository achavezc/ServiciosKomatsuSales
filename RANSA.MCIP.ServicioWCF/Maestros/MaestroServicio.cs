using RANSA.MCIP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RANSA.MCIP.LogicaNegocio;
using RANSA.MCIP.Framework;
using RANSA.MCIP.DTO.Maestros;
using RANSA.MCIP.LogicaNegocio.Maestros;


namespace RANSA.MCIP.ServicioWCF
{
    public class MaestroServicio : IMaestroServicio
    {
        public ResponseListarClienteDTO ListarCliente()
        {
            try
            {
                ClienteBL clienteBL = new ClienteBL();
                ResponseListarClienteDTO response = clienteBL.ListarCliente();

                return response;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                return null;
            }
        }

        public ResponseListarTipoPedidoDTO ListarTipoPedido()
        {
            try
            {
                TipoPedidoBL tipoPedidoBL = new TipoPedidoBL();
                ResponseListarTipoPedidoDTO response = tipoPedidoBL.ListarTipoPedido();

                return response;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                return null;
            }
        }

        public ResponseListarCuentaDTO ListarCuenta()
        {
            try
            {
                CuentaBL cuentaBL = new CuentaBL();
                ResponseListarCuentaDTO response = cuentaBL.ListarCuenta();

                return response;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                return null;
            }
        }

        public ResponseListarAlmacenDTO ListarAlmacen()
        {
            try
            {
                AlmacenBL almacenBL = new AlmacenBL();
                ResponseListarAlmacenDTO response = almacenBL.ListarAlmacen();

                return response;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                return null;
            }
        }

        public ResponseListarNegocioDTO ListarNegocio()
        {
            try
            {
                NegocioBL negocioBL = new NegocioBL();
                ResponseListarNegocioDTO response = negocioBL.ListarNegocio();

                return response;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                return null;
            }
        }
        public ResponseObtenerCorrelativoMaestro ObtenerCorrelativoMaestro(RequestObtenerCorrelativoMaestro requestObtenerCorrelativoMaestro)
        {
            MaestroBL negocioBL = new MaestroBL();
            ResponseObtenerCorrelativoMaestro response = new ResponseObtenerCorrelativoMaestro();
            try
            {
                if (requestObtenerCorrelativoMaestro.Tipo == "pedido")
                {
                    
                   PedidoIndividualBL pedidoBL = new PedidoIndividualBL();
                   response = pedidoBL.ObtenerCorrelativoPedido();
                }
                else
                {
                    response = negocioBL.ObtenerCorrelativoMaestro(requestObtenerCorrelativoMaestro);
                }
                return response;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                return null;
            }
        }


    }
}
