/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:36:29 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RANSA.MCIP.Framework;

namespace RANSA.MCIP.AgenteServicios
{
    public class BaseAgenteServicios
    {
        protected Y DeserializarJSON<T, Y>(T request, string url, string soapAction = "", bool consultaSap = false)
        {
            var utilitarioRest = new UtilitarioRest();
            return utilitarioRest.DeserializarJSON<T, Y>(request, url, soapAction, consultaSap);
        }

        protected Y DeserializarXML<T, Y>(T request, string url, string soapAction = "", bool consultaSap = false)
        {
            var utilitarioRest = new UtilitarioRest();
            return utilitarioRest.DeserializarJSON<T, Y>(request, url, soapAction, consultaSap,ContentType.XML);
        }

    }
}