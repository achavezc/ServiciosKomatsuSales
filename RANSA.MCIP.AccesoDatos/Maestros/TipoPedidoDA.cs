using RANSA.MCIP.DTO;
using RANSA.MCIP.Entidades;
using RANSA.MCIP.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.AccesoDatos
{
    public class TipoPedidoDA : RepositorioBase<TipoPedido>
    {
        public TipoPedidoDA(ContextoParaBaseDatos contexto) : base(contexto) { }

        public List<TipoPedido> ListarTipoPedido()
        {
            try
            {
                List<TipoPedido> tipoPedidos = new List<TipoPedido>();
                List<InputEF> lstInputBD = new List<InputEF>();

                tipoPedidos = new HelperEF(Contexto.Database).EjecutarFuncionOProcedimiento<TipoPedido>("SP_GRSCRIPTOR_ListarTipoPedido", lstInputBD);

                return tipoPedidos;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AccesoDatos);
                throw ex;
            }
        }
    }
}
