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
        private const string FILE_NAME = "SolicitudesBook.xlsx";

        private bool Exists(string bookLocation)
        {

            return File.Exists(FILE_NAME);
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

        public DataTable GetData(string bookLocation, string sheetName)
        {
            try
            {
                DataTable dt = new DataTable();
                int row = 0;

                if (!this.Exists(bookLocation))
                {
                    throw new Exception("Porfavor descargue la pplantilla");
                }
                using (SLDocument doc = new SLDocument(bookLocation, sheetName))
                {
                    SLWorksheetStatistics info = doc.GetWorksheetStatistics();
                    int iStartColumnIndex = info.StartColumnIndex;
                    int iEndColumnIndex = info.EndColumnIndex;

                    for (int columnIndex = 0; columnIndex <= info.EndColumnIndex; columnIndex++)
                    {
                        string name = doc.GetCellValueAsString(0, columnIndex);
                        dt.Columns.Add(new DataColumn(name));
                    }

                    for (row = info.StartRowIndex + 1; row <= info.EndRowIndex; ++row)
                    {
                        DataRow tr = dt.NewRow();
                        for (int column = 0; column <= iEndColumnIndex; column++)
                        {
                            tr[column] = doc.GetCellValueAsString(row, column);
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

        public bool SaveData(string bookLocation, string sheetName, Dictionary<int, int> key, Dictionary<int, string> values)
        {
            try
            {
                int row = 0;
                bool saved = false;

                if (!this.Exists(bookLocation))
                {
                    throw new Exception("Porfavor descargue la pplantilla");
                }
                using (SLDocument doc = new SLDocument(bookLocation, sheetName))
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
                            for (int column = 0; column <= iEndColumnIndex; column++)
                            {
                                string value = values.FirstOrDefault(x => x.Key == column).Value;
                                doc.SetCellValue(row, column, value);
                            }
                            saved = true;
                        }
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