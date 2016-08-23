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
    public class NegocioBL
    {
        private NegocioDA objDA;

        public NegocioBL()
        {
            objDA = new NegocioDA(new ContextoParaBaseDatos());        
        }

        public ResponseListarNegocioDTO ListarNegocio()
        {
            var response = new ResponseListarNegocioDTO();
            response.Negocios = new List<NegocioDTO>();

            try
            {
                List<Negocio> lista = objDA.ListarNegocio();

                foreach (var negocio in lista)
                {
                    response.Negocios.Add(
                    new NegocioDTO() 
                    {
                        IdNegocio = negocio.IdNegocio,
                        CodigoNegocio = negocio.CodigoNegocio,
                        Descripcion = negocio.Descripcion,
                        FlagAnulacion = negocio.FlagAnulacion
                    });
                }
                response.DefaultCodigoNegocio = lista.FirstOrDefault() != null ? lista.FirstOrDefault().CodigoNegocio : String.Empty;
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
