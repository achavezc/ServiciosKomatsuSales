using ModuloPilotoSodexo.Proxy;
using RANSA.MCIP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModuloPilotoSodexo.Controllers
{
    public class AdjuntarArchivosController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult eliminarVarios(String archivos, String iddoc)
        {

            List<string> nombresArchivos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(archivos);

            var obj = new EliminarArchivoAdjuntoDTO()
            {
                Archivos = nombresArchivos,
            };

            var proxy = new AdjuntarArchivosProxyRest();
            ResponseEliminarAdjuntarArchivoDTO response = proxy.EliminarArchivos(obj);

            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(response));
        }

        public ActionResult enviar(HttpPostedFileBase userfile, String iddoc)
        {
            AdjuntarArchivosProxyRest proxy = new AdjuntarArchivosProxyRest();
            //var parametros = proxy.ObtenerParametros(Helpers.Helper.GetSociedadPropietaria());

            String SociedadPropietaria = Helpers.Helper.GetSociedadPropietaria();

            //MaestrosControllerBase maestro = new MaestrosControllerBase();
            //var parametros= maestro.ListarParametroSistema(SociedadPropietaria);


            int maxSize = 5;//MB
            //int.Parse(parametros.Where(x => x.Codigo == (int)TRAMARSA.WA.CM.Entidades.Constantes.ConstantesParametrosSistema.MaxSize).FirstOrDefault().Valor);
            if (userfile.ContentLength <= maxSize * 1024 * 1024)
            {
                var binary = new byte[userfile.ContentLength];
                userfile.InputStream.Read(binary, 0, userfile.ContentLength);

                ResponseAdjuntarArchivoDTO response = proxy.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                {
                    filtros = new AdjuntarArchivosDTO()
                    {
                        archivoStream = binary,
                        filename = userfile.FileName,
                    },
                    //Server = Server,
                    SociedadPropietaria = Helpers.Helper.GetSociedadPropietaria()
                });

                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(response));
            }
            else
            {
                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(new ResponseAdjuntarArchivoDTO()
                {
                    error = "Fichero demasiado grande",
                    ficheroReal = userfile.FileName,
                    ficheroVisual = userfile.FileName
                }));
                //return Content("Fichero demasiado grande");
            }
        }
        public ActionResult Descarga(String Archivo)
        {
            AdjuntarArchivosProxyRest proxy = new AdjuntarArchivosProxyRest();
            ResponseDescargarArchivoDTO response = proxy.DescargarArchivo(new RequestDescargarArchivoDTO()
            {
                ArchivoVisual = Archivo,
                SociedadPropietaria = Helpers.Helper.GetSociedadPropietaria()
            });

            //Stream stream = new MemoryStream(response.archivoBytes);
            if (response.errores.Count == 0)
            {
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=\"" + response.ficheroVisual + "\"");
                //Response.AddHeader("Content-Length", response..ContentLength.ToString());
                Response.BinaryWrite(response.archivoBytes);
                Response.Flush();
                Response.Close();
                //Response.End();
                return null;
            }
            else
            {
                return Content(response.errores["Error"]);
            }
        }
	}
}