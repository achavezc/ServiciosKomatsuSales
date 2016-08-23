using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RANSA.MCIP.AccesoDatos;
using RANSA.MCIP.Entidades;
using GR.Scriptor.Framework;
using RANSA.MCIP.DTO;
using RANSA.MCIP.Entidades.Constantes;

namespace RANSA.MCIP.LogicaNegocio
{
    public class MaterialBL
    {
        private MaterialDA objDA;

        public MaterialBL()
        {
            objDA = new MaterialDA(new ContextoParaBaseDatos());        
        }

        public ResponseListarMaterialDTO ListarMaterial(string codigoMaterial)
        {
            var response = new ResponseListarMaterialDTO();
            response.Materiales = new List<MaterialDTO>();
            try
            {
                List<Material> lista = objDA.ListarMaterial(codigoMaterial);

                foreach (var material in lista)
                {
                    response.Materiales.Add(new MaterialDTO()
                    {
                        CodigoMaterial = material.CodigoMaterial,
                        CodigoUnidadMedidaBase = material.CodigoUnidadMedidaBase,
                        IdMaterial = material.IdMaterial,
                        Descripcion = material.Descripcion,
                        DescripcionBreve = material.DescripcionBreve,
                    });
                }

                response.DefaultCodigoTipoPedido = lista.FirstOrDefault() != null ? lista.FirstOrDefault().CodigoMaterial : String.Empty;
                response.estadoOperacion = ConstantesSistema.EstadoOperacionServicioCorrecto;
            }
            catch (Exception ex)
            {
                response.estadoOperacion = ConstantesSistema.EstadoOperacionServicioError;
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }
            return response;
        }
    }
}
