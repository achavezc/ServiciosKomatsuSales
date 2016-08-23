using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.ComponentModel;
using GR.Scriptor.Framework;
using OfficeOpenXml;
using OfficeOpenXml.Style;
//using ClosedXML.Excel;


namespace GR.Scriptor.Frameworks.Comun
{
    public class ExportarExcelV2
    {
        public static void List2Excel(HttpResponseBase responsePage, DataTable DataTablelista, String tituloReporte, String nombreArchivo, List<ReportColumnHeader> columnsNames)
        {
            var filename = nombreArchivo;
            //ordena columnas dearcuerdo el backoffice
            int contadorOrden = 0;
            for (int i = 0; i < columnsNames.Count; i++)
            {
                string nombrecolumna = columnsNames[i].BindField;
                DataColumn col = DataTablelista.Columns[nombrecolumna];
                if (col != null)
                {
                    DataTablelista.Columns[nombrecolumna].SetOrdinal(contadorOrden);
                    contadorOrden++;
                }
            }
            //pone nombres a las columnas
            List<DataColumn> lstIndexremoves = new List<DataColumn>();
            for (int i = 0; i < DataTablelista.Columns.Count; i++)
            {
                DataColumn col = DataTablelista.Columns[i];
                ReportColumnHeader mcolumn = columnsNames.Find(x => x.BindField == col.ColumnName);

                if (mcolumn == null)
                {
                    lstIndexremoves.Add(col);
                }
                else
                {
                    if (mcolumn.FlgOculto == "1")
                        lstIndexremoves.Add(col);
                    else
                        DataTablelista.Columns[i].ColumnName = mcolumn.HeaderName;
                }
            }

            //elimina columnas innecesarias.
            for (int i = 0; i < lstIndexremoves.Count; i++)
            {
                DataTablelista.Columns.Remove(lstIndexremoves[i]);
            }


            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Hoja 1");
            workSheet.Cells[1, 1].Value = "" + tituloReporte + "";
            workSheet.Cells[1, 1].Style.Font.Bold = true;
            workSheet.Cells[1, 1].Style.Font.Size = 24;
            workSheet.Cells[1, 1].Style.Font.Name = "Calibri";
            workSheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Cells["A1:J2"].Merge = true;

            workSheet.Cells[3, 1].Value = "Fecha de generación:";
            workSheet.Cells[3, 1].Style.Font.Bold = true;
            workSheet.Cells[3, 1].Style.Font.Size = 11;
            workSheet.Cells[3, 1].Style.Font.Name = "Calibri";
            workSheet.Cells[3, 1].Style.WrapText = true;
            workSheet.Cells[3, 2].Value = DateTime.Now.ToLongDateString();
            //workSheet.Cells[3, 2].Style.Font.Size = 11;
            //workSheet.Cells[3, 2].Style.Font.Name = "Calibri";            
            //workSheet.Cells[3, 2].Style.HorizontalAlignment= ExcelHorizontalAlignment.General;
            //workSheet.Cells[3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Bottom;
            //workSheet.Cells[3, 2].Style.WrapText = false;
            //workSheet.Cells[3, 2].Style.Indent = 0;
            //workSheet.Cells[3, 2].Style.ShrinkToFit = false;

            workSheet.Cells[5, 1].LoadFromDataTable(DataTablelista, true);
            workSheet.Cells.AutoFitColumns();
            for (int i = 1; i <= DataTablelista.Columns.Count; i++)
            {
                workSheet.Column(i).AutoFit();
                workSheet.Column(i).BestFit = true;

                workSheet.Cells[5, i].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[5, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[5, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Black);
                workSheet.Cells[5, i].Style.Font.Size = 11;
                workSheet.Cells[5, i].Style.Font.Name = "Calibri";
            }
            workSheet.Column(1).Width = 20;
            int maxpos = 6;

            ExcelRange rangoTabla = workSheet.Cells[maxpos, 1, maxpos + DataTablelista.Rows.Count - 1, DataTablelista.Columns.Count];

            rangoTabla.Style.Fill.PatternType = ExcelFillStyle.Solid;
            rangoTabla.Style.Font.Color.SetColor(System.Drawing.Color.Black);
            rangoTabla.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.White);
            rangoTabla.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

            rangoTabla.Style.Font.Size = 11;
            rangoTabla.Style.Font.Name = "Calibri";
            rangoTabla.Style.WrapText = true;

            responsePage.Clear();


            using (MemoryStream memoryStream = new MemoryStream())
            {
                responsePage.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                responsePage.AddHeader("content-disposition", String.Format(@"attachment;filename={0}.xlsx", filename.Replace(" ", "_")));
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(responsePage.OutputStream);
                responsePage.Flush();
                responsePage.End();
            }
        }
        public static void List2Excel<T>(HttpResponseBase responsePage, IList<T> lista, String tituloReporte, String nombreArchivo, List<ReportColumnHeader> columnsNames)
        {

            DataTable DataTablelista;
            DataTablelista = CollectionHelper.ConvertTo(lista);
            List2Excel(responsePage, DataTablelista, tituloReporte, nombreArchivo, columnsNames);
        }
    }

}
