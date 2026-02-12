using AspNetCore.IQueryable.Extensions.Sort;

namespace server.Shared.DataGrid;

public interface IDataGrid : IQuerySort
{
      public long? Id { get; set; }
      public int PageNow { get; set; }
      
      public int PageSize { get; set; }
      
      public bool Pagination { get; set; }
}