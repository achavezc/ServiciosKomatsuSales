using GR.Scriptor.Framework;
using ModuloPilotoSodexo.Agente.BL;
using ModuloPilotoSodexo.Helper;
using Newtonsoft.Json;
using RANSA.MCIP.ViewModel.MaestrosMasivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ModuloPilotoSodexo.Controllers
{
    public class MaestrosMasivosController : Controller
    {
    
        public ActionResult Index()
        {
            return View();
        }

        #region Clientes

        public ActionResult CargaMasivaClientes(HttpPostedFileBase upload)
        {
            ActionResult actionResult = null;
            var manejadorLogEventos = new ManejadorLogEventos();
            try
            {
                var response = new MaestrosMasivosBL().CargarDatosMasivoCliente(upload);
                actionResult = actionResult = Content(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                HelperCtrl.GrabarLog(ex, "", PoliticaExcepcion.WebController);
            }
            finally
            {
                manejadorLogEventos.RegistrarTiempoEjecucion(HelperCtrl.ObtenerAtributosManejadorEventos(ControllerContext.ToString(), MethodBase.GetCurrentMethod().Name, HelperCtrl.ObtenerUsuario()));
            }
            return actionResult;
        }

        public ActionResult RegistraMasivoCliente(RequestMasivoClienteViewModel request)
        {
            ActionResult actionResult = null;
            try
            {
                var response = new MaestrosMasivosBL().RegistraMasivoCliente(request);
                actionResult = Content(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                HelperCtrl.GrabarLog(ex, "", PoliticaExcepcion.WebController);
            }
            return actionResult;
        }

        #endregion

        #region Material

        public ActionResult CargaMasivaMateriales(HttpPostedFileBase upload)
        {
            ActionResult actionResult = null;
            var manejadorLogEventos = new ManejadorLogEventos();
            try
            {
                var response = new MaestrosMasivosBL().CargarDatosMasivoMaterial(upload);
                actionResult = actionResult = Content(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                HelperCtrl.GrabarLog(ex, "", PoliticaExcepcion.WebController);
            }
            finally
            {
                manejadorLogEventos.RegistrarTiempoEjecucion(HelperCtrl.ObtenerAtributosManejadorEventos(ControllerContext.ToString(), MethodBase.GetCurrentMethod().Name, HelperCtrl.ObtenerUsuario()));
            }
            return actionResult;
        }

        public ActionResult RegistraMasivoMaterial(RequestMasivoMaterialViewModel request)
        {
            ActionResult actionResult = null;
            try
            {
                var response = new MaestrosMasivosBL().RegistraMasivoMaterial(request);
                actionResult = Content(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                HelperCtrl.GrabarLog(ex, "", PoliticaExcepcion.WebController);
            }
            return actionResult;
        }

        #endregion

        #region  Almacen

        public ActionResult CargaMasivaAlmacenes(HttpPostedFileBase upload)
        {
            ActionResult actionResult = null;
            var manejadorLogEventos = new ManejadorLogEventos();
            try
            {
                var response = new MaestrosMasivosBL().CargarDatosMasivoAlmacen(upload);
                actionResult = actionResult = Content(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                HelperCtrl.GrabarLog(ex, "", PoliticaExcepcion.WebController);
            }
            finally
            {
                manejadorLogEventos.RegistrarTiempoEjecucion(HelperCtrl.ObtenerAtributosManejadorEventos(ControllerContext.ToString(), MethodBase.GetCurrentMethod().Name, HelperCtrl.ObtenerUsuario()));
            }
            return actionResult;
        }

        public ActionResult RegistraMasivoAlmacen(RequestMasivoAlmacenViewModel request)
        {
            ActionResult actionResult = null;
            try
            {
                var response = new MaestrosMasivosBL().RegistraMasivoAlmacen(request);
                actionResult = Content(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                HelperCtrl.GrabarLog(ex, "", PoliticaExcepcion.WebController);
            }
            return actionResult;
        }

        #endregion

    }
}