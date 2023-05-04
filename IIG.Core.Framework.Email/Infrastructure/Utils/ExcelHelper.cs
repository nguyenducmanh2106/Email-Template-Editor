using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email.Infrastructure.Utils
{
    public class ExcelHelper
    {
        private readonly IWebHostEnvironment _env;

        public ExcelHelper(IWebHostEnvironment env)
        {
            _env = env;
        }

        public static DataTable ReadExcelasDataTable(string fileName)
        {
            try
            {
                DataTable dt = new();
                using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(fileName, false))
                {
                    WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
                    IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                    string relationshipId = sheets.First().Id.Value;
                    WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
                    Worksheet workSheet = worksheetPart.Worksheet;
                    SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                    IEnumerable<Row> rows = sheetData.Descendants<Row>();
                    foreach (Cell cell in rows.ElementAt(0))
                    {
                        dt.Columns.Add(GetCellValue(spreadSheetDocument, cell));
                    }
                    foreach (Row row in rows)
                    {
                        DataRow tempRow = dt.NewRow();
                        int columnIndex = 0;
                        foreach (Cell cell in row.Descendants<Cell>())
                        {
                            int cellColumnIndex = (int)GetColumnIndexFromName(GetColumnName(cell.CellReference));
                            cellColumnIndex--;
                            if (columnIndex < cellColumnIndex)
                            {
                                do
                                {
                                    tempRow[columnIndex] = "";
                                    columnIndex++;
                                }
                                while (columnIndex < cellColumnIndex);
                            }
                            tempRow[columnIndex] = GetCellValue(spreadSheetDocument, cell);

                            columnIndex++;
                        }
                        dt.Rows.Add(tempRow);
                    }
                }

                dt.Rows.RemoveAt(0);

                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static DataTable ReadExcelasDataTable(Stream stream)
        {
            try
            {
                DataTable dt = new();
                using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(stream, false))
                {
                    WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
                    IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                    string relationshipId = sheets.First().Id.Value;
                    WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
                    Worksheet workSheet = worksheetPart.Worksheet;
                    SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                    IEnumerable<Row> rows = sheetData.Descendants<Row>();
                    foreach (Cell cell in rows.ElementAt(0))
                    {
                        dt.Columns.Add(GetCellValue(spreadSheetDocument, cell));
                    }
                    foreach (Row row in rows)
                    {
                        DataRow tempRow = dt.NewRow();
                        int columnIndex = 0;
                        foreach (Cell cell in row.Descendants<Cell>())
                        {
                            int cellColumnIndex = (int)GetColumnIndexFromName(GetColumnName(cell.CellReference));
                            cellColumnIndex--;
                            if (columnIndex < cellColumnIndex)
                            {
                                do
                                {
                                    tempRow[columnIndex] = "";
                                    columnIndex++;
                                }
                                while (columnIndex < cellColumnIndex);
                            }
                            tempRow[columnIndex] = GetCellValue(spreadSheetDocument, cell);

                            columnIndex++;
                        }
                        dt.Rows.Add(tempRow);
                    }
                }

                dt.Rows.RemoveAt(0);

                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static string GetColumnName(string cellReference)
        {
            Regex regex = new("[A-Za-z]+");
            Match match = regex.Match(cellReference);
            return match.Value;
        }

        public static int? GetColumnIndexFromName(string columnName)
        {
            string name = columnName;
            int number = 0;
            int pow = 1;
            for (int i = name.Length - 1; i >= 0; i--)
            {
                number += (name[i] - 'A' + 1) * pow;
                pow *= 26;
            }
            return number;
        }

        public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            if (cell.CellValue == null)
            {
                return "";
            }
            string value = cell.CellValue.InnerXml;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }

        internal static string GetCopyExcelTemplateFile()
        {
            string
                newFile = Guid.NewGuid() + "-" + "Excel.xlsx",
                templateFile = "Template\\DANH GIA CUOI NAM.xlsx",
                tempFile = Path.GetDirectoryName(templateFile) + "\\" + newFile;

            File.Copy(templateFile, tempFile, true);

            return tempFile;
        }
        internal static string GetCopyExcelTemplateFile(string templateFileCropPath, string downloadPath, string fileName, bool overWrite = true)
        {
            var newfilePath = string.Format("{0}\\{1}", downloadPath, fileName);
            var templateFilePath = $"{templateFileCropPath.Replace("/", "\\")}{1}".Replace("\\\\", "\\");

            File.Copy(templateFilePath, newfilePath, overWrite);

            return newfilePath;
        }

        internal static bool WriteExcel(string[,] array, List<dynamic> dynamicData, string excelFile, int rowIndex)
        {
            using SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(excelFile, true);
            int i = 0;
            WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;

            Sheet sheet = spreadsheetDocument.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

            Worksheet worksheet = (spreadsheetDocument.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;

            SheetData sheetData = worksheet.GetFirstChild<SheetData>();

            if (dynamicData != null && dynamicData.Any())
            {
                foreach (var item in dynamicData)
                {
                    i++;
                    // update cell value
                    var cell = sheetData.Elements<Row>().Where(x => x.RowIndex == item.RowIndex).FirstOrDefault().Elements<Cell>().Where(x => string.Compare(x.CellReference.Value, item.ColumnName + item.RowIndex, true) == 0).FirstOrDefault();
                    cell.CellValue = new CellValue(item.Value);
                    cell.DataType = new EnumValue<CellValues>(CellValues.String);
                }
            }

            SetSheetData(sheetData, array, rowIndex);

            spreadsheetDocument.WorkbookPart.Workbook.Save();
            spreadsheetDocument.Close();
            return true;
        }

        internal static FileResult WriteExcelDownloadAndDelete(string[,] array, List<dynamic> dynamicData, string excelFile, int rowIndex, string downloadFileName = "", bool deleteFile = true)
        {
            if (!WriteExcel(array, dynamicData, excelFile, rowIndex))
            {
                return null;
            }

            //Download
            var result = FileHelper.DownloadFile(excelFile, downloadFileName);

            if (deleteFile)
            {
                if (File.Exists(excelFile))
                {
                    File.Delete(excelFile);
                }
            }

            return result;
        }

        internal static void WriteToExcelFile(string[,] array, List<dynamic> dynamicData, string excelFile, int rowIndex)
        {
            using SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(excelFile, true);
            WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;

            Sheet sheet = spreadsheetDocument.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

            Worksheet worksheet = (spreadsheetDocument.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;

            SheetData sheetData = worksheet.GetFirstChild<SheetData>();

            SetSheetData(sheetData, array, rowIndex);

            if (dynamicData != null && dynamicData.Any())
            {
                foreach (var item in dynamicData)
                {
                    // update cell value
                    var cell = sheetData.Elements<Row>().Where(x => x.RowIndex == item.RowIndex).FirstOrDefault().Elements<Cell>().Where(x => string.Compare(x.CellReference.Value, item.ColumnName + item.RowIndex, true) == 0).FirstOrDefault();
                    cell.CellValue = new CellValue(item.Value);
                    cell.DataType = new EnumValue<CellValues>(CellValues.String);
                }
            }

            spreadsheetDocument.WorkbookPart.Workbook.Save();

            spreadsheetDocument.Close();
        }
        static string ReplaceHexadecimalSymbols(string txt)
        {
            string r = "[\x00-\x08\x0B\x0C\x0E-\x1F\x26]";
            return Regex.Replace(txt, r, "", RegexOptions.Compiled);
        }

        private static void SetSheetData(SheetData sheetData, string[,] array, int rowIndex)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Row insertRow = new();
                insertRow.RowIndex = (UInt32)(i + rowIndex);

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Cell cell = CreateTextCell(j + 1, Convert.ToInt32(insertRow.RowIndex.Value), ReplaceHexadecimalSymbols(array[i, j]));

                    insertRow.AppendChild(cell);
                }

                sheetData.AppendChild(insertRow);
            }
        }

        private static Cell CreateTextCell(int columnIndex, int rowIndex, string cellValue)
        {
            Cell cell = new()
            {
                CellReference = GetColumnName(columnIndex.ToString()) + rowIndex,

                DataType = CellValues.InlineString
            };
            InlineString inlineString = new();
            Text text = new()
            {
                Text = cellValue == null ? "" : cellValue.ToString()
            };
            inlineString.AppendChild(text);
            cell.AppendChild(inlineString);

            return cell;
        }

        private static Stylesheet GenerateStylesheet()
        {
            Fonts fonts = new(
                new Font( // Index 0 - default
                    new FontSize() { Val = 10 }

                ),
                new Font( // Index 1 - header
                    new FontSize() { Val = 10 },
                    new Bold(),
                    new Color() { Rgb = "FFFFFF" }

                ));

            Fills fills = new(
                    new Fill(new PatternFill() { PatternType = PatternValues.None }), // Index 0 - default
                    new Fill(new PatternFill() { PatternType = PatternValues.Gray125 }), // Index 1 - default
                    new Fill(new PatternFill(new ForegroundColor { Rgb = new HexBinaryValue() { Value = "66666666" } })
                    { PatternType = PatternValues.Solid }) // Index 2 - header
                );

            Borders borders = new(
                    new Border(), // index 0 default
                    new Border( // index 1 black border
                        new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new DiagonalBorder())
                );

            CellFormats cellFormats = new(
                    new CellFormat(), // default
                    new CellFormat { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true }, // body
                    new CellFormat { FontId = 1, FillId = 2, BorderId = 1, ApplyFill = true } // header
                );

            Stylesheet styleSheet = new(fonts, fills, borders, cellFormats);
            return styleSheet;
        }
    }
}
