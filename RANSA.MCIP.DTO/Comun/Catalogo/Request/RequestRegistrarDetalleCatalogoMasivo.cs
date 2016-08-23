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
    public class RequestRegistrarDetalleCatalogoMasivo : RequestBaseDTO
    {

        /// <summary>
        /// <br/><b>Nombre:</b> 'listaDetalleCatalogoDTO'
        /// <br/><b>Tipo:</b> List<DetalleCatalogoDTO>
        ///</summary>
        public List<GrabarDetalleCatalogoDTO> listaGrabarDetalleCatalogoDTO { get; set; }
    }
}