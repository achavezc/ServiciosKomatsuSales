using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuloPilotoSodexo.Models
{

    public class ConsultaDocumentoViewModelPrincipal
    {

        public List<ModuloPilotoSodexo.Models.Provincias> Provincias { get; set; }
        public List<ModuloPilotoSodexo.Models.Paises> Paises { get; set; }
        public List<ModuloPilotoSodexo.Models.Clientes> Clientes { get; set; }

        public string CodigoProvincia { get; set; }
        public string CodigoPais { get; set; }
    }
}