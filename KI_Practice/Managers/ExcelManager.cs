namespace KI_Practice.Managers;

using Excel = Microsoft.Office.Interop.Excel;

public class ExcelManager : IDisposable
{
    private Excel.Application _excel;
    private Excel.Workbook _workBook;
    private string _filePath;
    private Excel.Worksheet _workSheet;

    public ExcelManager()
    {
        _excel = new Excel.Application();
    }

    internal bool Open(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                _workBook = _excel.Workbooks.Open(filePath);
                _workSheet = (Excel.Worksheet)_workBook.ActiveSheet;
            }
            else
            {
                _workBook = _excel.Workbooks.Add();
                _filePath = filePath;
            }
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return false;
    }

    public bool Set(string column, int row, object data)
    {
        try
        {
            ((Excel.Worksheet)_excel.ActiveSheet).Cells[row, column] = data;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return false;
    }

    public void Save()
    {
        if (!String.IsNullOrEmpty(_filePath))
        {
            _workBook.SaveAs(_filePath);
            _filePath = null;
        }
        else
        {
            _workBook.Save();
        }
    }
    public void Dispose()
    {
        try
        {
            _workBook.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public bool Merge(string el1, string el2)
    {
        try
        {
            Excel.Range excelCells = _workSheet.Range[el1, el2];
            excelCells.Merge();
            return true;
        }
        catch (Exception e)
        {
            //Console.WriteLine(e);
        }

        return false;
    }

    public bool SetRange(string el1, string el2, object[] data)
    {
        try
        {
            Excel.Range valueRange = _workSheet.Range[el1, el2];
            valueRange.Value2 = data;
            return true;
        }
        catch (Exception e)
        {
            //Console.WriteLine(e);
        }

        return false;
    }
    public bool SetRange(string el1, string el2, long[] data)
    {
        object[] temp = new object[data.Length];
        
        for (int i = 0; i < temp.Length; i++) temp[i] = data[i];
        
        return SetRange(el1, el2, temp);
    }
    
    public bool SetRange(string el1, string el2, bool[] data)
    {
        object[] temp = new object[data.Length];
        
        for (int i = 0; i < temp.Length; i++) temp[i] = data[i];
        
        return SetRange(el1, el2, temp);
    }
    
    public bool SetRange(string el1, string el2, int[] data)
    {
        try
        {
            Excel.Range valueRange = _workSheet.Range[el1, el2];
            valueRange.Value2 = data;
            return true;
        }
        catch (Exception e)
        {
            //Console.WriteLine(e);
        }

        return false;
    }

    public bool MakeChart(double left, double top, double width, double height, string name, string categoryTitle, string valueTitle)
    {
        try
        {
            Excel.ChartObjects chartObjects = (Excel.ChartObjects)_workSheet.ChartObjects();
            Excel.ChartObject chartObject = chartObjects.Add(left, top, width, height);
            chartObject.Chart.ChartWizard(_workSheet.get_Range("C2", "L4"), Excel.XlChartType.xl3DArea,2,
                Excel.XlRowCol.xlRows,Type.Missing,
                0,true,name, categoryTitle, valueTitle,Type.Missing);
            
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return false;
    }

    /*public bool MakeChart(string startPoint, string endPoint, string title, string categoryName, int[] values,
        string value1Name, string value2Name = "", string value3Name = "", string value4Name = "")
    {
        try
        {
            _workSheets = _workBook.Worksheets; 
            _workSheet = (Excel.Worksheet)_workSheets.get_Item(1);
            //Определяем диаграммы как объекты Excel.ChartObjects
            Excel.ChartObjects chartsObjects = 
                (Excel.ChartObjects)_workSheet.ChartObjects(Type.Missing);
            //Добавляем одну диаграмму  в Excel.ChartObjects - диаграмма пока 
            //не выбрана, но место для нее выделено в методе Add
            Excel.ChartObject chartsObject = chartsObjects.Add(10,200,500,400);
            Excel.Range excelCells = _workSheet.get_Range(startPoint, endPoint);
            //Получаем ссылку на созданную диаграмму
            Excel.Chart excelChart = chartsObject.Chart;
            //Устанавливаем источник данных для диаграммы
            excelChart.SetSourceData(excelCells,Type.Missing);
            
            
            _excel.ActiveChart.ChartType = Excel.XlChartType.xlArea;
            _excel.ActiveChart.HasTitle = true;
            _excel.ActiveChart.ChartTitle.Text = title;
            _excel.ActiveChart.ChartTitle.Font.Size = 14;
            
            ((Excel.Axis)_excel.ActiveChart.Axes(Excel.XlAxisType.xlCategory,
                Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
            ((Excel.Axis)_excel.ActiveChart.Axes(Excel.XlAxisType.xlCategory,
                Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = categoryName;
            ((Excel.Axis)_excel.ActiveChart.Axes(Excel.XlAxisType.xlSeriesAxis,
                Excel.XlAxisGroup.xlPrimary)).HasTitle = false;
            ((Excel.Axis)_excel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
            if (value4Name == "")
            {
                if (value3Name == "")
                {
                    if (value2Name == "")
                    {
                        ((Excel.Axis)_excel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                            Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = value1Name;
                    }
                    else
                    {
                        ((Excel.Axis)_excel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                            Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = value1Name + "/" + value2Name;
                    }
                }
                else
                {
                    ((Excel.Axis)_excel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                        Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = value1Name + "/" + value2Name + "/" + value3Name;
                }
            }
            else
            {
                ((Excel.Axis)_excel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                    Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = value1Name + "/" + value2Name + "/" + value3Name + "/" + value4Name;
            }

            _excel.ActiveChart.HasLegend = true;
            _excel.ActiveChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionLeft;
            ((Excel.LegendEntry)_excel.ActiveChart.Legend.LegendEntries(1)).Font.Size=12;
            ((Excel.LegendEntry)_excel.ActiveChart.Legend.LegendEntries(2)).Font.Size=12;
            ((Excel.LegendEntry)_excel.ActiveChart.Legend.LegendEntries(3)).Font.Size=12;
            ((Excel.LegendEntry)_excel.ActiveChart.Legend.LegendEntries(4)).Font.Size=12;
            
            //Легенда тесно связана с подписями на осях - изменяем надписи
            // - меняем легенду, удаляем чтото на оси - изменяется легенда
            Excel.SeriesCollection seriesCollection = (Excel.SeriesCollection)_excel.ActiveChart.SeriesCollection(Type.Missing);
            Excel.Series series = seriesCollection.Item(1);
            series.Name = value1Name;
            if (value2Name != "")
            {
                series = seriesCollection.Item(2); 
                series.Name = value2Name;
            }
            if (value3Name != "")
            {
                series = seriesCollection.Item(3); 
                series.Name = value3Name;
            }
            if (value4Name != "")
            {
                series = seriesCollection.Item(4); 
                series.Name = value4Name;
            }
            series = seriesCollection.Item(1);
            //Переименуем ось X
            string valuesString = "";
            for (int i = 0; i < values.Length - 1; i++)
            {
                valuesString += values[i] + ";";
            }

            valuesString += values[values.Length - 1];

            series.XValues = valuesString;

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return false;
    }*/
    
}