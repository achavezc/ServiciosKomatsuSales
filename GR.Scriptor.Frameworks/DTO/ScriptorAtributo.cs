using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.Scriptor.Frameworks
{
    public class ScriptorAtributo
    {
        public string IdCampo { get; set; }
        public string Tipo { get; set; }
        public string NombreCampo { get; set; }
        public string Descripcion { get; set; }
        public string ValorCombo { get; set; }
        public string ValorDefecto { get; set; }
        public string CantidadCaracteres { get; set; }
        public string Orden { get; set; }
        public string NombreFormulario { get; set; }
        public string EsOpcional { get; set; }
        public string CriterioControl { get; set; }
        public string JsonFormParametros { get; set; }
        public string ClaseAtributo { get; set; }
        public string ClaseAtributoControl { get; set; }
        public string CanalAsociado { get; set; }
        public ScriptorDatoParametros ObjetoParametros { get; set; }
        public ListaValoresDetalleAtributo ListaValoresDetalle { get; set; }
        public dynamic Otros { get; set; }
    }
    public class ListaValoresDetalleAtributo : List<ValoresDetalleAtributo>
    {
        public ListaValoresDetalleAtributo()
            : base()
        {
        }
        public string IdCanal { get; set; }
    }
    public class ScriptorFormulario
    {
        public string TituloFormulario { get; set; }
        public List<ScriptorDivisiones> ListaDivisiones { get; set; }
    }
    public class ScriptorDivisiones
    {
        public string TituloDivision { get; set; }
        public List<ScriptorAtributo> ListaAtributos { get; set; }
    }
    public class ValoresDetalleAtributo
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string IdCanal { get; set; }
        public string Json { get; set; }
    }
    public class ScriptorDatoParametros
    {
        public string Titulo { get; set; }
        public string ObjGrilla { get; set; }
        public string CampoOrigen { get; set; }
        public string UrlBusqueda { get; set; }
        public string Clase { get; set; }
        public string ClaseControl { get; set; }
        public string AnchoMaximo { get; set; }
        public List<ScriptorDatoOrigenDestino> ListaOrigenDestino { get; set; }

    }
    public class ScriptorDatoOrigenDestino
    {
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Atributo { get; set; }
    }
}
