using GR.Scriptor.Framework;
using GR.Scriptor.Msc.Memberships.Agente.Request;
using GR.Scriptor.Msc.Memberships.Agente.Response;
using GR.Scriptor.Msc.Memberships.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GR.Scriptor.Msc.Memberships.Agente.BL
{
    public class SeguridadAgente
    {
        public ResponseLoginUsuario Login(RequestLogin request)
        {
            var crypt = new SimpleInteroperableEncryption(WebConfigReader.SemillaEncriptacionPublica);
            var dominio = WebConfigReader.DominioAplicacion;
            request.AcronimoAplicacion = WebConfigReader.AcronimoAplicacion;
            request.Clave = crypt.Encrypt(request.Clave);
            //request.Dominio = dominio.ToUpper();

            if (request.CodigoUsuario.IndexOf("\\") > -1)
            {
                request.Dominio = request.CodigoUsuario.Split('\\')[0].ToUpper();
                request.CodigoUsuario = request.CodigoUsuario.Split('\\')[1];
            }
            else
            {
                request.Dominio = dominio.ToUpper();
            }

            return (new SeguridadProxyRest()).Login(request);
        }
    }
}