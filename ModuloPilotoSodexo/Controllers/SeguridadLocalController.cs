using GR.Scriptor.Comun.Entidades.Constantes;
using GR.Scriptor.Framework;
using GR.Scriptor.Msc.Memberships.Agente.BL;
using GR.Scriptor.Msc.Memberships.Agente.Request;
using GR.Scriptor.Msc.Memberships.Agente.Response;
using GR.Scriptor.Msc.Memberships.Models;
using ModuloPilotoSodexo.App_Start.Helper;
using ModuloPilotoSodexo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Viatecla.Factory.Scriptor;
using Viatecla.Factory.Scriptor.ModularSite.Models;

namespace ModuloPilotoSodexo.Controllers
{
    public class SeguridadLocalController : GR.Scriptor.Msc.Memberships.Controllers.ModuloSeguridadGRController
    {
        public ActionResult QueryContents(string path, Guid? id, string[] query, int? skip = new int?(), int? take = new int?(), string orderBy = null, string authToken = null)
        {
            ActionResult result2 = new Helper.HelperDataScriptor().QueryContents(path, id, query, skip, take, orderBy, authToken);

            return result2;
        }

        //
        // GET: /SeguridadCalculadorWeb/
        public ActionResult Index()
        {
            return View();
        }
        //public override ActionResult Login(string usuario, string password)
        //{
        //    var actionresult = base.Login(usuario, password);
        //    return actionresult;
        //}
        public override ActionResult Login(string usuario, string password)
        {
            DatosBasicoClienteResponse response = new DatosBasicoClienteResponse();
            SeguridadBL seguridadBL = new SeguridadBL();
            var hashPermisosBotones = new List<string>();
            try
            {
                (new ManejadorLog()).RegistrarEvento(MethodBase.GetCurrentMethod().Name, usuario, password);

                ResponseLoginUsuario objLogin = seguridadBL.Login(new RequestLogin
                {
                    Clave = password,
                    CodigoUsuario = usuario
                });

                if (objLogin == null)
                    throw new Exception("Servicio Login no disponible.");

                if (objLogin.ResultadoLogin == false)
                    throw new Exception(objLogin.MensajeError);

                (new ManejadorLog()).RegistrarEvento(MethodBase.GetCurrentMethod().Name, Newtonsoft.Json.JsonConvert.SerializeObject(objLogin));

                //OBTENEMOS LOS DATOS DE SEGURIDAD DEL USUARIO
                ResponseInfoUsuarioDTO objInfo = seguridadBL.GetInformacionUsuario(objLogin.IdPerfilUsuario);

                (new ManejadorLog()).RegistrarEvento(MethodBase.GetCurrentMethod().Name, Newtonsoft.Json.JsonConvert.SerializeObject(objInfo));

                objInfo.IdPerfilUsuario = objLogin.IdPerfilUsuario;

                var tablaHash = new List<string>();
                List<ResponseOpcionUI> MenuOrdenado = new List<ResponseOpcionUI>();
                seguridadBL.HacerTablaHash(objInfo.OpcionesUI, ref tablaHash, ref MenuOrdenado, ref hashPermisosBotones);

                objInfo.OpcionesUI = null;
                //OBTENEMOS LOS DATOS DE NEGOCIO DEL USUARIO
                /*
                Datosbasicos datosBasicos = (new ComexBL()).GetDatosBasicoClienteSAP(objInfo.Alias);
                response.DatosBasicos = datosBasicos;*/
                string CodigoGrupoCentroDistribucion = "";

                bool esSuperCliente = false;
                if (objInfo.Roles.Count > 0)
                {
                    ResponseRoles rol = objInfo.Roles.Find(c => c.Codigo == "005");
                    if (rol != null)
                    {
                        if (!String.IsNullOrEmpty(rol.Codigo))
                        {
                            //Session["SuperCliente"] = true;
                            Session["CodigoGrupoCliente"] = objInfo.Alias;
                            esSuperCliente = true;
                        }
                    }
                }
                Dictionary<string, string> listaUrlServicio = new Dictionary<string, string>();
                if (!esSuperCliente)
                {
                    Session["CodigoCliente"] = objInfo.Alias;
                    listaUrlServicio = HelperBL.obtenerUrlServicios(objInfo.Alias, out CodigoGrupoCentroDistribucion);
                    Session["CodigoGrupoCentroDistribucion"] = CodigoGrupoCentroDistribucion;
                }
                Session["EsAdministrador"] = objInfo.RecursosAdicionales.Exists(x => x.Descripcion.Contains("Grupo de Cliente -"));
                Session["usuario"] = new ResponseUsuarioMscDTO()
                {
                    Usuario = new UsuarioDTO()
                    {
                        IdUsuario = objInfo.IdUsuario,
                        IdPerfilUsuario = objLogin.IdPerfilUsuario,
                        CodigoCargo = objInfo.CodigoCargo,
                        CodigoUsuario = objInfo.CodigoUsuario,
                        NombrePersona = objInfo.NombresCompletos.Split('(')[0],
                        NombreUsuario = objInfo.CodigoUsuario.Split('\\')[1],
                        Menu = objInfo.OpcionesUI,
                        //Permisos = permisos,
                        Permisos = tablaHash,
                        RolDescripcion = objInfo.Roles[0].Descripcion,
                        esExterno = objInfo.TipoUsuario == "E" ? true : false,
                        Alias = objInfo.Alias,
                    },
                    UrlServicios = listaUrlServicio,
                    GrupoClientesPermitidos = objInfo.RecursosAdicionales.FindAll(x => x.Descripcion.Contains("Grupo de Cliente -")).Select(x => x.Codigo).ToList(),
                    //SociedadesPermitidas = objInfo.Sociedades.Select(x => x.Codigo).ToList(),
                    //UnidadesNegocioPermitidas = objInfo.Negocios.Select(x => x.Codigo).ToList(),
                    //SedesPermitidas = objInfo.Sedes.Select(x => x.Codigo).ToList(),
                    ProvinciasPermitidas = objInfo.RecursosAdicionales.FindAll(x => x.Descripcion.Contains("Provincias -")).Select(x => x.Codigo).ToList(),
                    // adicional
                    CuentasPermitidas = objInfo.RecursosAdicionales.FindAll(x => x.Descripcion.Contains("Cuenta -")).Select(x => x.Codigo).ToList()
                };

                FormsAuthentication.SetAuthCookie(objInfo.CodigoUsuario, false);

                //
                var objSeguridadBL = new SeguridadBL();
                var objmenu = objSeguridadBL.MenuPrincipal();



                dynamic obj = new
                {
                    MenuPrincipal = objmenu.MenuPrincipal,
                    MenuDerecho = objmenu.MenuDerecho,
                    LinkDerecho = objmenu.LinkDerecho,
                    NombreUsuario = objmenu.NombreUsuario,
                    EsExterno = objmenu.EsExterno
                };
                Session["ObjMenu"] = obj;
                //

                response.Result = new Result { Success = true };

                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                (new ManejadorLog()).RegistrarEvento(MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace);

                response.Result = new Result { Success = false, Message = ex.Message };
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Salir()
        {
            Session["datosCliente"] = null;
            Session["usuario"] = null;
            Session["CodigoCliente"] = null;
            Session["CodigoGrupoCentroDistribucion"] = null;
            Session["ObjMenu"] = null;
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();

            Response.Redirect("/");
            Response.End();

            return null;
        }

        public ActionResult MenuPrincipal(String GUIDChannel)
        {
            dynamic obj = null;
            ScriptorChannel channel = Common.ScriptorClient.GetChannel(new Guid(GUIDChannel));

            try
            {
                if (Session["ObjMenu"] != null)
                {
                    var objSeguridadBL = new SeguridadBL();
                    var objmenu = objSeguridadBL.MenuPrincipal();


                    ViewBag.MenuPrincipal = objmenu.MenuPrincipal;
                    ViewBag.MenuDerecho = objmenu.MenuDerecho;
                    ViewBag.LinkDerecho = objmenu.LinkDerecho;
                    ViewBag.NombreUsuario = objmenu.NombreUsuario;
                    ViewBag.EsExterno = objmenu.EsExterno;
                    obj = new
                    {
                        MenuPrincipal = objmenu.MenuPrincipal,
                        MenuDerecho = objmenu.MenuDerecho,
                        LinkDerecho = objmenu.LinkDerecho,
                        NombreUsuario = objmenu.NombreUsuario,
                        EsExterno = objmenu.EsExterno
                    };
                    Session["ObjMenu"] = obj;
                }
                else
                {
                    dynamic objMenu = Session["ObjMenu"];
                    ViewBag.MenuPrincipal = objMenu.MenuPrincipal;
                    ViewBag.MenuDerecho = objMenu.MenuDerecho;
                    ViewBag.LinkDerecho = objMenu.LinkDerecho;
                    ViewBag.NombreUsuario = objMenu.NombreUsuario;
                    ViewBag.EsExterno = objMenu.EsExterno;

                }
            }
            catch (Exception ex)
            {
                (new ManejadorLog()).RegistrarEvento(MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace);
                IView vista2 = channel.Properties.Content.GetTemplateView(ControllerContext, null);

                Response.ContentType = "text/javascript";
                return View(vista2);
            }
            //ViewBag.CodigoRolResponsable = codigoRolResponsable;
            //ViewBag.CodigoRolCliente = codigoRolCliente;



            //mando el menu
            IView vista = channel.Properties.Content.GetTemplateView(ControllerContext, null);

            Response.ContentType = "text/javascript";
            return View(vista);
        }

    }
}