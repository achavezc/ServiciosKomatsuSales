using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GR.Scriptor.Framework;
using RANSA.MCIP.DTO;

namespace RANSA.MCIP.LogicaNegocio
{

    public static class PaginacionBL
    {
        public static List<T> PaginarLista<T>(List<T> lista, RequestPaginacionBaseDTO paginacionDTO, out int nroRegistros, out int cantPaginas,string ordenDefault = "", string orientacion = "")
        {
            List<T> salida = new List<T>();
            double cantidadPaginas = 0;

            nroRegistros = lista.Count;
            if (paginacionDTO.HabilitarPaginacion == true)
            {
                bool hayorden = false;
                if (paginacionDTO.OrdenCampo != null)
                    if (paginacionDTO.OrdenCampo.Length > 0)
                        hayorden = true;
                if (!hayorden)
                {
                    paginacionDTO.OrdenCampo = ordenDefault;
                    if (orientacion != string.Empty)
                    {
                        paginacionDTO.OrdenOrientacion = orientacion;
                    }
                }

                string orden = paginacionDTO.GetOrdenamiento().Trim();
                if (orden.Length > 0)
                {
                    string sortfield = orden.Split(' ')[0].Trim();
                    string sortExpression = orden.Split(' ')[1].ToUpper().Trim();

                    if (sortExpression == "ASC")
                    {
                        salida = lista.OrderBy(x => Helper.GetPropertyValue(x, sortfield)).Skip((paginacionDTO.GetNroPagina() - 1) * paginacionDTO.GetNroFilas()).Take(paginacionDTO.GetNroFilas()).ToList();
                    }
                    else
                    {
                        salida = lista.OrderByDescending(
                                    x => Helper.GetPropertyValue(x, sortfield)
                                ).Skip((paginacionDTO.GetNroPagina() - 1) * paginacionDTO.GetNroFilas()).Take(paginacionDTO.GetNroFilas()).ToList();
                    }
                }
                else
                {
                    salida = lista.Skip((paginacionDTO.GetNroPagina() - 1) * paginacionDTO.GetNroFilas()).Take(paginacionDTO.GetNroFilas()).ToList();
                }

                cantidadPaginas = Math.Ceiling((double)nroRegistros / paginacionDTO.GetNroFilas());
                cantPaginas = (int)cantidadPaginas;
            }
            else
            {
                salida = lista;
                cantPaginas = 0;
            }


            return salida;
        }

        public static DataTable PaginarDataTable(DataTable dt, RequestPaginacionBaseDTO paginacionDTO, out int nroRegistros, string ordenDefault = "")
        {
            DataTable salida = new DataTable();

            nroRegistros = dt.Rows.Count;
            if (paginacionDTO.HabilitarPaginacion == true)
            {
                bool hayorden = false;
                if (paginacionDTO.OrdenCampo != null)
                    if (paginacionDTO.OrdenCampo.Length > 0)
                        hayorden = true;
                if (!hayorden)
                {
                    paginacionDTO.OrdenCampo = ordenDefault;
                }

                string orden = paginacionDTO.GetOrdenamiento().Trim();
                if (orden.Length > 0)
                {
                    string sortfield = orden.Split(' ')[0].Trim();
                    string sortExpression = orden.Split(' ')[1].ToUpper().Trim();

                    DataView dv = dt.DefaultView;
                    dv.Sort = sortfield + " " + sortExpression;
                    salida = dv.ToTable();
                    salida = salida.AsEnumerable().Skip((paginacionDTO.GetNroPagina() - 1) * paginacionDTO.GetNroFilas()).Take(paginacionDTO.GetNroFilas()).CopyToDataTable();
                    salida.Columns.RemoveAt(salida.Columns.Count - 1);
                }
                else
                {
                    salida = dt;
                    //salida = lista.Skip((paginacionDTO.GetNroPagina() - 1) * paginacionDTO.GetNroFilas()).Take(paginacionDTO.GetNroFilas()).ToList();
                }
            }
            else
            {
                salida = dt;
            }


            return salida;
        }
    }

}
