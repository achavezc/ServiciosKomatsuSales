/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:36:43 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RANSA.MCIP.DTO
{
    public class RequestBusquedaCatalogoTablasDTO : RequestOperacionBusquedaDTO
    {
        public FiltrosBusquedaCatalogoTablasDTO filtros { get; set; }
    }
}