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
    public class AlmacenDA : RepositorioBase<Almacen>
    {
        public AlmacenDA(ContextoParaBaseDatos contexto) : base(contexto) { }

        public List<Almacen> ListarAlmacen()
        {
            List<Almacen> almacenes = new List<Almacen>();
            try
            {
                List<InputEF> lstInputBD = new List<InputEF>();

                almacenes = new HelperEF(Contexto.Database).EjecutarFuncionOProcedimiento<Almacen>("SP_GRSCRIPTOR_ListarAlmacen", lstInputBD);

                return almacenes;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AccesoDatos);
                throw ex;
            }

        }
    }
}
