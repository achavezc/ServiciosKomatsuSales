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
    public class ClienteBL
    {
        private ClienteDA objDA;

        public ClienteBL()
        {
            objDA = new ClienteDA(new ContextoParaBaseDatos());        
        }

        public ResponseListarClienteDTO ListarCliente()
        {
            var response = new ResponseListarClienteDTO();
            response.Clientes = new List<ClienteDTO>();
            
            try
            {
                List<Cliente> lista = objDA.ListarCliente();
            
                foreach (var cliente in lista)
                {
                    response.Clientes.Add(
                    new ClienteDTO() 
                    {
                        IdCliente = cliente.IdCliente,
                        IdNegocio = cliente.IdNegocio,
                        IdCuenta = cliente.IdCuenta,
                        CodigoCliente = cliente.CodigoCliente,
                        Nombre = cliente.Nombre,
                        Direccion = cliente.Direccion,
                        CodigoTipoDocumento = cliente.CodigoTipoDocumento,
                        NumDocumento = cliente.NumDocumento,
                        IdPais = cliente.IdPais,
                        IdDepartamento = cliente.IdDepartamento,
                        IdProvincia = cliente.IdProvincia,
                        IdDistrito = cliente.IdDistrito
                    });
                }

                response.DefaultCodigoCliente = lista.FirstOrDefault() != null ? lista.FirstOrDefault().CodigoCliente : String.Empty;
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
