using GR.Scriptor.Framework;
using ModuloPilotoSodexo.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viatecla.Factory.Scriptor;
using ModuloPilotoSodexo.Helper;
namespace ModuloPilotoSodexo.App_Start.Helper
{
    public class HelperWeb
    {

        public static void ExportarExcelDinamico(HttpResponseBase responsePage, string jsonListaResultado, string TituloReporte, List<ReportColumnHeader> columnas)
        {
            String nombreReport = string.Format("Resumen_{0}{1}", TituloReporte.Replace(" ", ""), DateTime.Now.ToString("yyyy-MM-dd"));

            DataTable DataTableListaResultado = GR.Scriptor.Framework.Helper.ConvertJsonArrayToDataTable(jsonListaResultado);
            GR.Scriptor.Frameworks.Comun.ExportarExcelV2.List2Excel(responsePage, DataTableListaResultado, "Resumen", nombreReport, columnas);
        }
        public static ContentResult ExportarExcel(HttpResponseBase responsePage, dynamic listaResultadosGrilla, Guid idGrilla)
        {

            ScriptorContent grillaScriptor = HelperBL.ObtenerGrillaScriptor(idGrilla);
            if (grillaScriptor != null)
            {
                String nombreReport = string.Format("Resumen_{0}", DateTime.Now.ToString("yyyy-MM-dd"));
                List<ReportColumnHeader> columnas = new List<ReportColumnHeader>();
                ScriptorContentInsert columnasResulta = (ScriptorContentInsert)grillaScriptor.Parts.columnas;
                if (columnasResulta.Count > 0)
                {
                    foreach (ScriptorContent contenido in columnasResulta)
                    {
                        string columnaId = contenido.Parts.IdColumna;
                        string nombre = contenido.Parts.Nombre;
                        columnas.Add(new ReportColumnHeader() { BindField = columnaId, HeaderName = nombre });
                    }
                    GR.Scriptor.Frameworks.Comun.ExportarExcelV2.List2Excel(responsePage, listaResultadosGrilla, "Resumen", nombreReport, columnas);
                }
            }
            return null;

        }

        public static string ListarDinamico(HttpRequestBase requestPage, HttpResponseBase responsePage, Object request, PaginacionDTO paginacionDTO, DatosListaDinamicaDTO datosListaDinamicaDTO)
        {
            string jsonRespuesta = null;
            JObject jsonLinq_paginacionDTO = GR.Scriptor.Framework.Helper.ConvertObjectToJObject(paginacionDTO);
            JObject jsonLinq_filtros = GR.Scriptor.Framework.Helper.ConvertObjectToJObject(request);

            string idGrilla = (string)jsonLinq_paginacionDTO["IdGrilla"];

            if (String.IsNullOrEmpty(idGrilla) == true)
            {
                jsonRespuesta = GR.Scriptor.Framework.Helper.ConvertObjectToJson(new { success = false, IdGrilla = "El Id de la Grilla es Nulo" });
            }
            else
            {
                string _ColumnaOrden = "";
                string _UrlServicio = "";
                string _TituloReporte = "";
                string _NombreCampoClaveRegistro = "";
                List<ReportColumnHeader> columnasGrillaReporte = new List<ReportColumnHeader>();
                HelperBL.ObtenerDatosGrillaScriptor(HttpContext.Current.Session["CodigoCliente"].ToString(), new Guid(idGrilla), out columnasGrillaReporte, out _UrlServicio, out _ColumnaOrden, out _TituloReporte, out _NombreCampoClaveRegistro);
                if (!String.IsNullOrEmpty(datosListaDinamicaDTO.NombreCampoClaveRegistro))
                    _NombreCampoClaveRegistro = datosListaDinamicaDTO.NombreCampoClaveRegistro;


                if (_UrlServicio == "")
                {
                    jsonRespuesta = GR.Scriptor.Framework.Helper.ConvertObjectToJson(new { success = false, IdGrilla = "La Url del Servicio esta vacio" });
                }
                else
                {
                    bool esExportacion = false;
                    if (!string.IsNullOrEmpty(requestPage.QueryString["export"]))
                    {
                        esExportacion = true;
                    }

                    if (esExportacion)
                    {
                        jsonLinq_filtros[datosListaDinamicaDTO.NombreCampoOrdenamiento] = _ColumnaOrden;
                        jsonLinq_filtros["TamanoPagina"] = 9999;
                        jsonLinq_filtros["PaginaActual"] = 1;


                        JObject json_listaRespuesta = JObject.Parse(new Proxy.ProxyRest().Execute(GR.Scriptor.Framework.Helper.ConvertObjectToJson(jsonLinq_filtros), _UrlServicio));
                        ExportarExcelDinamico(responsePage, GR.Scriptor.Framework.Helper.ConvertObjectToJson(json_listaRespuesta[datosListaDinamicaDTO.NombreObjetoLista]), _TituloReporte, columnasGrillaReporte);

                    }
                    else
                    {
                        string _ColumnaOrdenGrillaWeb = paginacionDTO.GetOrdenamiento();
                        jsonLinq_filtros[datosListaDinamicaDTO.NombreCampoOrdenamiento] = _ColumnaOrdenGrillaWeb;
                        if (string.IsNullOrEmpty(_ColumnaOrdenGrillaWeb))
                            jsonLinq_filtros[datosListaDinamicaDTO.NombreCampoOrdenamiento] = _ColumnaOrden;

                        jsonLinq_filtros["TamanoPagina"] = paginacionDTO.GetNroFilas();
                        jsonLinq_filtros["PaginaActual"] = paginacionDTO.GetNroPagina();
                        JObject json_listaRespuesta = JObject.Parse(new Proxy.ProxyRest().Execute(GR.Scriptor.Framework.Helper.ConvertObjectToJson(jsonLinq_filtros), _UrlServicio));

                        if (Convert.ToString(json_listaRespuesta["Result"]["Success"]) == "True")
                        {
                            int totalPages = 1;
                            int nroRegistros = 0;
                            if (String.IsNullOrEmpty(datosListaDinamicaDTO.NombreCampoNroRegistros) == false)
                                if (json_listaRespuesta[datosListaDinamicaDTO.NombreCampoNroRegistros] != null)
                                {
                                    nroRegistros = (int)json_listaRespuesta[datosListaDinamicaDTO.NombreCampoNroRegistros];
                                    totalPages = int.Parse("" + Math.Ceiling(Convert.ToDouble(nroRegistros) / paginacionDTO.GetNroFilas()).ToString());

                                }

                            var res = Helpers.Grid.toJSONFormatForJqGrid(GR.Scriptor.Framework.Helper.ConvertObjectToJson(json_listaRespuesta[datosListaDinamicaDTO.NombreObjetoLista]), paginacionDTO.GetNroPagina(), nroRegistros, totalPages, _NombreCampoClaveRegistro);
                            jsonRespuesta = res;

                        }
                        else
                        {

                            string errorDatos = "Error en la consulta al servicio";
                            jsonRespuesta = errorDatos;
                            new ManejadorLog().GrabarLog("REQUEST:" + jsonLinq_filtros.ToString());
                            new ManejadorLog().GrabarLog("RESPONSE:" + json_listaRespuesta.ToString());
                        }
                    }
                }
            }
            return jsonRespuesta;
        }

        public static ActionResult FiltrarContenidos(HttpRequestBase requestPage, HttpResponseBase responsePage, PaginacionDTO paginacionDTO, string filtrosJson)
        {
            List<string> arrayfiltros = new List<string>();
            arrayfiltros.Add("#id;00000000-0000-0000-0000-000000000000;<>");

            if (!String.IsNullOrEmpty(filtrosJson))
            {
                Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(filtrosJson);
                foreach (KeyValuePair<string, string> kvp in values)
                {
                    if (!String.IsNullOrEmpty(kvp.Value))
                    {
                        Guid guid = Guid.Empty;
                        if (Guid.TryParse(kvp.Value, out guid) == true)
                        {
                            arrayfiltros.Add(String.Format("{0};{1};like", kvp.Key, kvp.Value));
                        }
                        else
                        {
                            arrayfiltros.Add(String.Format("{0};{1};like", kvp.Key, "%" + kvp.Value + "%"));
                        }
                    }

                }
            }

            string _guid = Guid.NewGuid().ToString();
            string _ordenamiento = "";
            if (!String.IsNullOrEmpty(paginacionDTO.GetOrdenamiento()))
                _ordenamiento = "$$." + paginacionDTO.GetOrdenamiento();
            int? _desde = 0;
            int? _hasta = 99999;

            bool esExportacion = false;
            if (!string.IsNullOrEmpty(requestPage.QueryString["export"]))
            {
                esExportacion = true;
                paginacionDTO.HabilitarPaginacion = false;
            }
            else
                paginacionDTO.HabilitarPaginacion = true;

            if (paginacionDTO.HabilitarPaginacion == true)
            {
                if (paginacionDTO.page != null)
                    _desde = (paginacionDTO.page - 1) * paginacionDTO.GetNroFilas();

                _hasta = paginacionDTO.GetNroFilas();
            }
            //"/sistema/maestros/negocio"
            ActionResult respuestaConsulta = new HelperDataScriptor().QueryContents(paginacionDTO.RutaCanal, Guid.NewGuid(), arrayfiltros.ToArray(), _desde, _hasta, _ordenamiento);



            if (esExportacion)
            {
                JObject listaJqGrid = new JObject();
                JObject json_tmp = JObject.Parse(respuestaConsulta.ToJson());
                var jsonLinq = JArray.Parse(GR.Scriptor.Framework.Helper.ConvertObjectToJson(json_tmp["Data"]["rows"]));
                var srcArray = jsonLinq;

                var trgArray = new JArray();

                foreach (JObject row in srcArray.Children<JObject>())
                {
                    foreach (JProperty column in row.Properties())
                    {

                        if (column.Name == "cell")
                        {
                            // Only include JValue types
                            if (column.Value is JToken)
                            {
                                trgArray.Add(column.Value);
                            }
                        }
                    }


                }


                listaJqGrid.Add("rows", trgArray);

                string _ColumnaOrden = "";
                string _UrlServicio = "";
                string _TituloReporte = "";
                string _NombreCampoClaveRegistro = "";
                List<ReportColumnHeader> columnasGrillaReporte = new List<ReportColumnHeader>();
                HelperBL.ObtenerDatosGrillaScriptor(HttpContext.Current.Session["CodigoCliente"].ToString(), paginacionDTO.IdGrilla, out columnasGrillaReporte, out _UrlServicio, out _ColumnaOrden, out _TituloReporte, out _NombreCampoClaveRegistro);

                ExportarExcelDinamico(responsePage, GR.Scriptor.Framework.Helper.ConvertObjectToJson(listaJqGrid["rows"]), "ReporteListado", columnasGrillaReporte);
            }
            return respuestaConsulta;
        }
    }
}