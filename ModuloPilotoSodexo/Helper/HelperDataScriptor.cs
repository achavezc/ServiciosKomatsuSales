using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viatecla.Factory.Scriptor;
using System.Xml;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Viatecla.Factory.Scriptor.ModularSite.Models;
using Viatecla.Factory.Web.Core;

namespace ModuloPilotoSodexo.Helper
{
    public class HelperDataScriptor : Controller
    {
        public ActionResult Content(Controller controller, string path, Guid? templateId = new Guid?())
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult result = new Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult
                {
                    Error = true,
                    Message = "Missing mandatory parameter: 'path'",
                    Data = null
                };
                return base.Json(result, 0);
            }
            ScriptorChannel channel = Common.WebSiteChannel.Descendants.FirstOrDefault<ScriptorChannel>(ch => ch.FriendlyPath.EndsWith(path.Substring(0, path.LastIndexOf('/'))));
            if (channel == null)
            {
                Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult result2 = new Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult
                {
                    Error = true,
                    Message = "Channel not found",
                    Data = null
                };
                return base.Json(result2, 0);
            }
            ScriptorContent contentByFriendlyTitle = channel.GetContentByFriendlyTitle(path.Split(new char[] { '/' }).LastOrDefault<string>());
            if (contentByFriendlyTitle == null)
            {
                Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult result3 = new Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult
                {
                    Error = true,
                    Message = "Content not found",
                    Data = null
                };
                return base.Json(result3, 0);
            }
            if (templateId.HasValue)
            {
                Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult result4 = new Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult
                {
                    Error = false,
                    Message = "OK",
                    Data = contentByFriendlyTitle.GetTemplateView(controller.ControllerContext, Common.LayoutContent, new Guid?(templateId.Value)).RenderToString<ScriptorContent>(contentByFriendlyTitle, null, null)
                };
                return this.LargeJson(result4, 0, null);
            }
            Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult data = new Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult
            {
                Error = false,
                Message = "OK",
                Data = this.SafeContent(contentByFriendlyTitle)
            };
            return this.LargeJson(data, 0, null);
        }



        public ActionResult ChannelProperties(string path, Guid? id, bool? children = false, string authToken = null)
        {
            Func<ScriptorChannel, bool> predicate = null;
            Func<ScriptorChannel, bool> func2 = null;
            Func<ScriptorContent, object> selector = null;
            Func<ScriptorContent, object> func4 = null;
            if (string.IsNullOrWhiteSpace(path) && !id.HasValue)
            {
                Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult result = new Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult
                {
                    Error = true,
                    Message = "Missing mandatory parameter: 'path' or 'id'",
                    Data = null
                };
                return base.Json(result, 0);
            }
            ScriptorChannel channel = null;
            if (authToken == null)
            {
                if (!id.HasValue)
                {
                }
                if (predicate == null)
                {
                    predicate = ch => ch.Id == id.Value;
                }
                channel = (func2 != null) ? Common.WebSiteChannel.DescendantsAndSelf.FirstOrDefault<ScriptorChannel>(predicate) : Common.WebSiteChannel.DescendantsAndSelf.FirstOrDefault<ScriptorChannel>((func2 = ch => ch.FriendlyPath.EndsWith(path)));
                Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult result2 = new Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult
                {
                    Error = false,
                    Message = "OK"
                };
                if (selector == null)
                {
                    selector = c => this.SafeContent(c);
                }
                result2.Data = channel.Properties.Contents.Select<ScriptorContent, object>(selector);
                return this.LargeJson(result2, 0, null);
            }
            ScriptorClient client = new ScriptorClient(null, null, null, null);
            client.ChangeUserWithToken(authToken);
            channel = id.HasValue ? client.GetChannel(id.Value, null) : client.GetChannel(path, null);
            Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult data = new Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult
            {
                Error = false,
                Message = "OK"
            };
            if (func4 == null)
            {
                func4 = c => this.SafeContent(c);
            }
            data.Data = channel.Properties.Contents.Select<ScriptorContent, object>(func4);
            LargeJsonResult result3 = this.LargeJson(data, 0, null);
            client.DisposeScriptorObject();
            return result3;
        }

        public ActionResult QueryContents(string path, Guid? id, string[] query, int? skip = new int?(), int? take = new int?(), string orderBy = null, string authToken = null)
        {
            Func<ScriptorChannel, bool> predicate = null;
            Func<ScriptorChannel, bool> func2 = null;
            if (string.IsNullOrWhiteSpace(path) && !id.HasValue)
            {
                Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult result = new Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult
                {
                    Error = true,
                    Message = "Missing mandatory parameter: 'path' or 'id'",
                    Data = null
                };
                return this.Json(result, 0);
            }
            ScriptorChannel channel = null;
            if (authToken == null)
            {
                if (!id.HasValue)
                {
                }
                if (predicate == null)
                {
                    predicate = ch => ch.Id == id.Value;
                }
                channel = (func2 != null) ? Common.WebSiteChannel.DescendantsAndSelf.FirstOrDefault<ScriptorChannel>(predicate) : Common.WebSiteChannel.DescendantsAndSelf.FirstOrDefault<ScriptorChannel>((func2 = ch => ch.FriendlyPath.EndsWith(path)));
                return this.QueryContentsResult(channel, query, skip, take, orderBy);
            }
            ScriptorClient client = new ScriptorClient(null, null, null, null);
            client.ChangeUserWithToken(authToken);
            channel = id.HasValue ? client.GetChannel(id.Value, null) : client.GetChannel(path, null);
            ActionResult result2 = this.QueryContentsResult(channel, query, skip, take, orderBy);
            client.DisposeScriptorObject();
            return result2;
        }
        public ActionResult QueryContentsGRFormulario(string path, Guid? id, string[] query, int? skip = new int?(), int? take = new int?(), string orderBy = null, string authToken = null)
        {
            Func<ScriptorChannel, bool> predicate = null;
            Func<ScriptorChannel, bool> func2 = null;
            if (string.IsNullOrWhiteSpace(path) && !id.HasValue)
            {
                Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult result = new Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult
                {
                    Error = true,
                    Message = "Missing mandatory parameter: 'path' or 'id'",
                    Data = null
                };
                return this.Json(result, 0);
            }
            ScriptorChannel channel = null;
            if (authToken == null)
            {
                if (!id.HasValue)
                {
                }
                if (predicate == null)
                {
                    predicate = ch => ch.Id == id.Value;
                }
                channel = (func2 != null) ? Common.WebSiteChannel.DescendantsAndSelf.FirstOrDefault<ScriptorChannel>(predicate) : Common.WebSiteChannel.DescendantsAndSelf.FirstOrDefault<ScriptorChannel>((func2 = ch => ch.FriendlyPath.EndsWith(path)));
                return this.QueryContentsResultGRFormulario(channel, query, skip, take, orderBy);
            }
            ScriptorClient client = new ScriptorClient(null, null, null, null);
            client.ChangeUserWithToken(authToken);
            channel = id.HasValue ? client.GetChannel(id.Value, null) : client.GetChannel(path, null);
            ActionResult result2 = this.QueryContentsResultGRFormulario(channel, query, skip, take, orderBy);
            client.DisposeScriptorObject();
            return result2;
        }
        private ActionResult QueryContentsResultGRFormulario(ScriptorChannel channel, string[] query, int? skip, int? take, string orderBy)
        {
            try
            {
                if (channel == null)
                {
                    Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult result = new Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult
                    {
                        Error = true,
                        Message = "Channel not found",
                        Data = null
                    };
                    return this.Json(result, 0);
                }
                ScriptorQueryEnumerable<ScriptorContent> enumerable = channel.QueryContents("#Id", Guid.NewGuid(), "<>", false);

                foreach (string str in query)
                {
                    enumerable = enumerable.QueryContents(str.Split(new char[] { ';' })[0], str.Split(new char[] { ';' })[1], str.Split(new char[] { ';' })[2]);
                }

                if (skip.HasValue)
                {
                    enumerable = enumerable.Skip(skip.Value);
                }
                if (take.HasValue)
                {
                    enumerable = enumerable.Take(take.Value);
                }
                if (!string.IsNullOrWhiteSpace(orderBy))
                {
                    enumerable = enumerable.OrderBy(orderBy);
                }
                dynamic _rows = from c in enumerable.ToList()
                                select ((dynamic)this.SafeContentGRFormulario(c)).cell;


                return Viatecla.Factory.Web.Core.LargeJsonExtensions.LargeJson(this, _rows, 0, null);
            }
            catch (Exception ex)
            {
                Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult result = new Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult
                {
                    Error = true,
                    Data = ex.InnerException + " - " + ex.StackTrace,
                    Message = ex.Message
                };
                return this.Json(result, 0);
            }
        }
        private ActionResult QueryContentsResult(ScriptorChannel channel, string[] query, int? skip, int? take, string orderBy)
        {
            try
            {
                if (channel == null)
                {
                    Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult result = new Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult
                     {
                         Error = true,
                         Message = "Channel not found",
                         Data = null
                     };
                    return this.Json(result, 0);
                }
                ScriptorQueryEnumerable<ScriptorContent> enumerable = channel.QueryContents("#Id", Guid.NewGuid(), "<>", false);

                foreach (string str in query)
                {
                    enumerable = enumerable.QueryContents(str.Split(new char[] { ';' })[0], str.Split(new char[] { ';' })[1], str.Split(new char[] { ';' })[2]);
                }
                int nroRegistros = enumerable.Count();

                if (skip.HasValue)
                {
                    enumerable = enumerable.Skip(skip.Value);
                }
                if (take.HasValue)
                {
                    enumerable = enumerable.Take(take.Value);
                }
                if (!string.IsNullOrWhiteSpace(orderBy))
                {
                    enumerable = enumerable.OrderBy(orderBy);
                }
                //Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult data = new Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult
                //{
                //    Error = false,
                //    Message = "OK",
                //    Data = new { Id = channel.Id, Path = channel.FriendlyPath, Name = channel.Name, Schema = channel.Schema.Id, Contents = from c in enumerable select this.SafeContent(c) }
                //};
                dynamic _rows = from c in enumerable.ToList()
                                select new
                                {
                                    Id = ((dynamic)this.SafeContent(c)).Id,
                                    Title = ((dynamic)this.SafeContent(c)).Title,
                                    cell = ((dynamic)this.SafeContent(c)).Parts
                                };


                int nroEncontrados = enumerable.ToList().Count;

                dynamic lista = new
                {
                    page = (skip / take + 1),
                    records = nroRegistros,
                    total = Math.Ceiling((double)(nroRegistros) / (double)take),//(nroEncontrados / take + 1),
                    rows = _rows
                };


                return Viatecla.Factory.Web.Core.LargeJsonExtensions.LargeJson(this, lista, 0, null);
            }
            catch (Exception ex)
            {
                Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult result = new Viatecla.Factory.Scriptor.ModularSite.Controllers.DataController.DataResult
                {
                    Error = true,
                    Data = ex.InnerException + " - " + ex.StackTrace,
                    Message = ex.Message
                };
                return this.Json(result, 0);
            }
        }
        private object SafeContentGRFormulario(ScriptorContent c)
        {
            ScriptorContentInsertContent content = c as ScriptorContentInsertContent;
            if (content != null)//&& (content.ContentInsert.Field.ContentCriteria == "reverse")
            {
                return new
                {
                    Id = c.Id,
                    Title = c.Title,
                    cell = this.SafePartsGRFormulario(c, (dynamic)c.Parts, content.ContentInsert.Field.CriteriaParams)
                };
                //return c.Title;
            }
            return new
            {
                Id = c.Id,
                Title = c.Title,
                cell = this.SafePartsGRFormulario(c, (dynamic)c.Parts)
            };
        }
        private object SafePartsGRFormulario(ScriptorContent content, dynamic parts, IEnumerable<string> excludeFields = null)
        {
            return (parts as IDictionary<string, object>).Where<KeyValuePair<string, object>>(delegate(KeyValuePair<string, object> p)
            {
                if (excludeFields != null)
                {
                    return !excludeFields.Contains<string>(p.Key);
                }
                return true;
            }).ToDictionary<KeyValuePair<string, object>, string, object>(p1 => p1.Key, delegate(KeyValuePair<string, object> p2)
            {
                if (p2.Value is ScriptorContentInsert)
                {
                    var lista = (p2.Value as ScriptorContentInsert);
                    //string cadena = "";
                    //for (int i = 0; i < lista.Count; i++)
                    //{
                    //    if (i == (lista.Count - 1))
                    //        cadena = cadena + lista[i].Title;
                    //    else
                    //        cadena = cadena + lista[i].Title + ",";
                    //}
                    return (from ci in p2.Value as ScriptorContentInsert select this.SafeContentGRFormulario(ci));
                }
                if (!(p2.Value is DateTime))
                {
                    if (p2.Value is ScriptorFile)
                    {
                        return this.SafeScriptorFile(content, p2.Value as ScriptorFile);
                    }
                    if (p2.Value is ScriptorDropdownListValue)
                    {
                        return this.SafeDropDownListValue(p2.Value as ScriptorDropdownListValue);
                    }
                    if (p2.Value is System.Xml.XmlNode)
                    {
                        return new JavaScriptSerializer().Deserialize(JsonConvert.SerializeXmlNode(p2.Value as XmlNode, 0, true), typeof(Dictionary<string, object>));
                    }
                    if (p2.Value == null)
                    {
                        return null;
                    }
                    return p2.Value.ToString();
                }
                DateTime? nullable = p2.Value as DateTime?;
                return nullable.Value.ToString("o");
            });
        }
        private object SafeContent(ScriptorContent c)
        {
            ScriptorContentInsertContent content = c as ScriptorContentInsertContent;
            if (content != null)//&& (content.ContentInsert.Field.ContentCriteria == "reverse")
            {
                //return new { Id = c.Id, Title = c.Title, State = c.StateDescription, ChannelPath = c.Channel.FriendlyPath, Path = c.Channel.FriendlyPath + '/' + c.FriendlyTitle, Parts = this.SafeParts(c, (dynamic)c.Parts, content.ContentInsert.Field.CriteriaParams) };
                return c.Title;
            }
            return new { Id = c.Id, Title = c.Title, State = c.StateDescription, ChannelPath = c.Channel.FriendlyPath, Path = c.Channel.FriendlyPath + '/' + c.FriendlyTitle, Parts = this.SafeParts(c, (dynamic)c.Parts) };
        }
        private object SafeParts(ScriptorContent content, dynamic parts, IEnumerable<string> excludeFields = null)
        {
            return (parts as IDictionary<string, object>).Where<KeyValuePair<string, object>>(delegate(KeyValuePair<string, object> p)
            {
                if (excludeFields != null)
                {
                    return !excludeFields.Contains<string>(p.Key);
                }
                return true;
            }).ToDictionary<KeyValuePair<string, object>, string, object>(p1 => p1.Key, delegate(KeyValuePair<string, object> p2)
            {
                if (p2.Value is ScriptorContentInsert)
                {
                    var lista = (p2.Value as ScriptorContentInsert);
                    string cadena = "";
                    for (int i = 0; i < lista.Count; i++)
                    {
                        if (i == (lista.Count - 1))
                            cadena = cadena + lista[i].Title;
                        else
                            cadena = cadena + lista[i].Title + ",";
                    }
                    return cadena; //(from ci in p2.Value as ScriptorContentInsert select this.SafeContent(ci));
                }
                if (!(p2.Value is DateTime))
                {
                    if (p2.Value is ScriptorFile)
                    {
                        return this.SafeScriptorFile(content, p2.Value as ScriptorFile);
                    }
                    if (p2.Value is ScriptorDropdownListValue)
                    {
                        return (p2.Value as ScriptorDropdownListValue).Title;//this.SafeDropDownListValue(p2.Value as ScriptorDropdownListValue);
                    }
                    if (p2.Value is System.Xml.XmlNode)
                    {
                        return new JavaScriptSerializer().Deserialize(JsonConvert.SerializeXmlNode(p2.Value as XmlNode, 0, true), typeof(Dictionary<string, object>));
                    }
                    if (p2.Value == null)
                    {
                        return null;
                    }
                    return p2.Value.ToString();
                }
                DateTime? nullable = p2.Value as DateTime?;
                return nullable.Value.ToString("o");
            });
        }
        private object SafeScriptorFile(ScriptorContent content, ScriptorFile scriptorFile)
        {
            return new { Src = scriptorFile.Src, Size = scriptorFile.Size, FileName = scriptorFile.Filename };
        }
        private object SafeDropDownListValue(ScriptorDropdownListValue scriptorDropdownListValue)
        {
            return new { Value = scriptorDropdownListValue.Value, Title = scriptorDropdownListValue.Title, Content = (scriptorDropdownListValue.Content != null) ? this.SafeContent(scriptorDropdownListValue.Content) : null };
        }


        public string ObtenerCampoOrdenDefault(Guid idGrilla)
        {
            string obtenerColumnaOrden = "";
            List<ScriptorContent> ListaEstadosScriptor = new List<ScriptorContent>();
            Guid? idCanalGrilla = new Guid("69A1584C-D5EF-454F-8476-9F31A959B90A");
            ScriptorClient scriptorClient = Common.ScriptorClient;// new ScriptorClient(); //nuevo cliente para evitar uso de cache
            ScriptorChannel canalEstados = scriptorClient.GetChannel(idCanalGrilla.Value); //usar el nuevo cliente
            ListaEstadosScriptor = canalEstados.QueryContents("#Id", idGrilla, "=").ToList();
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

        public string ObtenerNombreUrlUtilizarPorTipo(Guid idTipoUtilizar)
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


    }
}