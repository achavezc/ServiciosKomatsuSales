using ModuloPilotoSodexo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuloPilotoSodexo.Models
{
    public class DatosBasicoClienteResponse
    {
        public DatosBasicoClienteResponse()
        {
            this.Result = new Result();
        }

        public Result Result { get; set; }
        public Datosbasicos DatosBasicos { get; set; }
    }
    public class Datosbasicos
    {
        public object Sociedad { get; set; }
        public string NumeroCliente { get; set; }
        public string NombreCliente { get; set; }
        public string NumeroRuc { get; set; }
        public string NumeroDNI { get; set; }
        public object NumeroDOI { get; set; }
        public string DireccionPrincipalCliente { get; set; }
        public string NumeroTelefono { get; set; }
        public string DireccionCorreoElectronico { get; set; }
        public string ClaveCondicionesPago { get; set; }
        public string DescripcionCondicionPago { get; set; }
        public string FlagOperadorComercion { get; set; }
        public string Ubigeo { get; set; }
        public string NumeroClienteInterlocutor { get; set; }
    }
}