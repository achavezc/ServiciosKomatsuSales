using GR.Scriptor.Framework;
using ModuloPilotoSodexo.Proxy;
using RANSA.MCIP.DTO.MaestrosMasivos.AlmacenMasivo;
using RANSA.MCIP.DTO.MaestrosMasivos.ClienteMasivo;
using RANSA.MCIP.DTO.MaestrosMasivos.MaterialMasivo;
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

        #region Carga Masivo Material

        public List<MasivoMaterialViewModel> CargarDatosMasivoMaterial(HttpPostedFileBase upload)
        {
            List<MasivoMaterialViewModel> ListaMasivoMaterial = new List<MasivoMaterialViewModel>();
            var usuario = Helper.HelperCtrl.ObtenerUsuario();
            DataTable dtCargaMasivo = new DataTable("MasivoMaterial");
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
                        var ws = pck.Workbook.Worksheets["Material"];
                        foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                        {
                            dtCargaMasivo.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                        }
                        var startRow = hasHeader ? 2 : 1;
                        for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                        {
                            var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                            DataRow row = dtCargaMasivo.Rows.Add();
                            foreach (var cell in wsRow)
                            {
                                row[cell.Start.Column - 1] = cell.Text;
                            }
                        }
                    }
                }

                foreach (DataRow ItemCliente in dtCargaMasivo.Rows)
                {
                    var oMaterial = new MasivoMaterialViewModel();
                    oMaterial.CodigoMaterial = ItemCliente["CodigoMaterial"].ToString();
                    oMaterial.CodigoCuenta = ItemCliente["CodigoCuenta"].ToString();
                    oMaterial.Descripcion = ItemCliente["Descripcion"].ToString();
                    oMaterial.DescripcionBreve = ItemCliente["DescripcionBreve"].ToString();
                    oMaterial.CodigoUnidadMedidaBase = ItemCliente["CodigoUnidadMedidaBase"].ToString();
                    oMaterial.PesoBruto = string.IsNullOrEmpty(ItemCliente["PesoBruto"].ToString()) ? 0 : Convert.ToSingle(ItemCliente["PesoBruto"]);
                    oMaterial.PesoNeto = string.IsNullOrEmpty(ItemCliente["PesoNeto"].ToString()) ? 0 : Convert.ToSingle(ItemCliente["PesoNeto"]);
                    oMaterial.CodigoUnidadPeso = ItemCliente["CodigoUnidadPeso"].ToString();
                    oMaterial.Volumen = string.IsNullOrEmpty(ItemCliente["Volumen"].ToString()) ? 0 : Convert.ToSingle(ItemCliente["Volumen"]);
                    oMaterial.CodigoUnidadVolumen = ItemCliente["CodigoUnidadVolumen"].ToString();
                    oMaterial.Longitud = string.IsNullOrEmpty(ItemCliente["Longitud"].ToString()) ? 0 : Convert.ToSingle(ItemCliente["Longitud"]);
                    oMaterial.Ancho = string.IsNullOrEmpty(ItemCliente["Ancho"].ToString()) ? 0 : Convert.ToSingle(ItemCliente["Ancho"]);
                    oMaterial.Altura = string.IsNullOrEmpty(ItemCliente["Altura"].ToString()) ? 0 : Convert.ToSingle(ItemCliente["Altura"]);
                    oMaterial.UnidadesPorCaja = string.IsNullOrEmpty(ItemCliente["UnidadesXCaja"].ToString()) ? 0 : Convert.ToSingle(ItemCliente["UnidadesXCaja"]);
                    oMaterial.CajaXPallet = string.IsNullOrEmpty(ItemCliente["CajaXPallet"].ToString()) ? 0 : Convert.ToSingle(ItemCliente["CajaXPallet"]);
                    oMaterial.CajaXCama = string.IsNullOrEmpty(ItemCliente["CajaXCama"].ToString()) ? 0 : Convert.ToSingle(ItemCliente["CajaXCama"]);
                    oMaterial.CamaXPallet = string.IsNullOrEmpty(ItemCliente["CamaXPallet"].ToString()) ? 0 : Convert.ToSingle(ItemCliente["CamaXPallet"]);
                    ListaMasivoMaterial.Add(oMaterial);
                    // Paginacion Memory
                    //ListaResponse = ListaPedidoIndividualMasivo.Skip(Convert.ToInt32(PaginacionDTO.page) * 10).Take(10).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //ListaMasivoMaterial = null;
            }
            return ListaMasivoMaterial;
        }

        public ResponseMaterialMasivoViewModel RegistraMasivoMaterial(RequestMasivoMaterialViewModel request)
        {
            var response = new ResponseMaterialMasivoViewModel();
            try
            {
                var requestAgente = new RequestMaterialMasivoDTO();
                requestAgente.ListaMaterial = (from item in request.ListaMaterial
                                               select GR.Scriptor.Framework.Helper.MiMapper<MasivoMaterialViewModel, MasivoMaterialDTO>(item)).ToList();
                var responseRegistroMasivoMaterial = new MaestroMasivoProxyRest().RegistrarMasivoMaterial(requestAgente);
                response.Result.Satisfactorio = responseRegistroMasivoMaterial.Result.Satisfactorio;
                response.Result.Mensaje = responseRegistroMasivoMaterial.Result.Mensaje;
            }
            catch (Exception ex)
            {
                response.Result = new RANSA.MCIP.DTO.Result { Satisfactorio = false };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AgenteServicios);
            }
            return response;
        }

        #endregion

        #region Carga Masivo Almacen

        public List<MasivoAlmacenViewModel> CargarDatosMasivoAlmacen(HttpPostedFileBase upload)
        {
            List<MasivoAlmacenViewModel> ListaMasivoAlmacen = new List<MasivoAlmacenViewModel>();
            var usuario = Helper.HelperCtrl.ObtenerUsuario();
            DataTable dtCargaMasivo = new DataTable("MasivoAlmacen");
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
                        var ws = pck.Workbook.Worksheets["Almacen"];
                        foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                        {
                            dtCargaMasivo.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                        }
                        var startRow = hasHeader ? 2 : 1;
                        for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                        {
                            var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                            DataRow row = dtCargaMasivo.Rows.Add();
                            foreach (var cell in wsRow)
                            {
                                row[cell.Start.Column - 1] = cell.Text;
                            }
                        }
                    }
                }

                foreach (DataRow ItemCliente in dtCargaMasivo.Rows)
                {
                    var oAlamacen = new MasivoAlmacenViewModel();
                    oAlamacen.CodigoAlmacen = ItemCliente["CodigoAlmacen"].ToString();
                    oAlamacen.Nombre = ItemCliente["Nombre"].ToString();
                    oAlamacen.Direccion = ItemCliente["Direccion"].ToString();
                    oAlamacen.FlagAnulacion = "0";
                    oAlamacen.IdPais = ItemCliente["Pais"].ToString();
                    oAlamacen.IdDepartamento = ItemCliente["Departamento"].ToString();
                    oAlamacen.IdProvincia = ItemCliente["Provincia"].ToString();
                    oAlamacen.IdDistrito = ItemCliente["Distrito"].ToString();
                    oAlamacen.CodigoCuenta = ItemCliente["CodigoCuenta"].ToString();
                    oAlamacen.CodigoNegocio = ItemCliente["CodigoNegocio"].ToString();
                    ListaMasivoAlmacen.Add(oAlamacen);
                    // Paginacion Memory
                    //ListaResponse = ListaPedidoIndividualMasivo.Skip(Convert.ToInt32(PaginacionDTO.page) * 10).Take(10).ToList();
                }
            }
            catch (Exception)
            {
                ListaMasivoAlmacen = null;
            }
            return ListaMasivoAlmacen;
        }

        public ResponseAlmacenMasivoViewModel RegistraMasivoAlmacen(RequestMasivoAlmacenViewModel request)
        {
            var response = new ResponseAlmacenMasivoViewModel();
            try
            {
                var requestAgente = new RequestAlmacenMasivoDTO();
                requestAgente.ListaAlmacen = (from item in request.ListaAlmacen
                                              select GR.Scriptor.Framework.Helper.MiMapper<MasivoAlmacenViewModel, MasivoAlmacenDTO>(item)).ToList();
                var responseRegistroMasivoAlmacen = new MaestroMasivoProxyRest().RegistrarMasivoAlmacen(requestAgente);
                response.Result.Satisfactorio = responseRegistroMasivoAlmacen.Result.Satisfactorio;
                response.Result.Mensaje = responseRegistroMasivoAlmacen.Result.Mensaje;
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