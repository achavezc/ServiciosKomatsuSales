using RANSA.MCIP.DTO;
using RANSA.MCIP.DTO.MaestrosMasivos.ClienteMasivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.LogicaNegocio.MaestrosMasivos
{
    public class ClienteMasivoBL
    {

        public ResponseClienteMasivoDTO RegistrarClienteMasivo(RequestClienteMasivoDTO request)
        {

            ResponseClienteMasivoDTO response = new ResponseClienteMasivoDTO();
            try
            {
                //var ListaCliente = new List<ClienteDTO>();
                //ListaCliente = request.RequestClienteMasivo;
                //ListaCliente.ForEach(delegate(ClienteDTO cliente)
                //{
                //    //response = servicioBL.RegistrarClienteMasivo(cliente);
                //});
            }
            catch (Exception ex)
            {
                //response.Result = new Result
                //{
                //    IdError = Guid.NewGuid(),
                //    Satisfactorio = false,
                //    Mensaje = "Ocurrio un problema interno en el servicio"
                //};
            }

            return response;

        }

    }
}
