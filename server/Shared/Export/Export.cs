using System.Data;
using ClosedXML.Excel;
using server.Shared.Convert;

namespace server.Shared.Export;

public class Export
{
    private Dictionary< string, DataTable> sheets = [];
    
    public void AddExcelSheet<T>(List<T> value, string nameSheet)
    {
        var dataTable = value.ListObjectToDataTable();
        sheets.Add(nameSheet, dataTable); 
    }
    
    public (Byte[] , string) ToExcel()
    {
        if (sheets.Count <= 0) throw new Exception("Não tem nenhuma planilha para ser colocada no arquivo!");
        using var wb = new XLWorkbook();
        var i = 0;
        foreach (var planilha in sheets)
        {
            wb.AddWorksheet(planilha.Value, planilha.Key);
        }

        using var ms = new MemoryStream();
        wb.SaveAs(ms);
        return (ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
    }
}