using RANSA.MCIP.AccesoDatos;
using RANSA.MCIP.AccesoDatos.Maestros;
using RANSA.MCIP.DTO.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.LogicaNegocio.Maestros
{
    public class MaestroBL
    {
        public ResponseObtenerCorrelativoMaestro ObtenerCorrelativoMaestro(RequestObtenerCorrelativoMaestro requestObtenerCorrelativoMaestro)
        {
            return new MaestroDA(new ContextoParaBaseDatos()).ObtenerCorrelativoMaestro(requestObtenerCorrelativoMaestro);
        }
 
    }
}
