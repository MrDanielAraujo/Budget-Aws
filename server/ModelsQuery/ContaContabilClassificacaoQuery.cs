using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using server.Shared.DataGrid;

namespace server.ModelsQuery;

public class ContaContabilClassificacaoQuery : IDataGrid
{
      public long? Id { get; set; }

      [QueryOperator(Operator = WhereOperator.Contains)]
      public string? Nome { get; set; }

      [QueryOperator(Operator = WhereOperator.EqualsWhenNullable)]
      public long? Codigo { get; set; }
      public int PageNow { get; set; }

      public int PageSize { get; set; }

      public bool Pagination { get; set; }

      public string? Sort { get; set; }
}