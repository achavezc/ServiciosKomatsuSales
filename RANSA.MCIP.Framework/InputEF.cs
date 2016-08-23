using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.Framework
{

    public class InputEF
    {
        public string NombreAtributo { get; set; }
        public Object Valor { get; set; }
        public ParameterDirection ParametroDireccionGrabado { get; set; }
        public SqlDbType? SqlDbTipo { get; set; }
        public int? Tamaño { get; set; }
        public byte? CantidadDecimales { get; set; }
        public string TipoNombre { get; set; }
        public DbType DbTipo { get; set; }

        public InputEF()
        {

        }
        public InputEF(string NombreAtributo, Object Valor, DbType TipoValor, ParameterDirection ParametroDireccionGrabado = ParameterDirection.Input)
        {
            this.Valor = Valor;
            this.NombreAtributo = NombreAtributo;
            this.ParametroDireccionGrabado = ParametroDireccionGrabado;
            this.SqlDbTipo = null;
            this.DbTipo = TipoValor;//HelperEF.ConvertToDbType(TipoValor);
        }
        public InputEF(string NombreAtributo, Object Valor, SqlDbType sqlDbType, int tamaño, short? CantidadDecimalesSiTuviese, ParameterDirection ParameterDirection = ParameterDirection.Input)
        {
            this.Valor = Valor;
            this.NombreAtributo = NombreAtributo;
            this.ParametroDireccionGrabado = ParameterDirection;
            this.CantidadDecimales = CantidadDecimalesSiTuviese != null ? (byte?)CantidadDecimalesSiTuviese : null;
            this.SqlDbTipo = sqlDbType;
            this.Tamaño = tamaño;
        }
        /// <summary>
        /// Sólo aplica cuando es Structuras.
        /// </summary>
        /// <param name="NombreAtributo"></param>
        /// <param name="TipoNombre"></param>
        public InputEF(string NombreAtributo, Object valor, String TipoNombre)
        {
            this.NombreAtributo = NombreAtributo;
            this.Valor = valor;
            this.ParametroDireccionGrabado = ParameterDirection.Input;
            this.SqlDbTipo = System.Data.SqlDbType.Structured;
            this.TipoNombre = TipoNombre;
        }

    }
}
