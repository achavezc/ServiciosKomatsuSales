using ModuloPilotoSodexo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GR.Scriptor.Msc.Memberships.Models;
using GR.Scriptor.Msc.Memberships;

namespace ModuloPilotoSodexo.Helpers
{
    public class Helper
    {
        public static ResponseUsuarioMscDTO GetUsuario()
        {
            ResponseUsuarioMscDTO usuario = HelperSeguridad.ObtenerSessionUsuarioMsc();
            return usuario;
        }

        public static String GetSociedadPropietaria()
        {
            return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["SociedadPropietariaNotificaciones"]);
        }
        public static Dictionary<string, object> GetErrorsFromModelState(ref String Errores, ModelStateDictionary ModelState)
        {
            var errors = new Dictionary<string, object>();
            foreach (var key in ModelState.Keys)
            {
                if (ModelState[key].Errors.Count > 0)
                {
                    var unerror = string.Empty;
                    foreach (ModelError item in ModelState[key].Errors)
                    {
                        unerror += item.ErrorMessage + "\n";
                    }

                    Errores += unerror;
                    errors[key] = unerror;
                }
            }

            return errors;
        }
    }
}