using GR.Scriptor.Framework;
using GR.Scriptor.Msc.Memberships.Models;
using ModuloPilotoSodexo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Viatecla.Factory.Scriptor;
using Viatecla.Factory.Scriptor.ModularSite.Models;

namespace ModuloPilotoSodexo.App_Start.Helper
{
    public static class HelperBL
    {
        #region "Metodos  Auxiliares"
        public static List<DatosListarResumenPedido> ObtenerEstados()
        {
            List<DatosListarResumenPedido> estados = new List<DatosListarResumenPedido>();
            List<ScriptorContent> ListaEstadosScriptor = new List<ScriptorContent>();
            Guid? idCanalEstado = new Guid("03AFB5D3-5003-4DE9-B063-00C54C6EBA9D");
            ScriptorClient scriptorClient = Common.ScriptorClient;// new ScriptorClient(); //nuevo cliente para evitar uso de cache
            ScriptorChannel canalEstados = scriptorClient.GetChannel(idCanalEstado.Value); //usar el nuevo cliente
            ListaEstadosScriptor = canalEstados.QueryContents("#Id", Guid.NewGuid(), "<>").ToList();
            if (ListaEstadosScriptor.Count > 0)
            {
                foreach (ScriptorContent contenido in ListaEstadosScriptor)
                {
                    DatosListarResumenPedido estado = new DatosListarResumenPedido();
                    estado.idEstado = int.Parse(contenido.Parts.Codigo);
                    estado.Estado = contenido.Parts.Descripcion;
                    estados.Add(estado);
                }
            }


            return estados;
        }
        public static ScriptorContent ObtenerGrillaScriptor(Guid idGrilla)
        {
            ScriptorContent salida = null;
            List<ScriptorContent> ListaEstadosScriptor = new List<ScriptorContent>();
            Guid? idCanalGrilla = new Guid("69A1584C-D5EF-454F-8476-9F31A959B90A");
            ScriptorClient scriptorClient = Common.ScriptorClient;// new ScriptorClient(); //nuevo cliente para evitar uso de cache
            ScriptorChannel canalEstados = scriptorClient.GetChannel(idCanalGrilla.Value); //usar el nuevo cliente
            ListaEstadosScriptor = canalEstados.QueryContents("#Id", idGrilla, "=").ToList();
            if (ListaEstadosScriptor.Count == 1)
                salida = ListaEstadosScriptor[0];
            return salida;
        }
        public static string ObtenerCampoOrdenDefault(Guid idGrilla)
        {
            string obtenerColumnaOrden = "";
            List<ScriptorContent> ListaEstadosScriptor = new List<ScriptorContent>();
            Guid? idCanalGrilla = new Guid("69A1584C-D5EF-454F-8476-9F31A959B90A");
            ScriptorClient scriptorClient = Common.ScriptorClient;// new ScriptorClient(); //nuevo cliente para evitar uso de cache
            ScriptorChannel canalEstados = scriptorClient.GetChannel(idCanalGrilla.Value); //usar el nuevo cliente
            ListaEstadosScriptor = canalEstados.QueryContents("#Id", new Guid(), "<>").QueryContents("#Id", idGrilla, "=").ToList();
            if (ListaEstadosScriptor.Count > 0)
            {
                ScriptorContentInsert columnasResulta = (ScriptorContentInsert)ListaEstadosScriptor[0].Parts.columnas;
                if (columnasResulta.Count > 0)
                {
                    foreach (ScriptorContent contenido in columnasResulta)
                    {

                        string ordenDefecto = contenido.Parts.OrdenDefecto;
                        if (ordenDefecto == "1")
                        {
                            obtenerColumnaOrden = contenido.Parts.IdColumna;
                            break;
                        }
                    }
                }
            }
            return obtenerColumnaOrden;
        }

        public static List<Provincias> Provincias()
        {
            List<Provincias> provincias = new List<Provincias>();
            List<ScriptorContent> ListaProvinciasScriptor = new List<ScriptorContent>();
            var usuario = Helpers.Helper.GetUsuario();
            JavaScriptSerializer js = new JavaScriptSerializer();
            if (usuario != null)
            {
                List<string> ListaCodigosProvincias = usuario.ProvinciasPermitidas; //obtner una lista de Guid para passar a QueryContents    
                Guid? idCanalProvincia = new Guid("11B8D0DC-2616-419A-8EC9-C0B5EFA628C4");
                ScriptorClient scriptorClient = Common.ScriptorClient;// new ScriptorClient(); //nuevo cliente para evitar uso de cache
                ScriptorChannel canalProvincias = scriptorClient.GetChannel(idCanalProvincia.Value); //usar el nuevo cliente
                ListaProvinciasScriptor = canalProvincias.QueryContents("Codigo", ListaCodigosProvincias, "IN").ToList();//.OrderByDescending(c=> c.Parts.ColumnaDefecto).ToList();
                if (ListaProvinciasScriptor.Count > 0)
                {
                    foreach (ScriptorContent contenido in ListaProvinciasScriptor)
                    {
                        Provincias prov = new Provincias();
                        prov.Codigo = contenido.Parts.Codigo;
                        prov.Descripcion = contenido.Parts.Descripcion;
                        provincias.Add(prov);
                    }
                }
            }

            return provincias;
        }
        public static List<Paises> Paises()
        {
            List<Paises> paises = new List<Paises>();
            Paises pais = new Paises();
            pais.Codigo = "1";
            pais.Descripcion = "Perú";
            paises.Add(pais);

            return paises;
        }
        public static List<Clientes> Clientes(string CampoFiltro)
        {

            List<Clientes> clientes = new List<Clientes>();
            List<ScriptorContent> ListaClientesScriptor = new List<ScriptorContent>();
            var usuario = Helpers.Helper.GetUsuario();
            if (usuario != null)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string codigoFiltro = usuario.Usuario.Alias; //obtner una lista de Guid para passar a QueryContents 

                Guid? idCanalClientes = new Guid("84843A17-EFFD-42B6-B97C-8540BD3183EE");
                ScriptorClient scriptorClient = Common.ScriptorClient;// new ScriptorClient(); //nuevo cliente para evitar uso de cache

                ScriptorChannel canalClientes = scriptorClient.GetChannel(idCanalClientes.Value); //usar el nuevo cliente
                if (CampoFiltro == "GrupoCliente")
                {
                    codigoFiltro = obtenerIdGrupoCliente(codigoFiltro);
                }
                ListaClientesScriptor = canalClientes.QueryContents(CampoFiltro, codigoFiltro, "=").ToList();
                if (ListaClientesScriptor.Count > 0)
                {
                    foreach (ScriptorContent contenido in ListaClientesScriptor)
                    {
                        Clientes cliente = new Clientes();
                        cliente.Codigo = contenido.Parts.Codigo;
                        cliente.Descripcion = contenido.Parts.Descripcion;
                        clientes.Add(cliente);
                    }
                }
            }
            return clientes;
        }
        public static string obtenerIdGrupoCliente(string codigoGrupoCliente)
        {
            string idGrupoCliente = "";
            List<ScriptorContent> ListaGrupoClientesScriptor = new List<ScriptorContent>();
            Guid? idCanalGrupoClientes = new Guid("475077F2-4D02-4045-8FC5-84C4EF6135C6");
            ScriptorClient scriptorClient = Common.ScriptorClient;// new ScriptorClient(); //nuevo cliente para evitar uso de cache
            ScriptorChannel canaGrupoClientes = scriptorClient.GetChannel(idCanalGrupoClientes.Value); //usar el nuevo cliente
            ListaGrupoClientesScriptor = canaGrupoClientes.QueryContents("Codigo", codigoGrupoCliente, "=").ToList();
            if (ListaGrupoClientesScriptor.Count > 0)
            {
                ScriptorContent contenido = ListaGrupoClientesScriptor[0];
                idGrupoCliente = contenido.Id.ToString();
            }
            return idGrupoCliente;
        }
        public static Clientes obtenerClientePorId(string codigoCliente)
        {
            Clientes cliente = new Clientes();
            List<ScriptorContent> ListaClientesScriptor = new List<ScriptorContent>();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Guid? idCanalClientes = new Guid("84843A17-EFFD-42B6-B97C-8540BD3183EE");
            ScriptorClient scriptorClient = Common.ScriptorClient;// new ScriptorClient(); //nuevo cliente para evitar uso de cache
            ScriptorChannel canalClientes = scriptorClient.GetChannel(idCanalClientes.Value); //usar el nuevo cliente
            ListaClientesScriptor = canalClientes.QueryContents("Codigo", codigoCliente, "=").ToList();
            if (ListaClientesScriptor.Count > 0)
            {
                ScriptorContent contenido = ListaClientesScriptor[0];
                cliente.Codigo = contenido.Parts.Codigo;
                cliente.Descripcion = contenido.Parts.Codigo;
                cliente.CodigoGrupoCentroDistribucion = contenido.Parts.GrupoCentroDistribucion.Content.Parts.Codigo;
                cliente.CodigoGrupoCliente = contenido.Parts.GrupoCliente.Content.Parts.Codigo;
            }
            return cliente;
        }
        public static ScriptorContent obtenerGrupoCentroDistribucion(string codigoGrupoCliente)
        {
            ScriptorContent grupoCD = null;
            List<ScriptorContent> ListaGrupoCentroDistribucionScriptor = new List<ScriptorContent>();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Guid? idCanalGrupoClientes = new Guid("A598CA04-0464-4250-B9F8-185E268C44D4");
            ScriptorClient scriptorClient = Common.ScriptorClient;// new ScriptorClient(); //nuevo cliente para evitar uso de cache
            ScriptorChannel canalClientes = scriptorClient.GetChannel(idCanalGrupoClientes.Value); //usar el nuevo cliente
            ListaGrupoCentroDistribucionScriptor = canalClientes.QueryContents("Codigo", codigoGrupoCliente, "=").ToList();
            if (ListaGrupoCentroDistribucionScriptor.Count > 0)
            {
                grupoCD = ListaGrupoCentroDistribucionScriptor[0];
            }
            return grupoCD;
        }
        public static Dictionary<string, string> obtenerUrlServicios(string idCliente, out string CodigoGrupoCentroDistribucion)
        {
            Dictionary<string, string> listasUrlsAsociadad = new Dictionary<string, string>();
            Clientes cliente = obtenerClientePorId(idCliente);
            CodigoGrupoCentroDistribucion = "";
            if (cliente != null)
            {
                CodigoGrupoCentroDistribucion = cliente.CodigoGrupoCentroDistribucion;
                ScriptorContent grupoCliente = obtenerGrupoCentroDistribucion(cliente.CodigoGrupoCentroDistribucion);

                if (grupoCliente != null)
                {
                    string tipoAmbiente = grupoCliente.Parts.Ambiente.Content.Parts.Codigo;

                    ScriptorContentInsert urlsAsociadas = grupoCliente.Parts.UrlsAsociadas;
                    foreach (ScriptorContent contenido in urlsAsociadas)
                    {
                        switch (tipoAmbiente)
                        {
                            case "PRD":
                                listasUrlsAsociadad.Add(contenido.Parts.NombreUrl, contenido.Parts.Url);
                                break;
                            case "DEV":
                                listasUrlsAsociadad.Add(contenido.Parts.NombreUrl, contenido.Parts.UrlDev);
                                break;
                            case "QA":
                                listasUrlsAsociadad.Add(contenido.Parts.NombreUrl, contenido.Parts.UrlQa);
                                break;
                        }
                    }
                }
            }
            return listasUrlsAsociadad;
        }
        public static string obtenerUrlServicio(Guid idGrilla, string idcliente = "")
        {
            ScriptorContent grilla = ObtenerGrillaScriptor(idGrilla);
            return obtenerUrlServicio_aux(grilla, idcliente);
        }
        public static string obtenerUrlServicio_aux(ScriptorContent grilla, string idcliente = "")
        {
            string UrlServicio = "";
            ResponseUsuarioMscDTO usuario = Helpers.Helper.GetUsuario();

            if (grilla != null)
            {
                string idTipoUrlUtilizar = grilla.Parts.UrlUtilizar.Value;
                if (!String.IsNullOrEmpty(idTipoUrlUtilizar))
                {
                    Guid idTipoUrl = new Guid(idTipoUrlUtilizar);
                    string nombreUrlUtilizar = ObtenerNombreUrlUtilizarPorTipo(idTipoUrl);

                    try
                    {
                        if (usuario != null)
                        {
                            Dictionary<string, string> listaUrls;
                            if (usuario.UrlServicios.Count == 0)
                            {
                                string CodigoGrupoCentroDistribucion = "";
                                listaUrls = HelperBL.obtenerUrlServicios(idcliente, out CodigoGrupoCentroDistribucion);
                            }
                            else
                                listaUrls = usuario.UrlServicios;

                            if (listaUrls != new Dictionary<string, string>())
                            {
                                if (!String.IsNullOrEmpty(listaUrls[nombreUrlUtilizar]))
                                {
                                    UrlServicio = listaUrls[nombreUrlUtilizar];
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        (new ManejadorLog()).RegistrarEvento(MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);
                    }
                }
            }
            return UrlServicio;
        }
        public static string ObtenerNombreUrlUtilizarPorTipo(Guid idTipoUtilizar)
        {
            string nombreUrlUtilizar = "";
            List<ScriptorContent> ListaTipoUrlScriptor = new List<ScriptorContent>();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Guid? idCanalTipoUrl = new Guid("43372FD4-C3DF-40E0-BD16-258F775EE00D");
            ScriptorClient scriptorClient = Common.ScriptorClient;// new ScriptorClient(); //nuevo cliente para evitar uso de cache
            ScriptorChannel canalTipoUrl = scriptorClient.GetChannel(idCanalTipoUrl.Value); //usar el nuevo cliente
            ListaTipoUrlScriptor = canalTipoUrl.QueryContents("#Id", idTipoUtilizar, "=").ToList();
            if (ListaTipoUrlScriptor.Count > 0)
            {
                ScriptorContent contenido = ListaTipoUrlScriptor[0];
                nombreUrlUtilizar = contenido.Parts.Descripcion;
            }
            return nombreUrlUtilizar;
        }
        public static string obtenerUrlServicioFormulario(Guid idGrilla)
        {
            string urlServicio = "";
            string NombreurlServicio = ObtenerNombreUrlUtilizarPorTipo(idGrilla);
            if (NombreurlServicio != "")
            {
                var usuario = Helpers.Helper.GetUsuario();
                if (usuario != null)
                {
                    Dictionary<string, string> listaUrls = new Dictionary<string, string>();
                    if (usuario.UrlServicios.Count == 0)
                    {
                        string CodigoGrupoCentroDistribucion = "";
                        listaUrls = HelperBL.obtenerUrlServicios(HttpContext.Current.Session["CodigoCliente"].ToString(), out CodigoGrupoCentroDistribucion);
                    }
                    else
                        listaUrls = usuario.UrlServicios;

                    urlServicio = listaUrls[NombreurlServicio];
                }
            }

            return urlServicio;
        }
        public static string obtenerValorComboDefecto()
        {
            string idProvinciaSeleccionada = "";
            Guid? idCanalProvincia = new Guid("11B8D0DC-2616-419A-8EC9-C0B5EFA628C4");
            ScriptorClient scriptorClient = Common.ScriptorClient;// new ScriptorClient(); //nuevo cliente para evitar uso de cache
            ScriptorChannel canalProvincias = scriptorClient.GetChannel(idCanalProvincia.Value); //usar el nuevo cliente
            var ListaProvinciasScriptor = canalProvincias.QueryContents("#Id", Guid.NewGuid(), "<>").QueryContents("ColumnaDefecto", "1", "=").ToList();
            if (ListaProvinciasScriptor.Count > 0)
            {
                idProvinciaSeleccionada = ListaProvinciasScriptor[0].Parts.Codigo;
            }
            return idProvinciaSeleccionada;
        }


        #endregion

        public static void ObtenerDatosGrillaScriptor(string idcliente, Guid idGrilla, out List<ReportColumnHeader> columnas, out string urlServicio, out string ordenDefecto, out string tituloReporte, out string nombreCampoClaveRegistro)
        {
            urlServicio = "";
            ordenDefecto = "";
            tituloReporte = "";
            nombreCampoClaveRegistro = "";
            columnas = new List<ReportColumnHeader>();
            ScriptorContent grillaScriptor = HelperBL.ObtenerGrillaScriptor(idGrilla);

            if (grillaScriptor != null)
            {
                ScriptorContentInsert columnasGrilla = (ScriptorContentInsert)grillaScriptor.Parts.columnas;
                tituloReporte = grillaScriptor.Parts.Nombre;
                if (columnasGrilla.Count > 0)
                {
                    foreach (ScriptorContent itemColumna in columnasGrilla)
                    {
                        string columnaId = itemColumna.Parts.IdColumna;
                        string nombre = itemColumna.Parts.Nombre;
                        columnas.Add(new ReportColumnHeader() { BindField = columnaId, HeaderName = nombre });

                        string _ordenDefecto = itemColumna.Parts.OrdenDefecto;
                        string _llave = itemColumna.Parts.llave;
                        if (_ordenDefecto == "1")
                            ordenDefecto = columnaId;
                        if (_llave == "1")
                            nombreCampoClaveRegistro = columnaId;

                    }
                }
            }


            urlServicio = HelperBL.obtenerUrlServicio_aux(grillaScriptor, idcliente);

        }
    }
}