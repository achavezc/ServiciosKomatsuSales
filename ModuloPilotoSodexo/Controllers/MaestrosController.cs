using ModuloPilotoSodexo.Proxy;
using RANSA.MCIP.DTO.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModuloPilotoSodexo.Controllers
{
    public class MaestrosController : Controller
    {
        //
        // GET: /Maestros/
        public ActionResult Index()
        {
            return View();
        }
        //
        // GET: /Maestros/
        public ActionResult CrearCorrelativo(RequestObtenerCorrelativoMaestro request)
        {
            var proxy = new MaestroProxyRest();
            ResponseObtenerCorrelativoMaestro response = proxy.ObtenerCorrelativoMaestro(request);

            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(response));
        }
    }
}