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
    public class AlmacenBL
    {
        private AlmacenDA objDA;

        public AlmacenBL()
        {
            objDA = new AlmacenDA(new ContextoParaBaseDatos());        
        }

        public ResponseListarAlmacenDTO ListarAlmacen()
        {
            var response = new ResponseListarAlmacenDTO();
            response.Almacenes = new List<AlmacenDTO>();
            try
            {
                List<Almacen> lista = objDA.ListarAlmacen();

                foreach (var almacen in lista)
                {
                    response.Almacenes.Add(
                    new AlmacenDTO() 
                    {
                        IdAlmacen = almacen.IdAlmacen,
                        IdNegocio = almacen.IdNegocio,
                        IdCuenta = almacen.IdCuenta,
                        CodigoAlmacen = almacen.CodigoAlmacen,
                        Nombre = almacen.Nombre,
                        Direccion = almacen.Direccion,
                        IdPais = almacen.IdPais,
                        IdDepartamento = almacen.IdDepartamento,
                        IdProvincia = almacen.IdProvincia,
                        IdDistrito = almacen.IdDistrito                        
                     });
                }

                response.DefaultCodigoAlmacen = lista.FirstOrDefault() != null ? lista.FirstOrDefault().CodigoAlmacen : String.Empty;
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
