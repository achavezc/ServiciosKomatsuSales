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
    public class NegocioDA : RepositorioBase<Negocio>
    {
        public NegocioDA(ContextoParaBaseDatos contexto) : base(contexto) { }

        public List<Negocio> ListarNegocio()
        {
            try 
            {
                List<Negocio> negocios = new List<Negocio>();
                List<InputEF> lstInputBD = new List<InputEF>();

                negocios = new HelperEF(Contexto.Database).EjecutarFuncionOProcedimiento<Negocio>("SP_GRSCRIPTOR_ListarNegocio", lstInputBD);

                return negocios;          
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AccesoDatos);
                throw ex;
            }
        }
    }
}
