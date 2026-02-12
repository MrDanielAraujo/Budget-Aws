using System.ComponentModel;
using System.Data;
using System.Linq.Dynamic.Core;
using System.Reflection;
using ClosedXML.Excel;
using NPOI.XSSF.UserModel;

namespace server.Shared.Convert;

public static class Convert
{

    public static DataTable ListObjectToDataTable<T>(this List<T> list)
    {
        var properties = TypeDescriptor.GetProperties(typeof(T));
        var dt = new DataTable();
        foreach (PropertyDescriptor prop in properties)
        {
            if (typeof(T).GetProperty(prop.Name)!.GetMethod!.IsVirtual) continue;
            
            dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        }

        foreach (var item in list)
        {
            var dr = dt.NewRow();
            foreach (PropertyDescriptor prop in properties)
            {
                if (typeof(T).GetProperty(prop.Name)!.GetMethod!.IsVirtual) continue;
                dr[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            }

            dt.Rows.Add(dr);
        }

        return dt;
    }
    
    public static List<T> XlsxToListObject<T>(this Stream arq)
    {
        var list = new List<T>();
        var typeOfObject = typeof(T);
        using IXLWorkbook workbook = new XLWorkbook(arq);
        var worksheet = workbook.Worksheets.First();
        var properties = typeOfObject.GetProperties();
        var columns = worksheet.FirstRow().Cells().Select((v, i) => new { v.Value, Index = i + 1 });
        foreach (var row in worksheet.RowsUsed().Skip(1))
        {
            var obj = (T)Activator.CreateInstance(typeOfObject)!;
            foreach (var prop in properties)
            {
                var colIndex = columns.SingleOrDefault(c => c.Value.ToString() == prop.Name.ToString())!.Index;
                var val = row.Cell(colIndex).Value;
                var type = prop.PropertyType;
                prop.SetValue(obj, System.Convert.ChangeType(val, type));
            }
            list.Add(obj);
        }
        return list;
    }
    
    
    public static DataTable XlsxToDataTable(this Stream arq)
    {
        var table = new DataTable();
        using IXLWorkbook workbook = new XLWorkbook(arq);
        var worksheet = workbook.Worksheets.First();
        
        foreach (var col in worksheet.FirstRow().Cells())
        {
            table.Columns.Add(col.Value.ToString());
        }
        
        foreach (var row in worksheet.RowsUsed().Skip(1))
        {
            var val = row.Cells().Select(v => v.Value);
            var dr = table.NewRow();
            dr.ItemArray = val.ToDynamicArray();
            table.Rows.Add(dr);
        }

        return table;
    }
}