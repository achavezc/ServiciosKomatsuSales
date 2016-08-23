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
    public class CuentaBL
    {
        private CuentaDA objDA;

        public CuentaBL()
        {
            objDA = new CuentaDA(new ContextoParaBaseDatos());        
        }

        public ResponseListarCuentaDTO ListarCuenta()
        {
            var response = new ResponseListarCuentaDTO();
            response.Cuentas = new List<CuentaDTO>();
            try
            {
                List<Cuenta> lista = objDA.ListarCuenta();

                foreach (var cuenta in lista)
                {
                    response.Cuentas.Add(
                        new CuentaDTO() { 
                        IdCuenta = cuenta.IdCuenta,
                        CodigoCuenta = cuenta.CodigoCuenta,
                        CodigoNegocio = cuenta.CodigoNegocio,
                        Direccion = cuenta.Direccion,
                        Nombre = cuenta.Nombre,
                        FlagAnulacion = cuenta.FlagAnulacion
                    });
                }
                
                response.DefaultCodigoCuenta = lista.FirstOrDefault() != null ? lista.FirstOrDefault().CodigoCuenta : String.Empty;
                response.estadoOperacion = ConstantesSistema.EstadoOperacionServicioCorrecto;
            }
            catch (Exception ex)
            {
                response.estadoOperacion = ConstantesSistema.EstadoOperacionServicioError;
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }
            return response;
        }

        public ResponseObtenerCuentaPorCliente ObtenerCuentaPorCliente(RequestObtenerCuentaPorCliente request)
        {
            var response = new ResponseObtenerCuentaPorCliente();
            
            try
            {
                Cuenta cuenta = objDA.ObtenerCuentaPorCliente(request.CodigoCliente);
                CuentaDTO cuentaDTO = new CuentaDTO();

                if (cuenta != null)
                {
                    cuentaDTO.IdCuenta = cuenta.IdCuenta;
                    cuentaDTO.CodigoCuenta = cuenta.CodigoCuenta;
                    response.cuenta = cuentaDTO;
                }
                
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
