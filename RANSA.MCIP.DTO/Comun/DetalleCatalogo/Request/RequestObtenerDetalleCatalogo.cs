/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:36:44 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RANSA.MCIP.DTO
{
    public class RequestObtenerDetalleCatalogo : RequestBaseDTO
    {
        /// <summary>
        /// <br/><b>Nombre:</b> 'idDetalleCatalogo'
        /// <br/><b>Tipo:</b> int
        ///</summary>
        public int? idDetalleCatalogo
        {
            get;
            set;
        }
        public int? idCatalogoTabla
        {
            get;
            set;
        }
    }
}