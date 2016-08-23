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
	public class RequestBaseDTO
	{
        public RequestBaseDTO()
        {
            this.ObjetoTrazabilidad = new ObjetoTrazabilidad();
        }

        //public void SetRequestBaseDTO(RequestBaseDTO requestBaseDTO)
        //{
        //    string eventoGuid = "";
        //    string origenGuid = "";

        //    if (requestBaseDTO == null)
        //        return;

        //    this.UsuarioSeguridadDTO = requestBaseDTO.UsuarioSeguridadDTO;

        //    if (requestBaseDTO.ObjetoTrazabilidad != null)
        //    {
        //        eventoGuid = !string.IsNullOrEmpty(requestBaseDTO.ObjetoTrazabilidad.GuidEvento) ? requestBaseDTO.ObjetoTrazabilidad.GuidEvento : "";
        //        origenGuid = !string.IsNullOrEmpty(requestBaseDTO.ObjetoTrazabilidad.GuidFormulario) ? requestBaseDTO.ObjetoTrazabilidad.GuidFormulario : "";
        //    }


        //    ObjetoTrazabilidad = new ObjetoTrazabilidad()
        //    {
        //        GuidEvento = eventoGuid,
        //        GuidFormulario = origenGuid,
        //        ValorReferencial = ""
        //    };
        //}


        ///// <summary>
        ///// <br/><b>Nombre:</b> 'usuarioSeguridadDTO'
        ///// <br/><b>Tipo:</b> UsuarioSeguridadDTO
        /////</summary>
        //public UsuarioSeguridadDTO UsuarioSeguridadDTO
        //{
        //    get;
        //    set;
        //}

        public ObjetoTrazabilidad ObjetoTrazabilidad { get; set; }
	}

    public class ObjetoTrazabilidad
    {
        public ObjetoTrazabilidad()
        {
            this.GuidFormulario = "";
            this.GuidEvento = "";
            this.ValorReferencial = "";
        }

        public string GuidFormulario { get; set; }
        public string GuidEvento { get; set; }
        public string ValorReferencial { get; set; }
    }
}