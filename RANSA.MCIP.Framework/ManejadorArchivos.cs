using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RANSA.MCIP.Framework
{
    public class ManejadorArchivos
    {

        public void GuardarKey(FileStream fs, Object key)
        {
            ProtectedKey key1 = (ProtectedKey)key;
            KeyManager.Write(fs, key1);
            fs.Close();
        }

        public Object LeerKey(string ruta)
        {
            ProtectedKey keysalida = null;
            FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read);
            keysalida = KeyManager.Read(fs, DataProtectionScope.LocalMachine);
            return keysalida;
            //ProtectedKey key = KeyManager.RestoreKey(File.Open(ruta,

            //                    FileMode.Open, FileAccess.Read), keyPassword,

            //  System.Security.Cryptography.DataProtectionScope.LocalMachine);

        }

        public void SerializarArchivoSinMsg(string ruta, Object obj)
        {
            IFormatter formato = new BinaryFormatter();
            //
            Stream flujo = new FileStream(ruta,
                FileMode.Create, FileAccess.Write, FileShare.None);
            formato.Serialize(flujo, obj);
            flujo.Close();
        }

        public Object DeSerializarArchivo(string ruta)
        {
            try
            {
                IFormatter formato = new BinaryFormatter();
                Stream flujo = new FileStream(ruta,
                        FileMode.Open, FileAccess.Read, FileShare.Read);
                Object salida = formato.Deserialize(flujo);
                flujo.Close();
                return salida;
            }
            catch
            {
                return null;
            }
        }

        public static XmlDocument GenerarRequestConsultaManifiesto(string numManifiesto, int annManifiesto, string codTipManifiesto, string codVia, string codAduana)
        {
            XmlDocument SoapEnvelop = new XmlDocument();
            string XmlrequestSunat="";

            XmlrequestSunat = @" <?xml version=""1.0"" encoding=""UTF-8""?> ";
            XmlrequestSunat = XmlrequestSunat + " <SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ns1=\"http://services.sigad.sunat.gob.pe\"> ";
            XmlrequestSunat = XmlrequestSunat + " <SOAP-ENV:Body> ";
            XmlrequestSunat = XmlrequestSunat + "  <ns1:consultarManifiesto> ";
            XmlrequestSunat = XmlrequestSunat + "    <numManifiesto>" + numManifiesto + "</numManifiesto> ";
            XmlrequestSunat = XmlrequestSunat + "    <annManifiesto>" + annManifiesto + "</annManifiesto> ";
            XmlrequestSunat = XmlrequestSunat + "    <codTipManifiesto>" + codTipManifiesto + "</codTipManifiesto> ";
            XmlrequestSunat = XmlrequestSunat + "    <codVia>" + codVia + "</codVia> ";
            XmlrequestSunat = XmlrequestSunat + "    <codAduana>" + codAduana + "</codAduana> ";
            XmlrequestSunat = XmlrequestSunat + "  </ns1:consultarManifiesto> ";
            XmlrequestSunat = XmlrequestSunat + " </SOAP-ENV:Body> ";
            XmlrequestSunat = XmlrequestSunat + " </SOAP-ENV:Envelope> ";
            SoapEnvelop.LoadXml(XmlrequestSunat);
            return SoapEnvelop;
        }

        public static XmlDocument GenerarRequestConsultaManifiestoCarga(Int64 dataArchivoConsulta)
        {
            XmlDocument SoapEnvelop = new XmlDocument();
            string XmlrequestSunat = "";

            XmlrequestSunat = @" <?xml version=""1.0"" encoding=""UTF-8""?> ";
            XmlrequestSunat = XmlrequestSunat + " <SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ns1=\"http://services.sigad.sunat.gob.pe\"> ";
            XmlrequestSunat = XmlrequestSunat + " <SOAP-ENV:Body> ";
            XmlrequestSunat = XmlrequestSunat + "  <ns1:consultarManifiestoCarga> ";
            XmlrequestSunat = XmlrequestSunat + "    <dataArchivoConsulta>" + dataArchivoConsulta + "</dataArchivoConsulta> ";
            XmlrequestSunat = XmlrequestSunat + "  </ns1:consultarManifiestoCarga> ";
            XmlrequestSunat = XmlrequestSunat + " </SOAP-ENV:Body> ";
            XmlrequestSunat = XmlrequestSunat + " </SOAP-ENV:Envelope> ";
            SoapEnvelop.LoadXml(XmlrequestSunat);
            return SoapEnvelop;
        }

    }
}
