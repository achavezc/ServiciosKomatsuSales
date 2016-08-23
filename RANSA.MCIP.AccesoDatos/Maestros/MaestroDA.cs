using RANSA.MCIP.DTO.Maestros;
using RANSA.MCIP.Entidades;
using RANSA.MCIP.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.AccesoDatos.Maestros
{
    public class MaestroDA : RepositorioBase<Almacen>
    {
        public MaestroDA(ContextoParaBaseDatos contexto)
            : base(contexto)
        {
        }
        public ResponseObtenerCorrelativoMaestro ObtenerCorrelativoMaestro(RequestObtenerCorrelativoMaestro requestObtenerCorrelativoMaestro)
        {
            try
            {
                List<InputEF> lstInputBD = new List<InputEF>();
                InputEF item = new InputEF();
                item.NombreAtributo = "@tipo";
                item.DbTipo = DbType.String;
                item.ParametroDireccionGrabado = ParameterDirection.Input;
                item.SqlDbTipo = SqlDbType.VarChar;
                item.Valor = requestObtenerCorrelativoMaestro.Tipo;
                lstInputBD.Add(item);

                List<ResponseObtenerCorrelativoMaestro> respuesta = new HelperEF(Contexto.Database).EjecutarFuncionOProcedimiento<ResponseObtenerCorrelativoMaestro>("PA_GR_SCRIPTOR_ObtenerCorrelativoMaestros", lstInputBD);

                return respuesta.FirstOrDefault();
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AccesoDatos);
                throw ex;
            }
        }
    }
}
