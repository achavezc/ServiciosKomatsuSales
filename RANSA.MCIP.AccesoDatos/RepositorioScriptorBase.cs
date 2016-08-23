using RANSA.MCIP.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Viatecla.Factory.Scriptor;
using Viatecla.Factory.Scriptor.ModularSite.Models;

namespace RANSA.MCIP.AccesoDatos
{
    /// <summary>
    /// ...
    /// </summary>
    public class RepositorioScriptorBase
    {
        public ScriptorClient scriptorClient;
        public ScriptorChannel currentChannel;
        public List<ScriptorContent> contents;
        
        public RepositorioScriptorBase(string _idCanal)
        {
            this.scriptorClient = new ScriptorClient();
            Guid idCanal = new Guid(_idCanal);
            this.currentChannel = scriptorClient.GetChannel(idCanal);
            contents = currentChannel.QueryContents("#Id", Guid.NewGuid(), "<>").ToList();
        }

        private T CrearItem<T>(ScriptorContent content)
        {
            T obj = default(T);

            if (content!=null)
            {
                obj = Activator.CreateInstance<T>();

                foreach (var item in content.Parts)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(item.Key);
                    try
                    {
                        dynamic value = content.Parts[item.Key];
                        if (value.GetType() == typeof (ScriptorContentInsert))
                        {
                            dynamic valuePart = null;
                            if (value.Count > 0)
	                        {
                                valuePart = value[0].Parts[item.Key];
	                        }
                            value = valuePart;
                        }
                        prop.SetValue(obj, value);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            return obj;
        }

        protected IList<T> ListarContent<T>()
        {
            IList<T> lista = new List<T>();
            try
            {
                
                foreach (var content in contents)
                {
                    T item = CrearItem<T>(content);
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AccesoDatos);
                throw ex;
            }
            return lista;  
        }
    }
}
