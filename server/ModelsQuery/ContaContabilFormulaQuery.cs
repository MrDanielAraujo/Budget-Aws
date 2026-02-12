using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using server.Shared.DataGrid;

namespace server.ModelsQuery;

public class ContaContabilFormulaQuery : IDataGrid
{
      public long? Id { get; set; }

      [QueryOperator(Operator = WhereOperator.Contains)]
      public string? Formula { get; set; }

      [QueryOperator(Operator = WhereOperator.Contains)]
      public string? Descricao { get; set; }

      public int PageNow { get; set; }

      public int PageSize { get; set; }

      public bool Pagination { get; set; }

      public string? Sort { get; set; }
}