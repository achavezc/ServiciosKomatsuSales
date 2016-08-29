using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RANSA.MCIP.Entidades;
using RANSA.MCIP.DTO;
using RANSA.MCIP.Framework;
using System.Data;

namespace RANSA.MCIP.AccesoDatos
{
    public class EstadoDA : RepositorioBase<Estado>
    {
        public EstadoDA(ContextoParaBaseDatos contexto) : base(contexto) { }

        public List<Estado> ListarEstados()
        {
            List<Estado> estados = new List<Estado>();
            try
            {
                List<InputEF> lstInputBD = new List<InputEF>();

                estados = new HelperEF(Contexto.Database).EjecutarFuncionOProcedimiento<Estado>("SP_GRSCRIPTOR_ListarEstado", lstInputBD);

                return estados;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AccesoDatos);
                throw ex;
            }
        }
    }
}
