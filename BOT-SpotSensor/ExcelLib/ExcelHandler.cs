using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelLib
{
    public class ExcelHandler
    {
        public static void CreateNewExcelFile(string filename)
        {
            //Creates an Excel Application instance
            var excelAplication = new Excel.Application();
            excelAplication.Visible = true;

            //Creates an Excel Workbook with a defaullt number of sheets.
            var excelWorkbook = excelAplication.Workbooks.Add();
            excelWorkbook.SaveAs(filename, AccessMode: Excel.XlSaveAsAccessMode.xlNoChange);

            //"Eliminates" the instances
            excelWorkbook.Close();
            excelAplication.Quit();

            //It's necessary to free all the memory used by the excel objects. e.g.:
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook)
            //...
            //GC.Collect();
            ReleaseCOMObjects(excelWorkbook);
            ReleaseCOMObjects(excelAplication);
        }

        public static void ReleaseCOMObjects(Object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        public static void WriteToExcelFile(string filename)
        {
            Excel.Application excelApplication = new Excel.Application();
            excelApplication.Visible = true;

            //Opens the excel file
            Excel.Workbook excelWorkbook = excelApplication.Workbooks.Open(filename);
            Excel.Worksheet excelWorksheet = excelApplication.ActiveSheet;

            excelWorksheet.Cells[1, 1].Value = "Hello";
            excelWorksheet.Cells[1, 2].Value = "World!";

            //you may also use the get_Item(1) method where '1' is the worksheet number
            Excel.Worksheet excelWorksheet2 = excelWorkbook.Worksheets.Add();
            excelWorksheet2.Cells[1, 1].Value = "Goodbye";
            excelWorksheet2.Cells[1, 2].Value = "world!";

            excelWorkbook.Save();
            excelWorkbook.Close();
            excelApplication.Quit();

            ReleaseCOMObjects(excelWorksheet);
            ReleaseCOMObjects(excelWorksheet2);
            ReleaseCOMObjects(excelWorkbook);
            ReleaseCOMObjects(excelApplication);
        }

        public static string ReadFromExcelFile(string filename)
        {
            var excelApplication = new Excel.Application();
            excelApplication.Visible = false;

            //Opens the excel file
            var excelWorkbook = excelApplication.Workbooks.Open(filename);
            var excelWorksheet = (Excel.Worksheet)excelWorkbook.ActiveSheet;

            string content = excelWorksheet.Cells[1, 1].Value;
            content += (excelWorksheet.Cells[1, 2] as Excel.Range).Text;

            excelWorkbook.Close();
            excelApplication.Quit();

            ReleaseCOMObjects(excelWorksheet);
            ReleaseCOMObjects(excelWorkbook);
            ReleaseCOMObjects(excelApplication);

            return content;
        }

        public static void CreateChart(string filename)
        {
            Excel.Application excelApplication = new Excel.Application();
            excelApplication.Visible = true;

            //Opens the excel file
            Excel.Workbook excelWorkbook = excelApplication.Workbooks.Add();
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Worksheets.get_Item(1);

            excelWorksheet.Cells[1, 1] = "Product ID";
            excelWorksheet.Cells[1, 2] = "Stock";
            excelWorksheet.Cells[2, 1] = "BB12";
            excelWorksheet.Cells[2, 2] = "15";
            excelWorksheet.Cells[3, 1] = "xy40";
            excelWorksheet.Cells[3, 2] = "18";
            excelWorksheet.Cells[4, 1] = "AX50";
            excelWorksheet.Cells[4, 2] = "23";

            //Add a char object
            Excel.Chart myChart = null;
            Excel.ChartObjects charts = excelWorksheet.ChartObjects();
            Excel.ChartObject chartObj = charts.Add(50, 50, 300, 300); //left; top; width; height
            myChart = chartObj.Chart;

            //set chart range -- cell values to be used in the graph
            Excel.Range myRange = excelWorksheet.get_Range("B1:B4");
            myChart.SetSourceData(myRange);

            //chart properties using the named properties and default parameters functionality in
            //the .Net Framework
            myChart.ChartType = Excel.XlChartType.xlLine;
            myChart.ChartWizard(Source: myRange,
                Title: "Graph Title",
                CategoryTitle: "Title of X axis... ",
                ValueTitle: "Title of Y axis... ");

            excelWorkbook.SaveAs(filename);
            excelWorkbook.Close();
            excelApplication.Quit();

            ReleaseCOMObjects(excelWorksheet);
            ReleaseCOMObjects(excelWorkbook);
            ReleaseCOMObjects(excelApplication);
        }

        public static List<string> ReadNxMCells(string filename, string n, string m)
        {
            var excelApplication = new Excel.Application();
            excelApplication.Visible = false;

            //Opens the excel file
            var excelWorkbook = excelApplication.Workbooks.Open(filename);
            var excelWorksheet = (Excel.Worksheet)excelWorkbook.Worksheets.get_Item(1);

            var range = excelWorksheet.get_Range(n + ":" + m);
            List<string> content = new List<string>();

            foreach (Excel.Range r in range)
            {
                content.Add(r.Value);
            }

            excelWorkbook.Close();
            excelApplication.Quit();

            ReleaseCOMObjects(excelWorksheet);
            ReleaseCOMObjects(excelWorkbook);
            ReleaseCOMObjects(excelApplication);

            return content;
        }

        public static string ReadFromEspecificWorksheet(string filename, int i)
        {
            var excelApplication = new Excel.Application();
            excelApplication.Visible = false;

            //Opens the excel file
            var excelWorkbook = excelApplication.Workbooks.Open(filename);
            var excelWorksheet = (Excel.Worksheet)excelWorkbook.Worksheets.get_Item(i);

            Excel.Range r = excelWorksheet.UsedRange;

            excelWorkbook.Close();
            excelApplication.Quit();

            ReleaseCOMObjects(excelWorksheet);
            ReleaseCOMObjects(excelWorkbook);
            ReleaseCOMObjects(excelApplication);

            return null;
        }
    }
}
