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
    public class EstadoBL
    {
        private EstadoDA objDA;

        public EstadoBL()
        {
            objDA = new EstadoDA(new ContextoParaBaseDatos());        
        }

        public ResponseListarEstado ListarEstados()
        {
            var response = new ResponseListarEstado();
            response.Estados = new List<EstadoDTO>();
            
            try
            {
                List<RANSA.MCIP.Entidades.Estado> lista = objDA.ListarEstados();
            
                foreach (var estado in lista)
                {
                    response.Estados.Add(
                    new EstadoDTO() 
                    {
                        IdEstado = estado.IdEstado,
                        Codigo = estado.Codigo,
                        Descripcion = estado.Descripcion
                    });
                }

                response.DefaultCodigoEstado = lista.FirstOrDefault() != null ? lista.FirstOrDefault().Codigo : String.Empty;
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
