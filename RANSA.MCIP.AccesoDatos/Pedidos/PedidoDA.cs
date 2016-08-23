using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RANSA.MCIP.Entidades;
using RANSA.MCIP.Framework;
using RANSA.MCIP.DTO;

namespace RANSA.MCIP.AccesoDatos.Pedidos
{
    public class PedidoDA : RepositorioBase<ConfiguracionCamposPedidos>
    {
        public PedidoDA(ContextoParaBaseDatos contexto) : base(contexto) { }

        public List<ConfiguracionCamposPedidosDTO> ValidarCamposPedido(RequestValidarCamposDTO request)
        {
            try
            {
                List<ConfiguracionCamposPedidosDTO> campos = new List<ConfiguracionCamposPedidosDTO>();
                List<InputEF> lstInputBD = new List<InputEF>();
                InputEF item = new InputEF();
                item.NombreAtributo = "@CodigoTipoPedido";
                item.DbTipo = DbType.String;
                item.ParametroDireccionGrabado = ParameterDirection.Input;
                item.SqlDbTipo = SqlDbType.VarChar;
                item.Valor = request.CodigoTipoPedido;
                lstInputBD.Add(item);

                InputEF item2 = new InputEF();
                item2.NombreAtributo = "@CodigoCuenta";
                item2.DbTipo = DbType.String;
                item2.ParametroDireccionGrabado = ParameterDirection.Input;
                item2.SqlDbTipo = SqlDbType.VarChar;
                item2.Valor = request.CodigoCuenta;
                lstInputBD.Add(item2);

                campos = new HelperEF(Contexto.Database).EjecutarFuncionOProcedimiento<ConfiguracionCamposPedidosDTO>("SP_GRSCRIPTOR_OBTENER_CAMPOS_PEDIDO", lstInputBD);

                return campos;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AccesoDatos);
                throw ex;
            }
        }
    }
}
