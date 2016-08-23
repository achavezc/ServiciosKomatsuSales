using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuloPilotoSodexo.App_Start.Helper
{
    public class DatosListaDinamicaDTO
    {
        public DatosListaDinamicaDTO()
        { }
        public DatosListaDinamicaDTO(string NombreObjetoLista, string NombreCampoClaveRegistro)
        {
            this.NombreObjetoLista = NombreObjetoLista;
            this.NombreCampoClaveRegistro = NombreCampoClaveRegistro;
            this.NombreCampoOrdenamiento = "ColumnaOrdenamiento";
            this.NombreCampoNroRegistros = "NroItem";
        }

        public DatosListaDinamicaDTO(string NombreObjetoLista, string NombreCampoClaveRegistro, string NombreCampoNroRegistros)
        {
            this.NombreObjetoLista = NombreObjetoLista;
            this.NombreCampoClaveRegistro = NombreCampoClaveRegistro;
            this.NombreCampoOrdenamiento = "ColumnaOrdenamiento";
            this.NombreCampoNroRegistros = NombreCampoNroRegistros;
        }

        public DatosListaDinamicaDTO(string NombreObjetoLista, string NombreCampoClaveRegistro, string NombreCampoNroRegistros, string NombreCampoOrdenamiento)
        {
            this.NombreObjetoLista = NombreObjetoLista;
            this.NombreCampoClaveRegistro = NombreCampoClaveRegistro;
            this.NombreCampoOrdenamiento = NombreCampoOrdenamiento;
            this.NombreCampoNroRegistros = NombreCampoNroRegistros;
        }


        public string NombreObjetoLista { get; set; }
        public string NombreCampoClaveRegistro { get; set; }
        public string NombreCampoOrdenamiento { get; set; }
        public string NombreCampoNroRegistros { get; set; }
    }
}