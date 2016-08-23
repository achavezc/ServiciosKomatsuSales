namespace ModuloPilotoSodexo.Models
{
    using ModuloPilotoSodexo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    ////[Serializable]
    public class ResponseConsultaInventarioDTO
    {
        public Result Result { get; set; }
        public List<DatosConsultaInventario> ListaInventario { get; set; }
        public int NroPagina { get; set; }
    }

    public class DatosConsultaInventario 
    {
        public int NroRegistro { get; set; }
        public string TipoDeposito { get; set; }
        public string CodigoMercaderia { get; set; }
        public string DescripcionMercaderia { get; set; }
        public string OrdenServicio { get; set; }
        public string FechaEmisionOS { get; set; }
        public decimal StockFisico { get; set; }
        public decimal CantidadWarranteada { get; set; }
        public decimal CantidadComprometida { get; set; }
        public decimal CantidadBloqueada { get; set; }
        public decimal CantidadDisponible { get; set; }
        public string UnidadMedida { get; set; }
        public decimal PesoStockFisico { get; set; }
        public decimal PesoWarranteado { get; set; }
        public decimal PesoComprometido { get; set; }
        public decimal PesoBloqueado { get; set; }
        public decimal PesoDisponible { get; set; }
        public string    UnidadMedidaPeso { get; set; }
        public string FechaVencimiento { get; set; }
        public string DescripcionMaqVapor { get; set; }
        
    }
}


