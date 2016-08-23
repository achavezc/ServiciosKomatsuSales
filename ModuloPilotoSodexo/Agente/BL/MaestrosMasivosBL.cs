using GR.Scriptor.Framework;
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
                        var CantidadWS = pck.Workbook.Worksheets.Count();
                        // Cargando los Datos --
                        for (int i = 1; i <= CantidadWS; i++)
                        {
                            var ws = pck.Workbook.Worksheets[i];
                            DataTable tbl = new DataTable(ws.Name);
                            foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                            {
                                tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                            }
                            var startRow = hasHeader ? 2 : 1;
                            for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                            {
                                var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                                DataRow row = tbl.Rows.Add();
                                foreach (var cell in wsRow)
                                {
                                    row[cell.Start.Column - 1] = cell.Text;
                                }
                            }
                        }
                    }
                }

                foreach (DataRow ItemCliente in dtCargaMasivoCliente.Rows)
                {
                    var ocliente = new MasivoClienteViewModel();
                    ocliente.CodigoCliente = ItemCliente[""].ToString();
                    ocliente.Nombre = ItemCliente[""].ToString();
                    ocliente.IdPais = ItemCliente[""].ToString();
                    ocliente.IdDepartamento = ItemCliente[""].ToString();
                    ocliente.IdProvincia = ItemCliente[""].ToString();
                    ocliente.IdDistrito = ItemCliente[""].ToString();
                    ocliente.Direccion = ItemCliente[""].ToString();
                    ocliente.FlagAnulacion = ItemCliente[""].ToString();
                    ocliente.CodigoTipoDocumento = ItemCliente[""].ToString();
                    ocliente.NumDocumento = ItemCliente[""].ToString();
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
                var ListRequesCliente = new List<MasivoClienteViewModel>();
                //foreach (var item in request.ListaCargaMasiva)
                //{
                //    Mapper.CreateMap<DetallePedidoViewModel, DetallePedidoDTO>();
                //    var requestAgente = GR.Scriptor.Framework.Helper.MiMapper<RequestRegistroPedidoIndividualViewModel, RequestRegistroPedidoIndividualDTO>(item);
                //    ListRequesAgente.Add(requestAgente);
                //}
                //var responseRegistroMasivoPedidoDto = new PedidoProxyRest().RegistrarPedidoMasivo(ListRequesAgente);

                //response.Result.Satisfactorio = responseRegistroMasivoPedidoDto.Result.Satisfactorio;
                //response.Result.Mensaje = responseRegistroMasivoPedidoDto.Result.Mensaje;
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