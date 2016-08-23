using GR.Scriptor.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml;
using Scriptor;
using System.Threading;
using System.Globalization;


namespace GR.Scriptor.Msc.Memberships
{
    public class MvcApplication : Viatecla.Factory.Scriptor.ModularSite.MvcApplication
    {
        public MvcApplication()
        {
            var xx = "";
            xx += "errr";
        }
        protected override void Application_Start()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB"); 
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture; 
            base.Application_Start();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                //Si el usuario esta Autenticado 
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    string usuariosession = "";
                    try
                    {
                        usuariosession = User.Identity.Name;

                        FormsAuthentication.SetAuthCookie(User.Identity.Name, false);

                        HelperSeguridad.SetUsuarioRed(User.Identity.Name);
                        ManejadorLog log = new ManejadorLog();
                        log.RegistrarEvento(string.Format("usuario = {0}", User.Identity.Name));
                    }
                    catch (Exception ex)
                    {
                        HelperEnviarCorreo.CrearLog("Session_Start error:" + ex.Message + ", user: " + usuariosession);
                    }
                }
            }
            else
            {
                string myself = HelperSeguridad.GetUsuarioRed();
                FormsAuthentication.SetAuthCookie(myself, false);
            }
        }



    }
}

