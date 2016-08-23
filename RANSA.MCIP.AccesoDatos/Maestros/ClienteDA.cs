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
    public class ClienteDA : RepositorioBase<Cliente>
    {
        public ClienteDA(ContextoParaBaseDatos contexto) : base(contexto) { }

        public List<Cliente> ListarCliente()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                List<InputEF> lstInputBD = new List<InputEF>();

                clientes = new HelperEF(Contexto.Database).EjecutarFuncionOProcedimiento<Cliente>("SP_GRSCRIPTOR_ListarCliente", lstInputBD);
                
                return clientes;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AccesoDatos);
                throw ex;
            }
        }

    }
}
