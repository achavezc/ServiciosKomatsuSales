using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
//using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Script.Serialization;

namespace ModuloPilotoSodexo.Helpers
{
    public static class JsonExtensions
    {
        public static string ToJson(this Object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }
        public static string ToJson2<T>(this T obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
            //string salida = "";

            //MemoryStream ms = new MemoryStream();
            //var serializerToUpload = new DataContractJsonSerializer(typeof(T));
            //serializerToUpload.WriteObject(ms, obj);
            //ms.Position = 0;
            //var sr = new StreamReader(ms);
            //salida = sr.ReadToEnd();
            //sr.Close();
            //ms.Close();

            //return salida;
        }
        public static String toJSONFormat<T>(List<T> rows, int page, int records, int total, String llave = "", List<String> orden = null)
        {
            var props = new Dictionary<String, PropertyInfo>();
            if (orden == null)
            {
                var tipo = typeof(T);
                var pis = tipo.GetProperties();
                orden = new List<string>();
                foreach (PropertyInfo pi in pis)
                {
                    props.Add(pi.Name, pi);
                }
            }
            else
            {
                var tipo = typeof(T);
                foreach (String item in orden)
                {
                    var pi = tipo.GetProperty(item);
                    if (pi != null)
                    {
                        props.Add(pi.Name, pi);
                    }
                }
            }
            if (string.IsNullOrEmpty(llave))
            {
                llave = orden[0];
            }
            var lista = new List<Helpers.Grid.JsonRow>();
            foreach (T fila in rows)
            {
                var x = fila.GetType();
                lista.Add(new Helpers.Grid.JsonRow
                {
                    id = x.GetProperty(llave).GetValue(fila, null).ToString(),
                    cell = fila
                });
            }
            var obj = new
            {
                page = page,
                records = records,
                total = total,
                rows = lista
            };
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
    }

}