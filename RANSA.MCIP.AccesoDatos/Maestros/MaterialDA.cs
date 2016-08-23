using RANSA.MCIP.DTO;
using RANSA.MCIP.Entidades;
using RANSA.MCIP.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.AccesoDatos
{
    public class MaterialDA : RepositorioBase<Material>
    {
        public MaterialDA(ContextoParaBaseDatos contexto) : base(contexto) { }

        public List<Material> ListarMaterial(string codigoMaterial)
        {
            try
            {
                List<Material> materiales = new List<Material>();
                List<InputEF> lstInputBD = new List<InputEF>();
                InputEF item  = new InputEF();
                item.NombreAtributo = "@sch_CodigoMaterial";
                item.DbTipo = DbType.String;
                item.ParametroDireccionGrabado= ParameterDirection.Input;
                item.SqlDbTipo = SqlDbType.VarChar;
                item.Valor = codigoMaterial;
                lstInputBD.Add(item);

                materiales = new HelperEF(Contexto.Database).EjecutarFuncionOProcedimiento<Material>("SP_GRSCRIPTOR_ListarMaterial", lstInputBD);

                return materiales;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AccesoDatos);
                throw ex;
            }
        }
    }
}
