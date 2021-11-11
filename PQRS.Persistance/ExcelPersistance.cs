using System;
using System.Collections.Generic;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using System.IO;
using System.Data;
using System.Linq;

namespace PQRS.Persistance
{
    public class SheetType
    {
        public const string SOLICITUD = "Solicitud";
        public const string PETICION = "Peticion";
        public const string QUEJA = "Queja";
        public const string RECLAMO = "Reclamo";
        public const string SUGERENCIA = "Sugerencia";
        public const string FELICITACION = "Feliticiones";
    }
    public class ExcelPersistance
    {
        private string FILE_NAME = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SolicitudesBook.xlsx");

        private void ValidateFile()
        {

            if (!File.Exists(FILE_NAME)) {
                this.CreateFile();
            }
        }

        private DataTable CreateDataTableByType(string sheetType)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Area", typeof(int)));
            dt.Columns.Add(new DataColumn("IdCliente", typeof(int)));
            dt.Columns.Add(new DataColumn("Servicio", typeof(int)));
            dt.Columns.Add(new DataColumn("TipoSoli", typeof(int)));
            dt.Columns.Add(new DataColumn("Fecha", typeof(string)));

            switch (sheetType)
            {
                case SheetType.PETICION:
                    dt.Columns.Add(new DataColumn("IdPeticion", typeof(int)));
                    dt.Columns.Add(new DataColumn("IdSupervisor", typeof(int)));
                    break;
                case SheetType.QUEJA:
                    dt.Columns.Add(new DataColumn("IdQueja", typeof(int)));
                    dt.Columns.Add(new DataColumn("IdSupervisor", typeof(int)));
                    dt.Columns.Add(new DataColumn("IdTipoResumenaracion", typeof(int)));
                    dt.Columns.Add(new DataColumn("IdTipoResumenaracion", typeof(int)));
                    break;
                case SheetType.RECLAMO:
                    dt.Columns.Add(new DataColumn("IdReclamo", typeof(int)));
                    dt.Columns.Add(new DataColumn("IdSolucion", typeof(int)));
                    dt.Columns.Add(new DataColumn("Costo", typeof(double)));
                    break;
                case SheetType.SUGERENCIA:
                    dt.Columns.Add(new DataColumn("IdSugerencia", typeof(int)));
                    dt.Columns.Add(new DataColumn("IdsuperviSln", typeof(int)));
                    dt.Columns.Add(new DataColumn("IdTipoSugerencia", typeof(int)));
                    dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
                    break;
                case SheetType.FELICITACION:
                    dt.Columns.Add(new DataColumn("IdFelicitacion", typeof(int)));
                    dt.Columns.Add(new DataColumn("Descripcion", typeof(int)));
                    break;
                default:
                    break;
            }
            return dt;
        }

        private void CreateFile() {
            try
            {
                using (SLDocument doc = new SLDocument())
                {
                    doc.AddWorksheet(SheetType.PETICION);
                    doc.SetCellValue(1, 1, "Area");
                    doc.SetCellValue(1, 2, "IdCliente");
                    doc.SetCellValue(1, 3, "Servicio");
                    doc.SetCellValue(1, 4, "TipoSoli");
                    doc.SetCellValue(1, 5, "Fecha");
                    doc.SetCellValue(1, 6, "IdPeticion");
                    doc.SetCellValue(1, 7, "IdSupervisor");

                    doc.AddWorksheet(SheetType.QUEJA);
                    doc.SetCellValue(1, 1, "Area");
                    doc.SetCellValue(1, 2, "IdCliente");
                    doc.SetCellValue(1, 3, "Servicio");
                    doc.SetCellValue(1, 4, "TipoSoli");
                    doc.SetCellValue(1, 5, "Fecha");
                    doc.SetCellValue(1, 6, "IdQueja");
                    doc.SetCellValue(1, 7, "IdSupervisor");
                    doc.SetCellValue(1, 8, "IdTipoResumenaracion");

                    doc.AddWorksheet(SheetType.RECLAMO);
                    doc.SetCellValue(1, 1, "Area");
                    doc.SetCellValue(1, 2, "IdCliente");
                    doc.SetCellValue(1, 3, "Servicio");
                    doc.SetCellValue(1, 4, "TipoSoli");
                    doc.SetCellValue(1, 5, "Fecha");
                    doc.SetCellValue(1, 6, "IdReclamo");
                    doc.SetCellValue(1, 7, "IdSolucion");
                    doc.SetCellValue(1, 8, "Costo");

                    doc.AddWorksheet(SheetType.SUGERENCIA);
                    doc.SetCellValue(1, 1, "Area");
                    doc.SetCellValue(1, 2, "IdCliente");
                    doc.SetCellValue(1, 3, "Servicio");
                    doc.SetCellValue(1, 4, "TipoSoli");
                    doc.SetCellValue(1, 5, "Fecha");
                    doc.SetCellValue(1, 6, "IdSugerencia");
                    doc.SetCellValue(1, 7, "IdsuperviSln");
                    doc.SetCellValue(1, 8, "IdTipoSugerencia");
                    doc.SetCellValue(1, 9, "Descripcion");

                    doc.AddWorksheet(SheetType.FELICITACION);
                    doc.SetCellValue(1, 1, "Area");
                    doc.SetCellValue(1, 2, "IdCliente");
                    doc.SetCellValue(1, 3, "Servicio");
                    doc.SetCellValue(1, 4, "TipoSoli");
                    doc.SetCellValue(1, 5, "Fecha");
                    doc.SetCellValue(1, 6, "IdFelicitacion");
                    doc.SetCellValue(1, 7, "Descripcion");

                    doc.SaveAs(FILE_NAME);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetData(string sheetName)
        {
            try
            {
                this.ValidateFile();

                DataTable dt = new DataTable();
                int row = 1;

                using (SLDocument doc = new SLDocument(FILE_NAME, sheetName))
                {
                    SLWorksheetStatistics info = doc.GetWorksheetStatistics();
                    int iStartColumnIndex = info.StartColumnIndex;
                    int iEndColumnIndex = info.EndColumnIndex;

                    for (int columnIndex = 1; columnIndex <= info.EndColumnIndex; columnIndex++)
                    {
                        string name = doc.GetCellValueAsString(1, columnIndex);
                        dt.Columns.Add(new DataColumn(name));
                    }

                    for (row = info.StartRowIndex + 1; row <= info.EndRowIndex; ++row)
                    {
                        DataRow tr = dt.NewRow();
                        for (int column = 1; column <= iEndColumnIndex; column++)
                        {
                            tr[column - 1] = doc.GetCellValueAsString(row, column);
                        }
                        dt.Rows.Add(tr);
                    }
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SaveData(string sheetName, Dictionary<int, int> key, Dictionary<int, string> values)
        {
            try
            {
                this.ValidateFile();

                int row = 1;
                bool saved = false;

                using (SLDocument doc = new SLDocument(FILE_NAME, sheetName))
                {
                    SLWorksheetStatistics info = doc.GetWorksheetStatistics();
                    int iStartColumnIndex = info.StartColumnIndex;
                    int iEndColumnIndex = info.EndColumnIndex;

                    for (row = info.StartRowIndex + 1; row <= info.EndRowIndex; ++row)
                    {
                        int keyIndex = key.Select(x => x.Key).FirstOrDefault();
                        int keyValue = key.FirstOrDefault(x => x.Key == keyIndex).Value;
                        if (doc.GetCellValueAsString(row, keyIndex).Trim().ToLower().Equals(keyValue.ToString().ToLower()))
                        {   
                            for (int column = 1; column <= iEndColumnIndex; column++)
                            {
                                string value = values.FirstOrDefault(x => x.Key == column - 1).Value;
                                doc.SetCellValue(row, column, value);
                            }
                            saved = true;
                        }
                    }
                    if (!saved) {
                        for (int column = 1; column <= iEndColumnIndex; column++)
                        {
                            string value = values.FirstOrDefault(x => x.Key == column - 1).Value;
                            doc.SetCellValue(row, column, value);
                        }
                        saved = true;
                    }

                }
                return saved;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}