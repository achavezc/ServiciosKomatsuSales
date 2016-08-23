using GR.Scriptor.Framework;
using GR.Scriptor.Frameworks.DTO;
using ModuloPilotoSodexo.App_Start.Helper;
using ModuloPilotoSodexo.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viatecla.Factory.Scriptor;
using Viatecla.Factory.Scriptor.ModularSite.Models;

namespace ModuloPilotoSodexo.Controllers
{
    public class FrameworkGRController : Controller
    {
        //
        // GET: /FrameworkGR/
        public ActionResult Index()
        {
            return View();
        }
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
                    if (!lstColumnas.ContainsKey(nombreColumnaScriptor))
                        continue;

                    object valorEditado = lstColumnas[nombreColumnaScriptor];
                    if (tipo.ToUpper().Contains("STRING"))
                    {
                        if (valorEditado.GetType().ToString().Contains("Boolean"))
                        {
                            part = (Convert.ToBoolean(valorEditado) == true ? "1" : "0");
                        }
                        else
                        {
                            part = valorEditado.ToString();
                        }
                    }
                    else if (tipo.ToUpper().Contains("INT32"))
                    {
                        part = valorEditado.ToString();
                    }
                    else if (tipo.ToUpper().Contains("DOUBLE"))
                    {
                        part = valorEditado.ToString();
                    }
                    else if (tipo.Contains("ScriptorContentInsert"))
                    {
                        string tipoCriterio = ((Viatecla.Factory.Scriptor.ScriptorContentInsert)(part)).Field.ContentCriteria;
                        if (!lstColumnas.ContainsKey(nombreColumnaScriptor + "Atributo"))
                            continue;
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
                                        if (ContenidoItemGrabar == null || esNuevo)
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
                                                if (_valorEditado.GetType().ToString().Contains("Boolean"))
                                                {
                                                    _part = (Convert.ToBoolean(_valorEditado) == true ? "1" : "0");
                                                }
                                                else
                                                {
                                                    _part = _valorEditado.ToString();
                                                }
                                                secambio = true;
                                            }
                                        }
                                        else
                                        {
                                            if (_tipo.ToUpper().Contains("ScriptorDropdownListValue".ToUpper()))
                                            {
                                                string colDDL = regItemArray[_nombreColumnaScriptor + "Atributo"].ToString();
                                                Dictionary<string, object> lstColumnasDropDown = JsonConvert.DeserializeObject<Dictionary<string, object>>(colDDL);
                                                string valorDropDownList = lstColumnasDropDown["Valor"].ToString();
                                                _part = valorDropDownList;
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
                                            ContenidoItemGrabar.Save("create_publish");
                                        }
                                        else
                                        {
                                            ContenidoItemGrabar.Save("alterar");
                                            //ContenidoItemGrabar//referenciado y modificado
                                        }

                                }
                                part = contenInsert;
                                break;
                            case "specific_dropdownlist":
                                {
                                    ScriptorContentInsert contenInsertDropDown = (ScriptorContentInsert)part;
                                    Guid? idContenidoArray = null;
                                    contenInsertDropDown.Clear();
                                    ScriptorChannel channel2 = scriptorClient.GetChannel(new Guid(valorIdCanal), null);
                                    if (valorEditado.ToString().Contains("["))
                                    {
                                        JArray arrayColumnasAtributos2 = JArray.Parse(valorEditado.ToString());

                                        foreach (var regItemArray in arrayColumnasAtributos2)
                                        {
                                            //verificar si existe, sino crea
                                            idContenidoArray = new Guid(regItemArray["Id"].ToString());
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        idContenidoArray = new Guid(valorEditado.ToString());
                                    }
                                    bool sicambio = false;

                                    ScriptorContent primerContenido = channel2.QueryContents("#Id", idContenidoArray, "=", false).ToList().FirstOrDefault();
                                    if (primerContenido != null)
                                        contenInsertDropDown.Add(primerContenido);

                                    part = contenInsertDropDown;

                                }
                                break;
                        }

                    }
                    else if (tipo.Contains("ScriptorDropdownListValue"))
                    {
                        if (!lstColumnas.ContainsKey(nombreColumnaScriptor + "Atributo"))
                            continue;
                        string valorEditadoAtributo = lstColumnas[nombreColumnaScriptor + "Atributo"].ToString();
                        Dictionary<string, object> lstColumnasAtributos = JsonConvert.DeserializeObject<Dictionary<string, object>>(valorEditadoAtributo);
                        string valorIdCanal = lstColumnasAtributos["IdCanal"].ToString();
                        if (String.IsNullOrEmpty(Convert.ToString(valorEditado)) == true)
                        {
                            part = null;
                        }
                        else
                        {
                            ScriptorChannel channel2 = Common.ScriptorClient.GetChannel(new Guid(valorIdCanal), null);
                            ScriptorContent primerContenido = channel2.QueryContents("#Id", valorEditado.ToString(), "=", false).ToList().FirstOrDefault();
                            part = ScriptorDropdownListValue.FromContent(primerContenido);
                        }
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

        public ActionResult QueryContentsGRFormulario(string path, Guid? id, string[] query, int? skip = new int?(), int? take = new int?(), string orderBy = null, string authToken = null)//RequestConsultaPedidoDTO filtros, PaginacionDTO paginacionDTO
        {
            return new HelperDataScriptor().QueryContentsGRFormulario(path, id, query, skip, take, orderBy, authToken);
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

        public ActionResult ListarContenidos(PaginacionDTO paginacionDTO, string filtrosJson)
        {
            return HelperWeb.FiltrarContenidos(Request, Response, paginacionDTO, filtrosJson);
        }
    }
}