using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RANSA.MCIP.AccesoDatos;
using RANSA.MCIP.Entidades;
using GR.Scriptor.Framework;
using RANSA.MCIP.DTO;
using RANSA.MCIP.Entidades.Constantes;

namespace RANSA.MCIP.LogicaNegocio
{
    public class TipoPedidoBL
    {
        private TipoPedidoDA objDA;

        public TipoPedidoBL()
        {
            objDA = new TipoPedidoDA(new ContextoParaBaseDatos());        
        }

        public ResponseListarTipoPedidoDTO ListarTipoPedido()
        {
            var response = new ResponseListarTipoPedidoDTO();
            response.TipoPedidos = new List<TipoPedidoDTO>();
            try
            {
                List<TipoPedido> lista = objDA.ListarTipoPedido();

                foreach (var tipoPedido in lista)
                {
                    response.TipoPedidos.Add(new TipoPedidoDTO() 
                    {
                        IdTipoPedido = tipoPedido.IdTipoPedido,
                        CodigoTipoPedido = tipoPedido.CodigoTipoPedido,
                        Descripcion = tipoPedido.Descripcion,
                        DescripcionBreve = tipoPedido.DescripcionBreve,
                        FlagAnulacion = tipoPedido.FlagAnulacion                        
                    });
                }

                response.DefaultCodigoTipoPedido = lista.FirstOrDefault() != null ? lista.FirstOrDefault().CodigoTipoPedido : String.Empty;
                response.estadoOperacion = ConstantesSistema.EstadoOperacionServicioCorrecto;
            }
            catch (Exception ex)
            {
                response.estadoOperacion = ConstantesSistema.EstadoOperacionServicioError;
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }
            return response;
        }
    }
}
