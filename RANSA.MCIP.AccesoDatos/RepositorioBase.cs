using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.SqlClient;
using System.Linq;

namespace RANSA.MCIP.AccesoDatos
{
    public class RepositorioBase<TData>
        where TData : class
    {
        protected ContextoParaBaseDatos Contexto;
        protected DbSet<TData> DbSet;

        protected RepositorioBase(ContextoParaBaseDatos contexto)
        {
            Contexto = contexto;
            DbSet = contexto.Set<TData>();
        }
        //public List<GR.COMEX.Comercial.Entidades.Core.TarifaSede> ObtenerTodo()
        //{
        //    return (from lst in Contexto.TarifaSede
        //            select lst).ToList();
        //}

        public virtual TData ObtenerPorId(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Agregar(TData entidad)
        {
            DbSet.Add(entidad);
        }

        public virtual void Eliminar(TData entidad)
        {
            if (Contexto.Entry(entidad).State == EntityState.Detached)
            {
                DbSet.Attach(entidad);
            }
            DbSet.Remove(entidad);
        }
        public virtual void EliminarLogicamente(TData entidad)
        {
            Actualizar(entidad);
            var entry = Contexto.Entry(entidad);
            foreach (var name in entry.CurrentValues.PropertyNames)
            {
                try
                {
                    if (name == "EstadoRegistro")
                        entry.Property(name).IsModified = true;
                    else
                        entry.Property(name).IsModified = false;
                }
                catch { }
            }
            Contexto.Entry(entidad).Property("FechaHoraActualizacion").CurrentValue = DateTime.Now;
            Contexto.Entry(entidad).Property("EstadoRegistro").CurrentValue = false;
        }
        public virtual void Actualizar(TData entidad)
        {
            if (Contexto.Entry(entidad).State == EntityState.Detached)
            {
                DbSet.Attach(entidad);
                //((IObjectContextAdapter)Contexto).ObjectContext.ObjectStateManager.ChangeObjectState(entidad, EntityState.Modified);
            }
            Contexto.Entry(entidad).State = EntityState.Modified;
        }
        public virtual void Actualizar(TData entidad, bool omitirdatoscreacion, List<String> lstomitirdatos)
        {
            Actualizar(entidad);
            if (omitirdatoscreacion)
            {
                Contexto.Entry(entidad).Property("FechaHoraCreacion").IsModified = false;
                Contexto.Entry(entidad).Property("UsuarioCreacion").IsModified = false;
            }
            if (lstomitirdatos.Count > 0)
            {
                foreach (String reg in lstomitirdatos)
                {
                    Contexto.Entry(entidad).Property(reg).IsModified = false;
                }
            }
        }
        public virtual void Actualizar(TData entidad, bool omitirdatoscreacion)
        {
            Actualizar(entidad);
            if (omitirdatoscreacion)
            {
                Contexto.Entry(entidad).Property("FechaHoraCreacion").IsModified = false;
                Contexto.Entry(entidad).Property("UsuarioCreacion").IsModified = false;
            }
        }
        public virtual void Actualizar(TData entidad, List<String> lstomitirdatos)
        {
            Actualizar(entidad);
            if (lstomitirdatos.Count > 0)
            {
                foreach (String reg in lstomitirdatos)
                {
                    Contexto.Entry(entidad).Property(reg).IsModified = false;
                }
            }
        }
        public tipo siNull<tipo>(SqlDataReader dr, string campo, tipo defecto)
        {
            if (dr.IsDBNull(dr.GetOrdinal(campo)))
                return defecto;
            else
                return (tipo)dr[campo];
        }

        public virtual void Grabar()
        {
            Contexto.SaveChanges();
        }

        public void ReAttach(TData entidad)
        {
            if (Contexto.Entry(entidad).State == EntityState.Detached)
            {
                DbSet.Attach(entidad);
            }
        }

        public SqlParameter createParameter(string paramNombre, SqlDbType paramTipo, object paramValor, ParameterDirection direccion = ParameterDirection.Input, int? tamano = null, string typeName = null)
        {
            SqlParameter parameter = new SqlParameter(paramNombre, paramTipo);
            parameter.Direction = direccion;
            if (tamano != null)
                parameter.Size = Convert.ToInt32(tamano);

            if (paramValor == null)
            {
                parameter.Value = DBNull.Value;
                //if (paramTipo == SqlDbType.VarChar)
                //{
                //    parameter.Value = string.Empty;
                //}
                //else
                //{
                //}
            }
            else
                parameter.Value = paramValor;

            if (!string.IsNullOrEmpty(typeName))
            {
                parameter.TypeName = typeName;
            }

            return parameter;
        }
    }
}

