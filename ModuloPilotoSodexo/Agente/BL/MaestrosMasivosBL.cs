using GR.Scriptor.Framework;
using ModuloPilotoSodexo.Proxy;
using RANSA.MCIP.DTO.MaestrosMasivos.ClienteMasivo;
using RANSA.MCIP.ViewModel.MaestrosMasivos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ModuloPilotoSodexo.Agente.BL
{
    public class MaestrosMasivosBL
    {

        #region Carga Masivo Cliente

        public List<MasivoClienteViewModel> CargarDatosMasivoCliente(HttpPostedFileBase upload)
        {
            List<MasivoClienteViewModel> ListaMasivoClientes = new List<MasivoClienteViewModel>();
            var usuario = Helper.HelperCtrl.ObtenerUsuario();
            DataTable dtCargaMasivoCliente = new DataTable("MasivoCliente");
            bool hasHeader = true;
            try
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    using (var pck = new OfficeOpenXml.ExcelPackage())
                    {
                        using (var stream = upload.InputStream)
                        {
                            pck.Load(stream);
                        }
                        // Cargando los Datos --
                        var ws = pck.Workbook.Worksheets["Cliente"];
                        foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                        {
                            dtCargaMasivoCliente.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                        }
                        var startRow = hasHeader ? 2 : 1;
                        for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                        {
                            var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                            DataRow row = dtCargaMasivoCliente.Rows.Add();
                            foreach (var cell in wsRow)
                            {
                                row[cell.Start.Column - 1] = cell.Text;
                            }
                        }
                    }
                }

                foreach (DataRow ItemCliente in dtCargaMasivoCliente.Rows)
                {
                    var ocliente = new MasivoClienteViewModel();
                    ocliente.CodigoCliente = ItemCliente["Codigocliente"].ToString();
                    ocliente.Nombre = ItemCliente["Nombre"].ToString();
                    ocliente.IdPais = ItemCliente["Pais"].ToString();
                    ocliente.IdProvincia = ItemCliente["Provincia"].ToString();
                    ocliente.IdDepartamento = ItemCliente["Departamento"].ToString();
                    ocliente.IdDistrito = ItemCliente["Distrito"].ToString();
                    ocliente.Direccion = ItemCliente["Direccion"].ToString();
                    ocliente.FlagAnulacion = "0";
                    ocliente.CodigoTipoDocumento = ItemCliente["TipoDocumento"].ToString();
                    ocliente.CodigoCuenta = ItemCliente["Cuenta"].ToString();
                    ocliente.CodigoNegocio = ItemCliente["Negocio"].ToString();
                    ocliente.NumDocumento = ItemCliente["NroIdentifacion"].ToString();
                    ListaMasivoClientes.Add(ocliente);
                    // Paginacion Memory
                    //ListaResponse = ListaPedidoIndividualMasivo.Skip(Convert.ToInt32(PaginacionDTO.page) * 10).Take(10).ToList();
                }
            }
            catch (Exception)
            {
                ListaMasivoClientes = null;
            }
            return ListaMasivoClientes;
        }


        public ResponseClienteMasivoViewModel RegistraMasivoCliente(RequestMasivoClienteViewModel request)
        {
            var response = new ResponseClienteMasivoViewModel();
            try
            {
                //var requestAgentes = GR.Scriptor.Framework.Helper.MiMapper<RequestMasivoClienteViewModel, RequestClienteMasivoDTO>(request);
                var requestAgente = new RequestClienteMasivoDTO();
                requestAgente.ListaCliente = (from item in request.ListaCliente
                                              select GR.Scriptor.Framework.Helper.MiMapper<MasivoClienteViewModel, MasivoClienteDTO>(item)).ToList();
                var responseRegistroMasivoCliente = new MaestroMasivoProxyRest().RegistrarMasivoCliente(requestAgente);
                response.Result.Satisfactorio = responseRegistroMasivoCliente.Result.Satisfactorio;
                response.Result.Mensaje = responseRegistroMasivoCliente.Result.Mensaje;
            }
            catch (Exception ex)
            {
                response.Result = new RANSA.MCIP.DTO.Result { Satisfactorio = false };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AgenteServicios);
            }
            return response;
        }
        #endregion

    }
}