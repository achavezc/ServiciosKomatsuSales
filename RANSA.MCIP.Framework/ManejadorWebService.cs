using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Services.Description;
using System.Xml;
using System.Xml.Linq;

namespace RANSA.MCIP.Framework
{
    public static class ManejadorWebService
    {
        public static XDocument InvocarWebService(string Url, XmlDocument RequestXml, string SoapAction = "", string Usuario = "", string Clave = "")
        {
            XDocument ResponseXML = new XDocument();
            string soapResult;
            WebResponse webResponse;
            StreamReader rd;
            Stream streamResponse;
            //Uri uri = new Uri(Url); // Create the uri object

            //Url = "http://www.sunat.gob.pe:443/itmanifiesto-ws/manifiestoService?wsdl";

            HttpWebRequest webRequest = CreateWebRequest(Url, SoapAction) ;

            // Generar credenciales si se ingresaron datos
            if (Usuario.Trim() != string.Empty && Clave.Trim() != string.Empty)
            {
                webRequest.Credentials = new NetworkCredential(Usuario, Clave);
            }

            //Adicionamos el Response
            InsertSoapEnvelopeIntoWebRequest(RequestXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            webResponse = webRequest.EndGetResponse(asyncResult);

            streamResponse = webResponse.GetResponseStream();
            rd = new StreamReader(streamResponse);
            ResponseXML = XDocument.Load(rd);
            soapResult = rd.ReadToEnd();
                
            Console.Write(soapResult);
            
            

            //XNamespace df = ResponseXML.Root.Name.Namespace;

            //string name = ResponseXML.Root.Element(df + "GetLocationByZipCodeResult").Element(df + "MunicipalityName").Value;

            //double latitude = (double)ResponseXML.Root.Element(df + "GetLocationByZipCodeResult").Element(df + "Latitude");

            //double longitude = (double)ResponseXML.Root.Element(df + "GetLocationByZipCodeResult").Element(df + "Longitude");

            //WebResponse webResponse = webRequest.GetResponse();
            //Stream requestStream = webResponse.GetResponseStream();

            //// Get a WSDL file describing a service
            //ServiceDescription serviceDescription = ServiceDescription.Read(requestStream);
            //// Initialize a service description importer
            //ServiceDescriptionImporter descriptionImporter = new ServiceDescriptionImporter();
            //descriptionImporter.AddServiceDescription(serviceDescription, String.Empty, String.Empty);

            ////The allowed values of this property are:  "Soap", "Soap12", "HttpPost" ,"HttpGet" and "HttpSoap".
            ////The default value is "Soap", which indicates the SOAP 1.1 standard. This is case sensitive.
            //descriptionImporter.ProtocolName = "Soap";
            //descriptionImporter.CodeGenerationOptions = CodeGenerationOptions.GenerateProperties;
            //CodeNamespace codeNamespace = new CodeNamespace();

            //// Compile to assembly
            //compilerResults = codeProvider.CompileAssemblyFromDom(compilerParameters, codeCompileUnit);
            //Assembly assembly = compilerResults.CompiledAssembly;

            //// We have a valid assembly now. Try to get the Type from it.
            //Type type = assembly.GetType(_mTypeName) ?? FindTypeByName(assembly);

            //// Create the object instance
            //_mTargetInstance = assembly.CreateInstance(_mTypeName);
            //// Get the method info object
            //_mMethodInfo = type.GetMethod(
            //_mMethodName,
            //BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.IgnoreReturn);

            //// Invoke the method with necessary arguments
            //object result = _mMethodInfo.Invoke(_mTargetInstance, parameters);

            return ResponseXML;
        
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
