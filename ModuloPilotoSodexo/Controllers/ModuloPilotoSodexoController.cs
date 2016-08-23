
using GR.Scriptor.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Viatecla.Factory.Scriptor.ModularSite.Models;
using GR.Scriptor.Msc.Memberships.Models;
using GR.Scriptor.Msc.Memberships;
using ModuloPilotoSodexo.Models;
using System.Web.Script.Serialization;
using System.Xml;
using System.Net;
using GR.Scriptor.Msc.Memberships.Agente.BL;
using Viatecla.Factory.Scriptor;
using GR.Scriptor.Msc.Memberships.Agente.Response;
using ModuloPilotoSodexo.Agente.BL;
using ModuloPilotoSodexo.Agente.DTO;
using ModuloPilotoSodexo.Helpers;
using System.Web.Security;
using ModuloPilotoSodexo.App_Start.Helper;
using System.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ModuloPilotoSodexo.Helper;
using GR.Scriptor.Frameworks.DTO;

namespace ModuloPilotoSodexo.Controllers
{
    public class ModuloPilotoSodexoController : Controller
    {

        #region "Carga Inicial"
        public ActionResult CargaInicialPedidos()
        {
            try
            {

                var vm = new ConsultaDocumentoViewModelPrincipal();
                vm.Provincias = HelperBL.Provincias();
                vm.Clientes = HelperBL.Clientes("Codigo");
                vm.CodigoProvincia = HelperBL.obtenerValorComboDefecto();
                vm.Paises = HelperBL.Paises();
                vm.CodigoPais = "1";
                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(vm));

            }
            catch (Exception ex)
            {
                (new ManejadorLog()).RegistrarEvento(MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region "Listados"
        public ActionResult ListarResumenPedido(RequestListarResumenPedidoDTO filtros, PaginacionDTO paginacionDTO)
        {
            string urlServicio = "";
            Session["CodigoCliente"] = filtros.CodigoCliente;
            if (paginacionDTO.IdGrilla == null || paginacionDTO.IdGrilla == new Guid())
            {
                return Json(new { success = false, IdGrilla = "El Id de la Grilla es Nulo" }, JsonRequestBehavior.AllowGet);
            }
            urlServicio = HelperBL.obtenerUrlServicio(paginacionDTO.IdGrilla, Session["CodigoCliente"].ToString());
            if (urlServicio == "")
            {
                return Json(new { success = false, IdGrilla = "La Url del Servicio esta vacio" }, JsonRequestBehavior.AllowGet);
            }
            ContentResult salidaJSON = null;
            if (TryUpdateModel(filtros) || 1 == 1)
            {
                ResponseListarResumenPedidoDTO listaRespuesta = new ResponseListarResumenPedidoDTO();
                listaRespuesta = new Proxy.ProxyRest().ListarResumenPedido(filtros, urlServicio);
                List<DatosListarResumenPedido> estados = HelperBL.ObtenerEstados();
                List<DatosListarResumenPedido> resultado = new List<DatosListarResumenPedido>();

                var query = (from listaResumen in listaRespuesta.ListarResumenPedido
                             join listaEstados in estados on listaResumen.Estado equals listaEstados.Estado into gj
                             from subpet in gj.DefaultIfEmpty()
                             select new { subpet.idEstado, listaResumen.Estado, listaResumen.Cantidad }).ToList();
                foreach (var datos in query)
                {
                    DatosListarResumenPedido estado = new DatosListarResumenPedido();
                    estado.idEstado = datos.idEstado;
                    estado.Estado = datos.Estado;
                    estado.Cantidad = datos.Cantidad;
                    resultado.Add(estado);
                }
                listaRespuesta.ListarResumenPedido = resultado;
                if (listaRespuesta.Result.Success == true)
                {
                    if (string.IsNullOrEmpty(Request.QueryString["export"]))
                    {
                        int totalPages = int.Parse("" + Math.Ceiling(Convert.ToDouble(listaRespuesta.NroPagina) / paginacionDTO.GetNroFilas()).ToString());
                        var res = Helpers.Grid.toJSONFormat2(listaRespuesta.ListarResumenPedido, paginacionDTO.GetNroPagina(), listaRespuesta.NroPagina, totalPages, "idEstado");
                        return Content(res);
                    }
                    else
                    {
                        String nombreReport = string.Format("Resumen_{0}", DateTime.Now.ToString("yyyy-MM-dd"));
                        GR.Scriptor.Frameworks.Comun.ExportarExcelV2.List2Excel(Response, listaRespuesta.ListarResumenPedido, "Resumen", nombreReport, new List<ReportColumnHeader>() { 
                                    new ReportColumnHeader(){ BindField="Estado", HeaderName="Estado"},
                                    new ReportColumnHeader(){ BindField="Cantidad", HeaderName="Cantidad"}                                  
                                });
                        return null;
                    }
                }
                else
                {
                    salidaJSON = Content(JsonExtensions.ToJson2(listaRespuesta));
                }
            }
            else
            {
                string cadena = string.Empty;
                var objetos = Helpers.Helper.GetErrorsFromModelState(ref cadena, ModelState);
                salidaJSON = Content(Helpers.Grid.emptyStrJSON(cadena, objetos));
            }
            return salidaJSON;
        }
        //public ActionResult GuardarContenido(string datosJson)
        //{
        //    bool resultado = false;
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    dynamic datos = js.Deserialize<dynamic>(datosJson);

        //    Guid? idGuidCanal = new Guid("6EA5ABE3-9979-41FD-B9C8-D26F4233B9C0");
        //    ScriptorClient scriptorClient = new ScriptorClient();
        //    ScriptorChannel canal = scriptorClient.GetChannel(idGuidCanal.Value);
        //    ScriptorContent contenido = null;


        //    ScriptorContent NuevoContenido = canal.NewContent();
        //    NuevoContenido.Parts.Title = "Titulo";
        //    NuevoContenido.Parts.Fecha = DateTime.Now;
        //    NuevoContenido.Title = "";
        //    resultado = NuevoContenido.Save();

        //    return null;
        //}
        public ActionResult GrabarContenidos(string filtrosJson, string idCanal, string idContenido)//RequestConsultaPedidoDTO filtros, PaginacionDTO paginacionDTO
        {
            Dictionary<string, object> lstColumnas = new Dictionary<string, object>();
            bool rspt = false;
            bool esNuevo = false;
            try
            {
                ScriptorClient scriptorClient = new ScriptorClient();
                lstColumnas = JsonConvert.DeserializeObject<Dictionary<string, object>>(filtrosJson);
                ScriptorChannel canalContenidoPedido = scriptorClient.GetChannel(new Guid(idCanal));

                if (String.IsNullOrEmpty(idContenido))
                {
                    esNuevo = true;
                }
                //obteniendo datos
                ScriptorContent ContenidoPedido = null;
                if (!esNuevo)
                    ContenidoPedido = canalContenidoPedido.Parent.QueryContents("#Id", idContenido, "=").ToList().FirstOrDefault();
                else
                    ContenidoPedido = canalContenidoPedido.Parent.NewContent();

                List<string> lstColumnasPartes = new List<string>();
                foreach (var objColumnas in ((Dictionary<string, object>.KeyCollection)(ContenidoPedido.Parts.Keys)))
                {
                    lstColumnasPartes.Add(objColumnas);
                }

                for (int i = 0; i < lstColumnasPartes.Count; i++)
                {
                    string nombreColumnaScriptor = lstColumnasPartes[i];
                    Object part = ContenidoPedido.Parts[nombreColumnaScriptor];
                    string tipo = part.GetType().ToString();
                    object valorEditado = lstColumnas[nombreColumnaScriptor];
                    if (tipo.ToUpper().Contains("STRING"))
                    {
                        part = valorEditado.ToString();
                    }
                    else if (tipo.Contains("ScriptorContentInsert"))
                    {
                        string tipoCriterio = ((Viatecla.Factory.Scriptor.ScriptorContentInsert)(part)).Field.ContentCriteria;
                        string valorEditadoAtributo = lstColumnas[nombreColumnaScriptor + "Atributo"].ToString();
                        Dictionary<string, object> lstColumnasAtributos = JsonConvert.DeserializeObject<Dictionary<string, object>>(valorEditadoAtributo);
                        string valorIdCanal = lstColumnasAtributos["IdCanal"].ToString();




                        switch (tipoCriterio)
                        {
                            case "specific":
                                ScriptorContentInsert contenInsert = (ScriptorContentInsert)part;

                                string arrayEditadoAtributo = lstColumnas[nombreColumnaScriptor].ToString();

                                ScriptorChannel canal = scriptorClient.GetChannel(new Guid(valorIdCanal));
                                JArray arrayColumnasAtributos = JArray.Parse(arrayEditadoAtributo);

                                foreach (var regItemArray in arrayColumnasAtributos)
                                {
                                    //verificar si existe, sino crea
                                    Guid idContenidoArray = new Guid(regItemArray["Id"].ToString());
                                    //ScriptorContent ContenidoItemGrabar = contenInsert.ContentInsert.ToList().Where(x => x.Id == idContenidoArray).ToList().FirstOrDefault();
                                    ScriptorContent ContenidoItemGrabar = contenInsert.ToList().Where(x => x.Id == idContenidoArray).ToList().FirstOrDefault();
                                    bool esNuevoItem = false;
                                    if (ContenidoItemGrabar == null)
                                    {
                                        ContenidoItemGrabar = canal.QueryContents("#Id", idContenidoArray, "=").ToList().FirstOrDefault();
                                        if (ContenidoItemGrabar == null)
                                        {
                                            ContenidoItemGrabar = canal.NewContent();
                                        }
                                        esNuevoItem = true;
                                    }
                                    //luego graba
                                    bool secambio = false;
                                    List<string> lstColumnasPartesArray = new List<string>();
                                    foreach (var objColumnas in ((Dictionary<string, object>.KeyCollection)(ContenidoItemGrabar.Parts.Keys)))
                                    {
                                        lstColumnasPartesArray.Add(objColumnas);
                                    }
                                    int nroCambios = 0;
                                    foreach (var objColumnasGrabar in lstColumnasPartesArray)
                                    {
                                        secambio = false;
                                        string _nombreColumnaScriptor = objColumnasGrabar;
                                        Object _part = ContenidoItemGrabar.Parts[_nombreColumnaScriptor];
                                        string _tipo = _part.GetType().ToString();
                                        object _valorEditado = regItemArray[_nombreColumnaScriptor];
                                        if (_tipo.ToUpper().Contains("STRING"))
                                        {
                                            if (ContenidoItemGrabar.Parts[_nombreColumnaScriptor] != _valorEditado.ToString())
                                            {
                                                _part = _valorEditado.ToString();
                                                secambio = true;
                                            }
                                        }
                                        if (secambio)
                                        {
                                            nroCambios++;
                                            ContenidoItemGrabar.Parts[_nombreColumnaScriptor] = _part;
                                        }
                                    }
                                    if (nroCambios > 0)
                                        if (esNuevoItem)
                                        {
                                            contenInsert.Add(ContenidoItemGrabar);
                                            //ContenidoItemGrabar.Save("create_publish");
                                        }
                                        else
                                        {
                                            //ContenidoItemGrabar.Save("alterar");
                                            //ContenidoItemGrabar//referenciado y modificado
                                        }

                                }
                                part = contenInsert;
                                break;
                            case "specific_dropdownlist":
                                {
                                    ScriptorContentInsert contenInsertDropDown = (ScriptorContentInsert)part;
                                    contenInsertDropDown.Clear();
                                    ScriptorChannel channel2 = scriptorClient.GetChannel(new Guid(valorIdCanal), null);
                                    ScriptorContent primerContenido = channel2.QueryContents("#Id", valorEditado.ToString(), "=", false).ToList().FirstOrDefault();
                                    if (primerContenido != null)
                                        contenInsertDropDown.Add(primerContenido);

                                    part = contenInsertDropDown;
                                }
                                break;
                        }

                    }
                    else if (tipo.Contains("ScriptorDropdownListValue"))
                    {
                        ScriptorChannel channel2 = Common.ScriptorClient.GetChannel(new Guid("FB963753-8F10-4607-9955-8E3E0492C1F4"), null);
                        ScriptorContent primerContenido = channel2.QueryContents("#Id", valorEditado.ToString(), "=", false).ToList().FirstOrDefault();
                        part = ScriptorDropdownListValue.FromContent(primerContenido);
                    }
                    ContenidoPedido.Parts[nombreColumnaScriptor] = part;
                }
                //fin obteniendo datos
                //grabando datos
                if (!esNuevo)
                {
                    rspt = ContenidoPedido.Save("alterar");
                    idContenido = idContenido;
                }
                else
                {
                    rspt = ContenidoPedido.Save("create_publish");
                    idContenido = Convert.ToString(ContenidoPedido.Id);
                }

            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.WebController);
                throw;
            }
            return Json(new
            {
                @Result = new Result()
                {
                    Success = true
                },
                Estado = "true",
                Mensaje = rspt,
                IdContenido = idContenido,
                ListaMensajes = new List<String>()
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EliminarContenidos(List<ScriptorEliminarElemento> ListaEliminar, string idCanal)//RequestConsultaPedidoDTO filtros, PaginacionDTO paginacionDTO
        {
            bool rspt = false;
            int nroregistros = 0;
            string mensaje = "";
            List<string> lstactualizados = new List<string>();
            try
            {
                nroregistros = ListaEliminar.Count;
                ScriptorChannel canalContenidoPedido = new ScriptorClient().GetChannel(new Guid(idCanal));



                List<ScriptorContent> lstContenidosEliminar = canalContenidoPedido.QueryContents("#Id", (from lst in ListaEliminar
                                                                                                         select lst.Id.ToString()).ToList(), "IN").ToList();
                rspt = true;
                foreach (ScriptorContent contenido in lstContenidosEliminar)
                {
                    string accion = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["accionEliminarWorkflow"]);
                    bool resultadoGrabado = contenido.Save(accion);
                    lstactualizados.Add(contenido.Id + "-" + resultadoGrabado);
                    if (resultadoGrabado == false)
                        rspt = false;
                }

            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.WebController);
                mensaje = ex.InnerException + "-" + ex.Message;
            }
            return Json(new
            {
                @Result = new Result()
                    {
                        Success = rspt
                    },
                Estado = rspt,
                Mensaje = "Se encontraros " + nroregistros + " registros",
                ListaMensajes = mensaje + "-" + lstactualizados
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListarContenidos(PaginacionDTO paginacionDTO, string filtrosJson)//RequestConsultaPedidoDTO filtros, PaginacionDTO paginacionDTO
        {
            return HelperWeb.FiltrarContenidos(Request, Response, paginacionDTO, filtrosJson);
        }

        public ActionResult ListarConsultaPedido(RequestConsultaPedidoDTO filtros, PaginacionDTO paginacionDTO)
        {
            return Content(HelperWeb.ListarDinamico(Request, Response, filtros, paginacionDTO, new DatosListaDinamicaDTO("ListarConsultaPedido", "NroRegistro", "nroPagina", "ColumnaOrden")));
        }
        public ActionResult BusquedaAvanzada(RequestConsultaAvanzadaPedidoDTO filtros, PaginacionDTO paginacionDTO)
        {
            return Content(HelperWeb.ListarDinamico(Request, Response, filtros, paginacionDTO, new DatosListaDinamicaDTO("ConsultaAvanzadaPedidosList", "NumeroPedido", "NroPagina", "ColumnaOrden")));
        }
        public ActionResult ListarDetallePedido(RequestConsultaDetallePedidoDTO filtros, PaginacionDTO paginacionDTO)
        {
            return Content(HelperWeb.ListarDinamico(Request, Response, filtros, paginacionDTO, new DatosListaDinamicaDTO("ListarDetallePedido", "NroRegistro", "NroPagina")));
        }
        public ActionResult ListarGuiaRemision(RequestConsultaGuiaRemisionDTO filtros, PaginacionDTO paginacionDTO)
        {
            return Content(HelperWeb.ListarDinamico(Request, Response, filtros, paginacionDTO, new DatosListaDinamicaDTO("ConsultaGuiaRemision", "NroRegistro", "NroPagina")));
        }
        public ActionResult ListarDetalleGuiaRemision(RequestDetalleGuiaRemisionDTO filtros, PaginacionDTO paginacionDTO)
        {
            return Content(HelperWeb.ListarDinamico(Request, Response, filtros, paginacionDTO, new DatosListaDinamicaDTO("ListarDetalleGuiaRemision", "NroItem", "NroPagina")));
        }

        public ActionResult BusquedaInventarios(RequestConsultaInventarioDTO filtros, PaginacionDTO paginacionDTO)
        {
            return Content(HelperWeb.ListarDinamico(Request, Response, filtros, paginacionDTO, new DatosListaDinamicaDTO("ListaInventario", "NroRegistro", "NroPagina", "ColumnaOrden")));
        }


        //public ActionResult BuscarScriptor(RequestConsultaAvanzadaPedidoDTO filtros, PaginacionDTO paginacionDTO)
        //{
        //    return Content(BuscarScriptor_Aux(Request, Response, filtros, paginacionDTO, new DatosListaDinamicaDTO("ConsultaAvanzadaPedidosList", "NumeroPedido", "NroPagina", "ColumnaOrden")));
        //}


        #endregion

        #region "Secciones de las pantallas"

        public ActionResult ObtenerCabeceraPedido(RequestConsultaCabeceraPedidoDTO filtros, PaginacionDTO paginacionDTO)
        {
            string urlServicio = "";
            if (paginacionDTO.IdGrilla == null || paginacionDTO.IdGrilla == new Guid())
            {
                return Json(new { success = false, IdGrilla = "El Id de la Grilla es Nulo" }, JsonRequestBehavior.AllowGet);
            }
            urlServicio = HelperBL.obtenerUrlServicioFormulario(paginacionDTO.IdGrilla);
            if (urlServicio == "")
            {
                return Json(new { success = false, IdGrilla = "La Url del Servicio esta vacio" }, JsonRequestBehavior.AllowGet);
            }
            ContentResult salidaJSON = null;
            if (TryUpdateModel(filtros) || 1 == 1)
            {

                ResponseConsultaCabeceraPedidoDTO listaRespuesta = new Proxy.ProxyRest().ObtenerCabeceraPedido(filtros, urlServicio);
                return Json(listaRespuesta, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string cadena = string.Empty;
                var objetos = Helpers.Helper.GetErrorsFromModelState(ref cadena, ModelState);
                salidaJSON = Content(Helpers.Grid.emptyStrJSON(cadena, objetos));
            }
            return salidaJSON;
        }

        public ActionResult ObtenerCabeceraDetallePedido(RequestCabeceraItemPedidoDTO filtros, PaginacionDTO paginacionDTO)
        {
            string urlServicio = "";
            if (paginacionDTO.IdGrilla == null || paginacionDTO.IdGrilla == new Guid())
            {
                return Json(new { success = false, IdGrilla = "El Id de la Grilla es Nulo" }, JsonRequestBehavior.AllowGet);
            }
            urlServicio = HelperBL.obtenerUrlServicioFormulario(paginacionDTO.IdGrilla);
            if (urlServicio == "")
            {
                return Json(new { success = false, IdGrilla = "La Url del Servicio esta vacio" }, JsonRequestBehavior.AllowGet);
            }
            ContentResult salidaJSON = null;
            if (TryUpdateModel(filtros) || 1 == 1)
            {
                ResponseCabeceraItemPedidoDTO listaRespuesta = new Proxy.ProxyRest().ObtenerCabeceraDetallePedido(filtros, urlServicio);
                return Json(listaRespuesta, JsonRequestBehavior.AllowGet);

            }
            else
            {
                string cadena = string.Empty;
                var objetos = Helpers.Helper.GetErrorsFromModelState(ref cadena, ModelState);
                salidaJSON = Content(Helpers.Grid.emptyStrJSON(cadena, objetos));
            }
            return salidaJSON;
        }

        public ActionResult ObtenerGuiaRemision(RequestConsultaCabeceraGuiaRemisionDTO filtros, PaginacionDTO paginacionDTO)
        {
            string urlServicio = "";
            if (paginacionDTO.IdGrilla == null || paginacionDTO.IdGrilla == new Guid())
            {
                return Json(new { success = false, IdGrilla = "El Id de la Grilla es Nulo" }, JsonRequestBehavior.AllowGet);
            }
            urlServicio = HelperBL.obtenerUrlServicioFormulario(paginacionDTO.IdGrilla);
            // urlServicio = "http://10.72.13.42/WS_SGL/SeguimientoPedidoServicio.svc/SeguimientoPedido/ObtenerGuiaRemision";
            if (urlServicio == "")
            {
                return Json(new { success = false, IdGrilla = "La Url del Servicio esta vacio" }, JsonRequestBehavior.AllowGet);
            }

            ContentResult salidaJSON = null;
            if (TryUpdateModel(filtros) || 1 == 1)
            {
                ResponseConsultaCabeceraGuiaRemisionDTO listaRespuesta = new Proxy.ProxyRest().ObtenerGuiaRemision(filtros, urlServicio);
                return Json(listaRespuesta, JsonRequestBehavior.AllowGet);

            }
            else
            {
                string cadena = string.Empty;
                var objetos = Helpers.Helper.GetErrorsFromModelState(ref cadena, ModelState);
                salidaJSON = Content(Helpers.Grid.emptyStrJSON(cadena, objetos));
            }
            return salidaJSON;
        }


        public ActionResult BusquedaClientes(PaginacionDTO paginacionDTO, string busquedaClientes)
        {
            ClientesBL bl = new ClientesBL();
            List<BusquedaClientesDTO> lstBusquedaClientes = bl.BusquedaClientes(busquedaClientes);
            ResponseUsuarioMscDTO usuario = Helpers.Helper.GetUsuario();
            lstBusquedaClientes = lstBusquedaClientes.FindAll(x => usuario.GrupoClientesPermitidos.Exists(y => y == x.NombreGrupo));


            if (!string.IsNullOrEmpty(Request.QueryString["export"]))
            {
                return HelperWeb.ExportarExcel(Response, lstBusquedaClientes, paginacionDTO.IdGrilla);
            }
            else
            {
                int totalPages = 1;
                var res = Helpers.Grid.toJSONFormat2(lstBusquedaClientes, 1, lstBusquedaClientes.Count, 1000, "CodigoCliente");
                return Content(res);
            }
        }
        public ActionResult ListarConsultaClientes(PaginacionDTO paginacionDTO)
        {
            List<Clientes> clientes = HelperBL.Clientes("GrupoCliente");
            ResponseConsultaClienteDTO listaRespuesta = new ResponseConsultaClienteDTO();
            listaRespuesta.ListarConsultaCliente = clientes;
            listaRespuesta.nroPagina = listaRespuesta.ListarConsultaCliente.Count;
            Result resultado = new Result();
            resultado.Success = true;
            listaRespuesta.Result = resultado;

            if (!string.IsNullOrEmpty(Request.QueryString["export"]))
            {
                return HelperWeb.ExportarExcel(Response, listaRespuesta.ListarConsultaCliente, paginacionDTO.IdGrilla);
            }
            ContentResult salidaJSON = null;
            if (listaRespuesta.Result.Success == true)
            {
                if (string.IsNullOrEmpty(Request.QueryString["export"]))
                {
                    int totalPages = int.Parse("" + Math.Ceiling(Convert.ToDouble(listaRespuesta.nroPagina) / paginacionDTO.GetNroFilas()).ToString());
                    var res = Helpers.Grid.toJSONFormat2(listaRespuesta.ListarConsultaCliente, paginacionDTO.GetNroPagina(), listaRespuesta.nroPagina, totalPages, "Codigo");
                    return Content(res);
                }
            }
            else
            {
                if (listaRespuesta.ListarConsultaCliente.Count <= 0)
                {
                    listaRespuesta.ListarConsultaCliente = new List<Clientes>();
                }
                salidaJSON = Content(JsonExtensions.ToJson2(listaRespuesta));
            }
            return salidaJSON;
        }


        #endregion

        #region "Prueba de concepto"



        public ActionResult Test()
        {
            Scriptor.scrEdit objScriptor = new Scriptor.scrEdit(System.Configuration.ConfigurationManager.AppSettings["Viatecla.Factory.Scriptor.ConnectionString"].ToString(), "anonimo", String.Empty, "/scrEdit.log");
            XmlNode nodeResult = objScriptor.getContentViewXML("6EA5ABE3-9979-41FD-B9C8-D26F4233B9C0", "CDA200AD-EEF7-456F-B7A4-6E29E5B7D57E", "pt", "1");
            XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(nodeResult.InnerXml));
            List<Dictionary<string, string>> propiedadesContenidos = new List<Dictionary<string, string>>();
            #region
            while (reader.Read())
            {
                var idCampo = reader.GetAttribute("id");
                var tipo = reader.GetAttribute("field_type");
                var nombre = reader.GetAttribute("name");
                var descripcion = reader.GetAttribute("txt_description");
                var valoresCombo = reader.GetAttribute("txt_content_field_list");
                var valorDefecto = reader.GetAttribute("txt_default_value");
                var cantidadCaracteres = reader.GetAttribute("n_db_size");
                var Orden = reader.GetAttribute("n_order");
                if (reader.NodeType.ToString() != "EndElement")
                {
                    Dictionary<string, string> propiedadesContenido = new Dictionary<string, string>();
                    if (idCampo != null)
                        propiedadesContenido.Add("idCampo", idCampo);
                    if (tipo != null)
                        propiedadesContenido.Add("tipo", tipo);
                    if (nombre != null)
                        propiedadesContenido.Add("nombre", nombre);
                    if (descripcion != null)
                        propiedadesContenido.Add("descripcion", descripcion);
                    if (valoresCombo != null)
                        propiedadesContenido.Add("valoresCombo", valoresCombo);
                    if (valorDefecto != null)
                        propiedadesContenido.Add("cantidadCaracteres", cantidadCaracteres);
                    if (Orden != null)
                        propiedadesContenido.Add("Orden", Orden);
                    if (propiedadesContenido.Count > 0)
                        propiedadesContenidos.Add(propiedadesContenido);
                }
            }
            #endregion

            if (propiedadesContenidos.Count > 0)
            {
                foreach (Dictionary<string, string> item in propiedadesContenidos)
                {
                    if (item["tipo"] == "title" || item["tipo"] == "textline")
                    {
                        //Textbox Input
                    }
                    if (item["tipo"] == "dropdownlist")
                    {
                        //Combobox Combobox 
                    }
                    if (item["tipo"] == "html")
                    {
                        //Editor HTML
                    }
                }
            }
            return null;

        }



        #endregion

    }
}
