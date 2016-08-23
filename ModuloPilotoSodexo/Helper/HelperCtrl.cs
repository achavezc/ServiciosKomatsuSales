using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using GR.Scriptor.Framework;
using GR.Scriptor.Msc.Memberships.Models;
using Viatecla.Factory.Scriptor;
using Viatecla.Factory.Scriptor.ModularSite.Models;
using System.Web.Mvc;
using GR.Scriptor.Frameworks.Comun;
using GR.Scriptor.Msc.Memberships;

namespace ModuloPilotoSodexo.Helper
{
    public class HelperCtrl
    {


        public static void GrabarLog(Exception ex, string titulo, PoliticaExcepcion politica)
        {
            ManejadorExcepciones.PublicarExcepcion(ex, politica);
        }
        public static RequestLogEvento ObtenerAtributosManejadorEventos(string Formulario, string NombreEvento, string nombreUsuario)
        {
            return new RequestLogEvento
            {
                NombreMaquina = GR.Scriptor.Framework.Helper.GetNombreMaquina(),
                DireccionIP = GR.Scriptor.Framework.Helper.LocalIPAddress(),
                NombreUsuario = nombreUsuario,
                Formulario = Formulario,
                NombreEvento = NombreEvento
            };
        }


        public static string ObtenerUsuario()
        {
            return ((ResponseUsuarioMscDTO)GR.Scriptor.Framework.Helper.GetSession("usuario")).Usuario.CodigoUsuario;
        }



        public static ContentResult ExportarExcel(dynamic listaRespuesta, dynamic listaResultadosGrilla, Guid idGrilla, string idColumna, string requestExportarexcel, HttpResponseBase Response, string tituloReporte)
        {
            //dynamic filtros = obj;

            //filtros.ColumnaOrden = columnaOrden;

            //filtros.TamanoPagina = 9999;
            //filtros.PaginaActual = 1;

            //ResponseConsultaPedidoDTO listaRespuesta = new Proxy.ProxyRest().ListarConsultaPedido(filtros);


            if (string.IsNullOrEmpty(requestExportarexcel))
            {
                int totalPages = int.Parse("" + Math.Ceiling(Convert.ToDouble(listaRespuesta.NroPagina) / 9999).ToString());
                var res = Grid.toJSONFormat2(listaResultadosGrilla, 1, listaRespuesta.NroPagina, totalPages, idColumna);
                ContentResult cr = new ContentResult();
                cr.Content = res;
                return cr;
            }
            else
            {
                List<ScriptorContent> columnasScriptor = ObtenerGrillaScriptor(idGrilla);
                if (columnasScriptor.Count > 0)
                {
                    String nombreReport = string.Format("Resumen_{0}{1}", tituloReporte.Replace(" ", ""), DateTime.Now.ToString("yyyy-MM-dd"));
                    List<ReportColumnHeader> columnas = new List<ReportColumnHeader>();
                    ScriptorContentInsert columnasResulta = (ScriptorContentInsert)columnasScriptor[0].Parts.columnas;
                    if (columnasResulta.Count > 0)
                    {
                        foreach (ScriptorContent contenido in columnasResulta)
                        {
                            string columnaId = contenido.Parts.IdColumna;
                            string nombre = contenido.Parts.Nombre;
                            string flgOculto = contenido.Parts.oculto;
                            columnas.Add(new ReportColumnHeader() { BindField = columnaId, HeaderName = nombre, FlgOculto = flgOculto });
                        }
                        ExportarExcelV2.List2Excel(Response, listaResultadosGrilla, tituloReporte, nombreReport, columnas);
                    }
                }
                return null;
            }


            return null;
        }
        private static List<ScriptorContent> ObtenerGrillaScriptor(Guid idGrilla)
        {
            List<ScriptorContent> ListaEstadosScriptor = new List<ScriptorContent>();
            Guid? idCanalGrilla = new Guid("69A1584C-D5EF-454F-8476-9F31A959B90A");
            ScriptorClient scriptorClient = Common.ScriptorClient;// new ScriptorClient(); //nuevo cliente para evitar uso de cache
            ScriptorChannel canalEstados = scriptorClient.GetChannel(idCanalGrilla.Value); //usar el nuevo cliente
            ListaEstadosScriptor = canalEstados.QueryContents("#Id", idGrilla, "=").ToList();
            return ListaEstadosScriptor;
        }

    }
}