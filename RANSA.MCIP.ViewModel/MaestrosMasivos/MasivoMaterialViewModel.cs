using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.ViewModel.MaestrosMasivos
{
    public class MasivoMaterialViewModel
    {
        public string CodigoMaterial { get; set; }
        public string CodigoCuenta { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionBreve { get; set; }
        public string CodigoUnidadMedidaBase { get; set; }
        public float PesoNeto { get; set; }
        public float PesoBruto { get; set; }
        public string CodigoUnidadPeso { get; set; }
        public float Volumen { get; set; }
        public string CodigoUnidadVolumen { get; set; }
        public float Longitud { get; set; }
        public float Ancho { get; set; }
        public float Altura { get; set; }
        public float UnidadesPorCaja { get; set; }
        public float CajaXPallet { get; set; }
        public float CajaXCama { get; set; }
        public float CamaXPallet { get; set; }
    }
}
