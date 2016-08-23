using RANSA.MCIP.DTO;
using RANSA.MCIP.Entidades;
using RANSA.MCIP.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.AccesoDatos
{
    public class CuentaDA : RepositorioBase<Cuenta>
    {
        public CuentaDA(ContextoParaBaseDatos contexto) : base(contexto) { }

        public List<Cuenta> ListarCuenta()
        {
            List<Cuenta> cuentas = new List<Cuenta>();
            try
            {
                List<InputEF> lstInputBD = new List<InputEF>();

                cuentas = new HelperEF(Contexto.Database).EjecutarFuncionOProcedimiento<Cuenta>("SP_GRSCRIPTOR_ListarCuenta", lstInputBD);

                return cuentas;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AccesoDatos);
                throw ex;
            }
        }

        public Cuenta ObtenerCuentaPorCliente(string codigoCliente)
        {
            try
            {
                List<InputEF> lstInputBD = new List<InputEF>();
                List<Cuenta> lista = new List<Cuenta>();
                Cuenta cuenta = null;

                lstInputBD.Add(new InputEF("@CodigoCliente", codigoCliente, DbType.String, ParameterDirection.Input));
                               
                lista = new HelperEF(Contexto.Database).EjecutarFuncionOProcedimiento<Cuenta>("SP_GRSCRIPTOR_ObtenerCuentaPorCliente", lstInputBD);
                
                if (lista.Count > 0)
                {
                    cuenta = lista.SingleOrDefault();
                }
                
                return cuenta;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AccesoDatos);
                throw ex;
            }
        }
    }
}
