using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using PostSharp.Aspects;
using RANSA.MCIP.Framework;
using RANSA.MCIP.DTO;

namespace RANSA.MCIP.ServicioWCF
{
    // This aspect traces the execution of methods including the value of parameters and return value,
    // implementing performance best practices. Note that reflection is not used at runtime.
    [Serializable]
    public sealed class LogAttribute : OnMethodBoundaryAspect
    {
        // This field is assigned and serialized at build time, then deserialized and read at runtime.
        private string methodName;

        private string url;

        private string tramaInput;

        private string nombreUsuario;

        //DateTime TInicio = DateTime.Now;

        private ManejadorLogEventos manejadorLogEventos;

        // This method is executed at build-time, inside PostSharp.
        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            // Computes the field value at build-time so that reflection is not necessary at runtime.
            this.methodName = method.DeclaringType.FullName + "." + method.Name;
        }

        // This method is executed at runtime inside your application,
        // before target methods.
        public override void OnEntry(MethodExecutionArgs args)
        {
            try
            {
                manejadorLogEventos = new ManejadorLogEventos();

                url = OperationContext.Current.IncomingMessageHeaders.To.AbsoluteUri;
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("+ Entering ");
                nombreUsuario = "";

                if (args.Arguments != null && args.Arguments.Count > 0)
                {
                    tramaInput = Helper.SerializarJsonObjecto(args.Arguments[0]);
                    //nombreUsuario = getUsuario(args.Arguments[0]);

                    ////
                    //ObjetoTrazabilidad objetoTrazabilidad = GR.COMEX.Framework.Helper.ConvertirAObjeto<ObjetoTrazabilidad>("ObjetoTrazabilidad", Helper.SerializarJsonObjecto(args.Arguments[0]));
                    //if (objetoTrazabilidad != null)
                    //{
                    //    //Helper.SetSession("ObjetoTrazabilidad", objetoTrazabilidad);
                    //    //Helper.SetSession("ObjetoTrazabilidad", objetoTrazabilidad);
                    //}
                    ////
                }
                args.MethodExecutionTag = stringBuilder;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
            }
        }

        // This method is executed at runtime inside your application,
        // when target methods exit with success.
        public override void OnSuccess(MethodExecutionArgs args)
        {
            try
            {
                string tramaOutput = "";
                manejadorLogEventos.Break();
                try
                {
                    tramaOutput = Helper.SerializarJsonObjecto(args.ReturnValue);
                }
                catch (Exception ex)
                {

                    tramaOutput = "ERROR AL SERIALIZAR JSON";
                    ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                }
                //ManejadorLog manejadorLog = new ManejadorLog();
                //manejadorLog.GrabarLog(tramaOutput);

                string ip = String.Empty;

                var props = OperationContext.Current.IncomingMessageProperties;
                var endpointProperty = props[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                if (endpointProperty != null)
                {
                    ip = endpointProperty.Address;
                }

                var flagTrazasServicioWCF = ConfigurationManager.AppSettings["FlagTrazasServicioWCF"];
                if (flagTrazasServicioWCF == "S")
                {
                    try
                    {
                        var objetoTrazabilidad = Helper.ConvertirAObjeto<ObjetoTrazabilidad>("ObjetoTrazabilidad", tramaInput);

                        manejadorLogEventos.GrabarLogMapaBD(manejadorLogEventos.inicio, manejadorLogEventos.fin, manejadorLogEventos.GetDuracion(), (manejadorLogEventos.GetDuracion() / 1000), ip, nombreUsuario, "WCF", url, tramaInput, tramaOutput, "LOG_MAPA_SERVICIO", null, objetoTrazabilidad != null ? objetoTrazabilidad.GuidFormulario : null, objetoTrazabilidad != null ? objetoTrazabilidad.ValorReferencial : null, objetoTrazabilidad != null ? objetoTrazabilidad.GuidEvento : null);
                    }
                    catch (Exception)
                    {
                        manejadorLogEventos.GrabarLogMapa(manejadorLogEventos.inicio.ToString(), manejadorLogEventos.fin.ToString(), manejadorLogEventos.GetDuracion().ToString(), (manejadorLogEventos.GetDuracion() / 1000).ToString(), ip, nombreUsuario, "WCF", url, tramaInput, tramaOutput);
                    }
                    //
                }

            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
            }
        }
        //private string getUsuario(object argumento)
        //{
        //    try
        //    {
        //        RequestBaseDTO req = (RequestBaseDTO)argumento;
        //        return req.UsuarioSeguridadDTO.CuentaUsuarioRed;
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}
        public override void OnException(MethodExecutionArgs args)
        {
            try
            {
                manejadorLogEventos.Break();
                string tramaOutput = Helper.SerializarJsonObjecto(args.ReturnValue);

                //ManejadorLog manejadorLog = new ManejadorLog();
                //manejadorLog.GrabarLog(tramaOutput);

                string ip = String.Empty;

                var props = OperationContext.Current.IncomingMessageProperties;
                var endpointProperty = props[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                if (endpointProperty != null)
                {
                    ip = endpointProperty.Address;
                }
                var flagTrazasServicioWCF = ConfigurationManager.AppSettings["FlagTrazasServicioWCF"];
                if (flagTrazasServicioWCF == "S")
                {
                    try
                    {
                        manejadorLogEventos.GrabarLogMapaBD(manejadorLogEventos.inicio, manejadorLogEventos.fin, manejadorLogEventos.GetDuracion(), (manejadorLogEventos.GetDuracion() / 1000), ip, nombreUsuario, "WCF-ERROR", url, tramaInput, tramaOutput, "LOG_MAPA_SERVICIO");
                    }
                    catch (Exception)
                    {
                        manejadorLogEventos.GrabarLogMapa(manejadorLogEventos.inicio.ToString(), manejadorLogEventos.fin.ToString(), manejadorLogEventos.GetDuracion().ToString(), (manejadorLogEventos.GetDuracion() / 1000).ToString(), ip, nombreUsuario, "WCF-ERROR", url, tramaInput, tramaOutput);
                    }
                }
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
            }
        }


    }
}

