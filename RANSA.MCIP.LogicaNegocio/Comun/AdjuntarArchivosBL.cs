using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

using System.Web;

using System.IO.IsolatedStorage;
using RANSA.MCIP.Framework;
using RANSA.MCIP.AccesoDatos;
using RANSA.MCIP.DTO;
using RANSA.MCIP.Entidades.Constantes;

namespace RANSA.MCIP.LogicaNegocio
{
    public class AdjuntarArchivosBL
    {

        private String getRutaFisica(String SociedadPropietaria)
        {
            
                return Helper.GetAppSetting("RUTAFISICA");
            
        }

        public String getRutaLogica(String SociedadPropietaria)
        {
            return "/AdjuntarArchivos/Descarga?Archivo=";
        }

        private String getNombreInterno(String SociedadPropietaria, String FileName)
        {
            FileName = FileName.Replace(" ", "");
            String aleatorio = Math.Round(new Random().NextDouble() * 99999999, 0).ToString();
            String nuevofile = DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + aleatorio + FileName;
            return nuevofile;
        }

        public ResponseAdjuntarArchivoDTO AgregarArchivo(RequestAdjuntarArchivosDTO request)
        {
            var filtro = request.filtros;

            try
            {
                if (filtro.archivoStream.Length > 0)
                {
                    var fileName = Path.GetFileName(filtro.filename);
                    //filtro.filename = fileName;
                    //la ruta fisica donde se guardará
                    String nombreInterno = getNombreInterno(request.SociedadPropietaria, fileName);
                    String rutaReal = Path.Combine(getRutaFisica(request.SociedadPropietaria), nombreInterno);

                    var memoryStream = new MemoryStream(filtro.archivoStream);

                    //----------------------------------------------------
                    try
                    {
                        FileStream file = new FileStream(rutaReal, FileMode.Create, System.IO.FileAccess.Write);
                        byte[] bytes = new byte[memoryStream.Length];
                        memoryStream.Read(bytes, 0, (int)memoryStream.Length);
                        file.Write(bytes, 0, bytes.Length);
                        file.Close();
                        memoryStream.Close();

                        return new ResponseAdjuntarArchivoDTO()
                        {
                            error = "",
                            ficheroReal = nombreInterno,
                            ficheroVisual = filtro.filename,
                            link = getRutaLogica(request.SociedadPropietaria) + "" + nombreInterno
                        };
                    }
                    catch (Exception ex)
                    {
                        ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
                        return new ResponseAdjuntarArchivoDTO()
                        {
                            error = ex.Message,
                            ficheroReal = filtro.filename,
                            ficheroVisual = filtro.filename
                        };
                    }
                    //----------------------------------------------------
                }
                else
                {
                    return new ResponseAdjuntarArchivoDTO()
                    {
                        error = "El archivo no es válido o es corrupto",
                        ficheroReal = filtro.filename,
                        ficheroVisual = filtro.filename
                    };
                }
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);

                return new ResponseAdjuntarArchivoDTO()
                {
                    error = ex.Message,
                    ficheroReal = filtro.filename,
                    ficheroVisual = filtro.filename
                };
            }
        }

        public ResponseEliminarAdjuntarArchivoDTO EliminarArchivo(EliminarArchivoAdjuntoDTO request)
        {
            var filtro = request;
            String error = "";
            foreach (var item in request.Archivos)
            {
                try
                {
                    String nombreInterno = getNombreInterno(request.SociedadPropietaria, item);
                    String rutaReal = Path.Combine(getRutaFisica(request.SociedadPropietaria), nombreInterno);

                    System.IO.File.Delete(rutaReal);
                }
                catch (Exception ex)
                {
                    ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
                    error += ex.Message + "\n";
                }
            }
            return new ResponseEliminarAdjuntarArchivoDTO()
            {
                Archivos = request.Archivos,
                error = error
            };
        }

        public ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request)
        {
            try
            {
                using (var Contexto = new ContextoParaBaseDatos())
                {
                    //RepositorioDocumentoAdjunto repo = new RepositorioDocumentoAdjunto(Contexto);
                    //var registro = repo.ObtenerPorFicheroVisual(request.ArchivoVisual);
                    String rutaReal = Path.Combine(getRutaFisica(request.SociedadPropietaria), request.ArchivoVisual.Replace("\\", ""));

                    if (File.Exists(rutaReal))
                    {

                        Byte[] archivoBytes = System.IO.File.ReadAllBytes(rutaReal);
                        return new ResponseDescargarArchivoDTO()
                        {
                            archivoBytes = archivoBytes,
                            errores = new Dictionary<string, string>(),
                            estadoOperacion = ConstantesSistema.EstadoOperacionServicioCorrecto,
                            ficheroVisual = request.ArchivoVisual
                        };
                    }
                    else
                    {
                        var resp = new ResponseDescargarArchivoDTO()
                        {
                            archivoBytes = null,
                            errores = new Dictionary<string, string>(),
                            estadoOperacion = ConstantesSistema.EstadoOperacionServicioError,
                            ficheroVisual = ""
                        };
                        resp.errores.Add("Error", "El Archivo solicitado no existe");
                        return resp;
                    }
                }
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }
            return null;
        }

        //public ResponseParametrosDTO ObtenerParametros(String SociedadPropietaria)
        //{
        //    using (ContextoParaBaseDatos contexto = new ContextoParaBaseDatos())
        //    {
        //        var repo = new RepositorioParametroSistema(contexto);
        //        var res = new ResponseParametrosDTO();

        //        res.Parametros = new List<ParametroDTO>();
        //        res.Parametros.Add(new ParametroDTO()
        //        {
        //            Nombre = "maxFiles",
        //            Valor = repo.ObtenerParametroSistema(ConstantesParametrosSistema.MaxFiles, SociedadPropietaria).Valor
        //        });
        //        res.Parametros.Add(new ParametroDTO()
        //        {
        //            Nombre = "maxSize",
        //            Valor = repo.ObtenerParametroSistema(ConstantesParametrosSistema.MaxSize, SociedadPropietaria).Valor
        //        });
        //        return res;
        //    }
        //}
    }
}
