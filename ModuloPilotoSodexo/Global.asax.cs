using GR.Scriptor.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml;
using Scriptor;
using GR.Scriptor.Msc.Memberships;
using Viatecla.Factory.Scriptor.ModularSite;
using Viatecla.Factory.Scriptor.ModularSite.Models;
using Viatecla.Factory.Scriptor;
using Viatecla.Factory.Web.Core;
using System.Configuration;
using Viatecla.Factory.Web.Mvc;
using System.Net;


namespace ModuloPilotoSodexo
{
    public class MvcApplication : GR.Scriptor.Msc.Memberships.MvcApplication
    {
        public MvcApplication()
        {
        }
        protected override void Application_Start()
        {
            //base.Application_Start();
            //AreaRegistration.RegisterAllAreas();
        }

        

        protected void Session_Start(object sender, EventArgs e)
        {

        }



    }
}

