using System;
using System.Collections.Generic;
using System.Linq;

namespace RANSA.MCIP.Framework
{
    //Los que son valores de Catalogo de Tablas, deben coincidir con la columna CodigoTabla de la tabla CatalogoTablas
    public enum KeyCache
    {
        /*CatalogoTablas*/
        CodAduanas,
        CodEstadosRegistro,
        CodTiposManifiesto,
        CodViasTransporte,
        /*Interno*/
        Sociedad,
        CodTiposDocumento
    }
}