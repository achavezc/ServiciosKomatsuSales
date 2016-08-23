using GR.Scriptor.Framework;
using RANSA.MCIP.Entidades.Constantes;
using RANSA.MCIP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Viatecla.Factory.Scriptor;
using Viatecla.Factory.Scriptor.ModularSite.Models;

namespace ModuloPilotoSodexo.Agente.BL
{
    public class MaestrosBL
    {
        public List<ElementoDTO> ListarTipoPedido(out string valorDefault)
        {
            return ListaCombo_Auxiliar(out valorDefault, ConstantesConfig.GuidCanalTipoPedido, "CodigoTipoPedido", "Descripcion");
        }

        public List<ElementoDTO> ListarCuenta(out string valorDefault)
        {
            return ListaCombo_Auxiliar(out valorDefault, ConstantesConfig.GuidCanalCuenta, "CodigoCuenta", "Nombre");
        }

        public List<ElementoDTO> ListarNegocio(out string valorDefault)
        {
            return ListaCombo_Auxiliar(out valorDefault, ConstantesConfig.GuidCanalNegocio, "CodigoNegocio", "Descripcion");
        }

        public List<ElementoDTO> ListarAlmacen(out string valorDefault)
        {
            return ListaCombo_Auxiliar(out valorDefault, ConstantesConfig.GuidCanalAlmacen, "CodigoAlmacen", "Nombre", "Direccion");
        }

        public List<ElementoDTO> ListarCliente(out string valorDefault)
        {
            return ListaCombo_Auxiliar(out valorDefault, ConstantesConfig.GuidCanalCliente, "CodigoCliente", "Nombre", "Direccion");
        }

        private ScriptorChannel ObtenerCanal(string strIdCanal)
        {
            Guid idCanal = new Guid(strIdCanal);
            ScriptorClient scriptorClient = Common.ScriptorClient;
            ScriptorChannel canal = scriptorClient.GetChannel(idCanal);
            return canal;
        }

        public ElementoDTO ObtenerCliente(string codigoCliente)
        {
            List<ScriptorContent> lista = ObtenerCanal(ConstantesConfig.GuidCanalCliente).QueryContents(String.Empty, String.Empty, String.Empty).ToList();
            ScriptorContent content = lista.FirstOrDefault(c => c.Parts["CodigoCliente"] == codigoCliente && c.Parts["FlagAnulacion"] == "0");

            return new ElementoDTO()
            {
                Codigo = content.Parts["CodigoCliente"],
                Nombre = content.Parts["Nombre"],
                Objeto1 = content.Parts["IdCuenta"]
            };                    
        }

        private List<ElementoDTO> ListaCombo_Auxiliar(out string valorDefault, string strIdCanal, string DataFieldValue, string DataFieldName, string elementoContenido1="")
        {
            valorDefault = "";
            List<ElementoDTO> listaResultado = new List<ElementoDTO>();

            Guid idCanal = new Guid(strIdCanal);

            ScriptorClient scriptorClient = Common.ScriptorClient;
            ScriptorChannel canal = scriptorClient.GetChannel(idCanal); //usar el nuevo cliente
            List<ScriptorContent> Lista = canal.QueryContents("FlagAnulacion", "0", "=").OrderBy(x=> x.Parts[DataFieldName]).ToList();//QueryContents("#Id", Guid.NewGuid(), "<>")

            if (Lista.Count > 0)
            {
                valorDefault = Lista.FirstOrDefault().Parts[DataFieldValue];
            }

            listaResultado = (from lst in Lista
                              select new ElementoDTO()
                              {
                                  Codigo = lst.Parts[DataFieldValue],
                                  Nombre = lst.Parts[DataFieldName],
                                  Elemento1 = string.IsNullOrEmpty(elementoContenido1) ? "" : lst.Parts[elementoContenido1]
                              }).ToList()
                              ;

            return listaResultado;
        }
        
    }
}