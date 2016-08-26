using RANSA.MCIP.AccesoDatos.MaestrosMasivos;
using RANSA.MCIP.DTO;
using RANSA.MCIP.DTO.MaestrosMasivos.AlmacenMasivo;
using RANSA.MCIP.DTO.MaestrosMasivos.ClienteMasivo;
using RANSA.MCIP.DTO.MaestrosMasivos.MaterialMasivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.LogicaNegocio.MaestrosMasivos
{
    public class MaestrosMasivoBL
    {

        public ResponseClienteMasivoDTO RegistrarClienteMasivo(RequestClienteMasivoDTO request)
        {
            var response = new ResponseClienteMasivoDTO();
            try
            {
                var ListaCliente = new List<MasivoClienteDTO>();
                ListaCliente = request.ListaCliente;
                response = new ClienteMasivoDA().RegistrarClienteMasivo(ListaCliente);
                response.Result.Satisfactorio = true;
            }
            catch (Exception ex)
            {
                response.Result = new Resultado
                {
                    IdError = Guid.NewGuid(),
                    Satisfactorio = false,
                    Mensaje = "Ocurrio un problema interno en el servicio"
                };
            }
            return response;
        }


        public ResponseMaterialMasivoDTO RegistrarMaterialMasivo(RequestMaterialMasivoDTO request)
        {
            var response = new ResponseMaterialMasivoDTO();
            try
            {
                var ListaMaterial = new List<MasivoMaterialDTO>();
                ListaMaterial = request.ListaMaterial;
                response = new ClienteMasivoDA().RegistrarMaterialMasivo(ListaMaterial);
                response.Result.Satisfactorio = true;
            }
            catch (Exception ex)
            {
                response.Result = new Resultado
                {
                    IdError = Guid.NewGuid(),
                    Satisfactorio = false,
                    Mensaje = "Ocurrio un problema interno en el servicio"
                };
            }
            return response;
        }



        public ResponseAlmacenMasivoDTO RegistrarAlmacenMasivo(RequestAlmacenMasivoDTO request)
        {
            var response = new ResponseAlmacenMasivoDTO();
            try
            {
                var ListaAlmacen = new List<MasivoAlmacenDTO>();
                ListaAlmacen = request.ListaAlmacen;
                response = new ClienteMasivoDA().RegistrarAlmacenMasivo(ListaAlmacen);
                response.Result.Satisfactorio = true;
            }
            catch (Exception ex)
            {
                response.Result = new Resultado
                {
                    IdError = Guid.NewGuid(),
                    Satisfactorio = false,
                    Mensaje = "Ocurrio un problema interno en el servicio"
                };
            }
            return response;
        }


    }
}
