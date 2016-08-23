﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Globalization;
using System.Web.Mvc;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using Viatecla.Factory.Scriptor;
using Viatecla.Factory.Web;
using ScriptorModel = Viatecla.Factory.Scriptor.ModularSite.Models;
using System.Xml;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Web.UI.WebControls;
using System.Net;

using GR.Scriptor.Framework;
using System.Web.Script.Serialization;
using System.Web.Security;
using GR.Scriptor.Msc.Memberships.Models;
using GR.Scriptor.Msc.Memberships.Agente.BL;
using ModuloPilotoSodexo;
using GR.Scriptor.Msc.Memberships.Agente.Response;
using GR.Scriptor.Msc.Memberships.Agente.Request;
using System.Reflection;

namespace GR.Scriptor.Msc.Memberships.Controllers
{
    public class ModuloSeguridadGRController : Controller
    {
        //
        // GET: /ModuloAPIRansa/

        public ActionResult Index()
        {
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public virtual ActionResult CerrarSesion()
        {

            Session["CodigoUsuario"] = null;
            Session["NombreUsuario"] = null;
            Session["NombreRol"] = null;
            Session["usuario"] = null;

            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();

            Response.Redirect("/");
            Response.End();

            return Json(new { success = true });
        }
        public ActionResult Demo()
        {
            ScriptorChannel canal = ScriptorModel.Common.ScriptorClient.GetChannel(new Guid("3A22E23A-47B3-4212-BF4B-40EEB88349CF"));

            ScriptorSchemaField campo = canal.Properties.Schema.Fields.AllFields.Where(x => x.Name == "UnidadTiempoPRI").ToList().FirstOrDefault();



            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult Login(string usuario, string password)
        {

            SeguridadBL seguridadBL = new SeguridadBL();
            var hashPermisosBotones = new List<string>();
            try
            {
                //ContentResult loginResponse = (ContentResult)(new SeguridadController()).Login(usuario, password);
                //GR.Scriptor.Membership.Entidades.ResponseLoginUsuario responseLoginUsuario = Newtonsoft.Json.JsonConvert.DeserializeObject<GR.Scriptor.Membership.Entidades.ResponseLoginUsuario>(loginResponse.Content);
                //OBTENEMOS EL LOGIN
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

                        Menu = MenuOrdenado,
                        //Permisos = permisos,
                        Permisos = tablaHash,
                        RolDescripcion = objInfo.Roles[0].Descripcion,
                        esExterno = objInfo.TipoUsuario == "E" ? true : false,
                        Alias = objInfo.Alias,
                        PermisosBotones = hashPermisosBotones
                    },
                };
                FormsAuthentication.SetAuthCookie(objInfo.CodigoUsuario, false);



                return Json(new Result { Success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                (new ManejadorLog()).RegistrarEvento(MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace);

                return Json(new Result { Success = false, Message = ex.Message, Data = hashPermisosBotones }, JsonRequestBehavior.AllowGet);
            }
        }

        public virtual ActionResult ObtenerMenus()
        {
            bool success = false;
            List<ResponseOpcionUI> menu = new List<ResponseOpcionUI>();
            string nombreUsuario = "";
            string rolUsuario = "";
            if (Session["usuario"] != null)
            {
                ResponseUsuarioMscDTO data = (ResponseUsuarioMscDTO)Session["usuario"];
                menu = data.Usuario.Menu;
                nombreUsuario = data.Usuario.NombrePersona;
                rolUsuario = data.Usuario.RolDescripcion;
                success = true;
            }

            return Json(new MenuDTO { Success = success, MenuIzquierdo = menu, NombreUsuario = nombreUsuario, RolUsuario = rolUsuario }, JsonRequestBehavior.AllowGet);

        }
        public virtual ActionResult SesionUsuario()
        {
            List<string> datos = new List<string>();
            string loginame = "";
            string datoserror = "";
            try
            {
                loginame = User.Identity.Name.Split('\\')[1];

                using (var pctx = new PrincipalContext(ContextType.Domain, "GRUPOCOGESA"))
                {
                    using (UserPrincipal up = UserPrincipal.FindByIdentity(pctx, loginame))
                    {
                        if (up != null)
                        {
                            //oUsuario.Email = up.EmailAddress.TryToString(); 
                            datos.Add(up.DisplayName);
                            datos.Add(up.EmailAddress.ToString());
                        }
                        else
                        {
                            datoserror = "NO LOGIN IDENTITY: " + loginame;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                datoserror = "NO LOGIN IDENTITY ERROR: " + loginame + " - " + e.Message;
                //HelperEnviarCorreo.CrearLog("NO LOGIN IDENTITY ERROR: " + loginame + " - " + e.Message);
                datoserror += " - " + e.InnerException.ToString();
                //HelperEnviarCorreo.CrearLog(e.InnerException.ToString());
                datoserror += "  -" + e.Message;
                //HelperEnviarCorreo.CrearLog(e.Message);
                datoserror += " - " + e.StackTrace;
                //HelperEnviarCorreo.CrearLog(e.StackTrace);

            }

            return Json(new { success = datos, error = datoserror }, JsonRequestBehavior.AllowGet);
        }
    }
}
